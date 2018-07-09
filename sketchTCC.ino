#include <PID_v1.h>                                     // Biblioteca do PID automático
#include <string.h>                                     // Biblioteca para manipulação de string
#include <Wire.h>                                       // Biblioteca para comunicação serial
#include <Adafruit_MCP4725.h>                           // Biblioteca do conversor digital analógico

double sinalop, setpoint, VP, OUT;                      // Sinal de operação, setpoint, input, output
double VPmatriz[21], OUTmatriz[21];                     // Matrizes dos últimos valores de input e output
double VPvar = (50),VPmax = (3500),VPmin = (500),       // Limites da estabilidade do sistema
       OUTvar = (50), OUTmax = (3500), OUTmin = (500);  // 
double IntOUT, IntERR;                                  // Integrais do erro e output 
double MIntOUT[5], MIntERR[5];                          // Matriz das integrais do erro e output 
double mOUT, mVP;                                       // Média das matrizes de input e output
double erro;                                            // Erro do sistema
double Au = 0, Ad = 0;                                  // Pico e Vale do relé
double MAu[5], MAd[5];                                  // Matrizes de Pico e Vale
double d = (200), biasd = (250);                        // Amplitude do relé e bias da amplitude 
double his = (100), biashis = (250);                    // Histerese do relé e bias da histerese
double lambda = 2;                                      // Grava o valor de Lambda
double contador = 0;                                    // Contador de transições de estado do relé
double Tom, MTom[9];                                    // Atraso medido e matriz de atraso 
unsigned long time0 = millis();                         // Usado para contar tempo para envio de dados do gráfico
unsigned long time1 = millis();                         // Usado para contar tempo para cálculo da estabilidade 
unsigned long time2 = millis();                         // Usado para marcar o início do tempo para cálculo das integrais  
unsigned long time3 = millis();                         // Usado para calcular o intervalo de tempo das integrais
unsigned long now = millis();                           // Usado para enviar o momento atual para o gráfico 
unsigned long Toff0, Ton0;                              // Usado para marcar o início do tempo ON e OFF do relé 
unsigned long MTon[5], MToff[5];                        // Matrizes de tempo ON e OFF do relé 
unsigned long checkTime = 0;                            // Usado para comparar tempo para leitura de dados
int Acao = 1;                                           // Acão do controlador (direta ou reversa)
int Metodo = 1;                                         // Método de parametrização 
int Malha = 0;                                          // Malha utilizada (Aberta, Relé, PID)
int Modelo = 1;                                         // Modelo utlizado após a parametrização (ON/OFF/Media, t0 medido/calculado)
int lastSent = 1;                                       // Últimos dados enviados
int sizetoSend = 0;                                     // Tamanho do dado a ser enviado
int checkSize = 0;                                      // Auxiliar do tamanho a ser enviado
int commandC = 0;                                       // Comando recebido pelo C#
int sizeReceived = 0;                                   // Tamanho do dado recebido
int SampleTime = 200;                                   // Taxa de amostragem do PID pré-setado em 200 milisegundos
bool estavel = false;                                   // Status de estabilidade do sistema
bool rele = false;                                      // Status da lógica relé
bool parametros = false;                                // Flag de parâmetros do relé
bool dadosgrafico = false;                              // Flag para envio de dados para o gráfico
bool timerenvio = false;                                // Flag para aguardar o tempo para envio 
bool regrele = false;                                   // Flag para registro de uso do relé
bool sentrele = true;                                   // Flag para sentido do relé
/*Variáveis do PID simples*/
unsigned long lastTime;
double errSum = 0, lastErr = 0;
double kp, ki, kd;

// Criando o PID com os parâmetros: Input -> 'VP', Output -> 'OUT', Setpoint -> 'setpoint', Kp -> '1', Ki -> '0', Kd -> '0', Termo Proporcional -> 'on Error', Atuação -> 'Direta'
PID pid(&VP, &OUT, &setpoint, 1, 0, 0, P_ON_E, DIRECT); 
Adafruit_MCP4725 dac;                                   // Criando o conversor analógico digital 

// Função de computação do PID Simples
void pidsimCompute()
{
   //unsigned long now = millis();
   int timeChange = (now - lastTime);
   if(timeChange >= SampleTime)
   {
      /*Compute all the working error variables*/
      double error = setpoint - VP;
      errSum += error;
      double dErr = (error - lastErr);
      /*Compute PID Output*/
      OUT = kp * error + ki * errSum + kd * dErr;
      /*Remember some variables for next time*/
      lastErr = error;
      lastTime = now;
   }
}
 
// Função de troca de parâmetros do PID Simples 
void pidsimSetTunings(double Kp, double Ki, double Kd)
{
  double SampleTimeInSec = ((double)SampleTime)/1000;
   kp = Kp;
   ki = Ki * SampleTimeInSec;
   kd = Kd / SampleTimeInSec;
}

// Função de mudança do tempo de amostragem do PID Simples   
void pidsimSetSampleTime(int NewSampleTime)
{
   if (NewSampleTime > 0)
   {
      double ratio  = (double)NewSampleTime / (double)SampleTime;
      ki *= ratio;
      kd /= ratio;
      SampleTime = (unsigned long)NewSampleTime;
   }
}

// Função que retorna o valor mínimo do vetor (recebe todas as posições do vetor exceto a primeira que é utilizada como índice e não é enviada)
double mini(double *vet, unsigned char tam){                
  double m = vet[0];                                        // A primeira posição (vet[0]) é segunda posição do vetor enviado
  for (int c = 1; c < tam; c++) if (vet[c] < m) m = vet[c]; // Compara e armazena se menor
  return m;
}

// Função que retorna o valor máximo do vetor (recebe todas as posições do vetor exceto a primeira que é utilizada como índice e não é enviada) 
double maxi(double *vet, unsigned char tam){                
  double m = vet[0];                                        // A primeira posição (vet[0]) é segunda posição do vetor enviado
  for (int c = 1; c < tam; c++) if (vet[c] > m) m = vet[c]; // Compara e armazena se maior
  return m;
}

// Função que retorna a média dos valores do vetor (recebe todas as posições do vetor exceto a primeira que é utilizada como índice e não é enviada)
double medi(double *vet, unsigned char tam){                
  double s = 0;                                             // 
  for (int c = 0; c < tam; c++) s += vet[c]/tam;            // Soma os valores divididos pelo tamanho do vetor
  return s;
}

// FUNÇÃO PARA ENVIO DE DADOS AO C# 
/* OS DADOS SÃO ENVIADOS DA SEGUINTE FORMA: HEADER + DADOS + CHECKSUM 
EXISTEM 5 GRUPOS DE DADOS ENVIADOS:
1- DADOS PARA O GRÁFICO DO C# E ESTABILIDADE
2- PARÂMETROS OBTIDOS NA LÓGICA RELÉ
3- DADOS PARA INICIALIZAÇÃO DO FORM
4- VALOR DO SETPOINT ALTERADO PELO 'Tracking' 
5- PEDIDO DE REENVIO DE DADO EM CASO DE ERRO */
void dataPrint(int command) { // 
  if (command != 5) //
    lastSent = command; //                                                                    Tamanho   Tipo
  Serial.print("}=");                               // Header                                  +2 =2    char array
  Serial.print(commandC);                           // último comando recebido do C#           +? =??   int                                                           
  sizetoSend = 2 + String(commandC).length(); //                                           TOTAL = 2 + ? 
  switch (command) { //                                                                        +
    case 1: // DADOS PARA O GRÁFICO DO C# E ESTABILIDADE                                      Tamanho   Tipo
      Serial.print(",A="); //                                                                  +3 =3    char array
      Serial.print(now);                            // milisegundos momento atual              +? =??   unsigned long
      Serial.print(",D="); //                                                                  +3 =6    char array
      Serial.print(VP);                             // valor input                             +? =??   double
      Serial.print(",E="); //                                                                  +3 =9    char array
      Serial.print(OUT);                            // valor output                            +? =??   double
      Serial.print(",t="); // *                                                                +3 =12   char array
      Serial.print(estavel);                        // status relé                             +1 =13   bool
      Serial.print(",v="); //                                                                  +3 =16   char array
      Serial.print(Malha);                          // status estabilidade                     +? =??   int
      //                                                                                   TOTAL = 16 + ?   
      sizetoSend += 16 + String(now).length() + String(VP).length() + String(OUT).length() + String(Malha).length(); // +   
    break; //                                                                                  +
    case 2: // PARÂMETROS OBTIDOS NA LÓGICA RELÉ                                              Tamanho   Tipo
      Serial.print(",F="); //                                                                  +3 =3    char array
      Serial.print(mVP);                                     // média inputs 10s               +? =??   double
      Serial.print(",G="); //                                                                  +3 =6    char array
      Serial.print(mOUT);                                    // média outputs 10s              +? =??   double
      Serial.print(",H="); //                                                                  +3 =9    char array
      Serial.print(sentrele);                                // sentido do relé                +1 =10   bool
      Serial.print(",N="); //                                                                  +3 =13   char array
      Serial.print(String(MTom[int(MTom[0]-7)%8 + 1]));      // Atraso medido no 1º ON         +? =??   double
      Serial.print(",O="); //                                                                  +3 =16   char array
      Serial.print(String(MTom[int(MTom[0]-6)%8 + 1]));      // Atraso medido no 1º OFF        +? =??   double
      Serial.print(",P="); //                                                                  +3 =19   char array
      Serial.print(String(MTom[int(MTom[0]-5)%8 + 1]));      // Atraso medido no 2º ON         +? =??   double
      Serial.print(",Q="); //                                                                  +3 =22   char array
      Serial.print(String(MTom[int(MTom[0]-4)%8 + 1]));      // Atraso medido no 2º OFF        +? =??   double
      Serial.print(",R="); //                                                                  +3 =25   char array
      Serial.print(String(MTom[int(MTom[0]-3)%8 + 1]));      // Atraso medido no 3º ON         +? =??   double
      Serial.print(",S="); //                                                                  +3 =28   char array
      Serial.print(String(MTom[int(MTom[0]-2)%8 + 1]));      // Atraso medido no 3º OFF        +? =??   double
      Serial.print(",T="); //                                                                  +3 =31   char array
      Serial.print(String(MTom[int(MTom[0]-1)%8 + 1]));      // Atraso medido no 4º ON         +? =??   double
      Serial.print(",U="); //                                                                  +3 =34   char array
      Serial.print(String(MTom[int(MTom[0])%8 + 1]));        // Atraso medido no 4º OFF        +? =??   double
      Serial.print(",V="); //                                                                  +3 =37   char array
      Serial.print(String(MTon[int(MTon[0]-3)%4 + 1]));      // Tempo ON medido no 1º ciclo    +? =??   unsigned long
      Serial.print(",W="); //                                                                  +3 =40   char array
      Serial.print(String(MTon[(MTon[0]-2)%4 + 1]));         // Tempo ON medido no 2º ciclo    +? =??   unsigned long
      Serial.print(",X="); //                                                                  +3 =43   char array
      Serial.print(String(MTon[int(MTon[0]-1)%4 + 1]));      // Tempo ON medido no 3º ciclo    +? =??   unsigned long
      Serial.print(",Y="); //                                                                  +3 =46   char array
      Serial.print(String(MTon[int(MTon[0])%4 + 1]));        // Tempo ON medido no 4º ciclo    +? =??   unsigned long
      Serial.print(",Z="); //                                                                  +3 =49   char array
      Serial.print(String(MToff[int(MToff[0]-3)%4 + 1]));    // Tempo OFF medido no 1º ciclo   +? =??   unsigned long
      Serial.print(",[="); //                                                                  +3 =52   char array
      Serial.print(String(MToff[int(MToff[0]-2)%4 + 1]));    // Tempo OFF medido no 2º ciclo   +? =??   unsigned long
      Serial.print(",]="); //                                                                  +3 =55   char array
      Serial.print(String(MToff[int(MToff[0]-1)%4 + 1]));    // Tempo OFF medido no 3º ciclo   +? =??   unsigned long
      Serial.print(",^="); //                                                                  +3 =58   char array
      Serial.print(String(MToff[int(MToff[0])%4 + 1]));      // Tempo OFF medido no 4º ciclo   +? =??   unsigned long
      Serial.print(",_="); //                                                                  +3 =61   char array
      Serial.print(String(MAu[int(MAu[0]-3)%4 + 1]));        // Pico medido no 1º OFF          +? =??   double
      Serial.print(",'="); //                                                                  +3 =64   char array
      Serial.print(String(MAu[int(MAu[0]-2)%4 + 1]));        // Pico medido no 2º OFF          +? =??   double
      Serial.print(",a="); //                                                                  +3 =67   char array
      Serial.print(String(MAu[int(MAu[0]-1)%4 + 1]));        // Pico medido no 3º OFF          +? =??   double
      Serial.print(",b="); //                                                                  +3 =70   char array
      Serial.print(String(MAu[int(MAu[0])%4 + 1]));          // Pico medido no 4º OFF          +? =??   double
      Serial.print(",c="); //                                                                  +3 =73   char array
      Serial.print(String(MAd[int(MAd[0]-3)%4 + 1]));        // Vale medido no 1º ON           +? =??   double
      Serial.print(",d="); //                                                                  +3 =76   char array
      Serial.print(String(MAd[int(MAd[0]-2)%4 + 1]));        // Vale medido no 2º ON           +? =??   double
      Serial.print(",e="); //                                                                  +3 =79   char array
      Serial.print(String(MAd[int(MAd[0]-1)%4 + 1]));        // Vale medido no 3º ON           +? =??   double
      Serial.print(",f="); //                                                                  +3 =82   char array
      Serial.print(String(MAd[int(MAd[0])%4 + 1]));          // Vale medido no 4º ON           +? =??   double
      Serial.print(",g="); //                                                                  +3 =85   char array
      Serial.print(String(MIntERR[int(MIntERR[0]-3)%4 + 1]));// Integral do Erro do 1º ciclo   +? =??   double
      Serial.print(",h="); //                                                                  +3 =88   char array
      Serial.print(String(MIntERR[int(MIntERR[0]-2)%4 + 1]));// Integral do Erro do 2º ciclo   +? =??   double
      Serial.print(",i="); //                                                                  +3 =91   char array
      Serial.print(String(MIntERR[int(MIntERR[0]-1)%4 + 1]));// Integral do Erro do 3º ciclo   +? =??   double
      Serial.print(",j="); //                                                                  +3 =94   char array
      Serial.print(String(MIntERR[int(MIntERR[0])%4 + 1]));  // Integral do Erro do 4º ciclo   +? =??   double
      Serial.print(",k="); //                                                                  +3 =97   char array
      Serial.print(String(MIntOUT[int(MIntOUT[0]-3)%4 + 1]));// Integral do Output do 1º ciclo +? =??   double
      Serial.print(",l="); //                                                                  +3 =100   char array
      Serial.print(String(MIntOUT[int(MIntOUT[0]-2)%4 + 1]));// Integral do Output do 2º ciclo +? =??   double
      Serial.print(",m="); //                                                                  +3 =103   char array
      Serial.print(String(MIntOUT[int(MIntOUT[0]-1)%4 + 1]));// Integral do Output do 3º ciclo +? =??   double
      Serial.print(",n="); //                                                                  +3 =106   char array
      Serial.print(String(MIntOUT[int(MIntOUT[0])%4 + 1]));  // Integral do Output do 4º ciclo +? =??   double
      //                                                                                   TOTAL = 106 + ? 
      sizetoSend += 106 + String(mVP).length() + String(mOUT).length() +
                    String(MTom[int(MTom[0]-7)%8 + 1]).length() + String(MTom[int(MTom[0]-6)%8 + 1]).length() + String(MTom[int(MTom[0]-5)%8 + 1]).length() + String(MTom[int(MTom[0]-4)%8 + 1]).length() +
                    String(MTom[int(MTom[0]-3)%8 + 1]).length() + String(MTom[int(MTom[0]-2)%8 + 1]).length() + String(MTom[int(MTom[0]-1)%8 + 1]).length() + String(MTom[int(MTom[0])%8 + 1]).length() +
                    String(MTon[int(MTon[0]-3)%4 + 1]).length() + String(MTon[int(MTon[0]-2)%4 + 1]).length() + String(MTon[int(MTon[0]-1)%4 + 1]).length() + String(MTon[int(MTon[0])%4 + 1]).length() +
                    String(MToff[int(MToff[0]-3)%4 + 1]).length() + String(MToff[int(MToff[0]-2)%4 + 1]).length() + String(MToff[int(MToff[0]-1)%4 + 1]).length() + String(MToff[int(MToff[0])%4 + 1]).length() +
                    String(MAu[int(MAu[0]-3)%4 + 1]).length() + String(MAu[int(MAu[0]-2)%4 + 1]).length() + String(MAu[int(MAu[0]-1)%4 + 1]).length() + String(MAu[int(MAu[0])%4 + 1]).length() +
                    String(MAd[int(MAd[0]-3)%4 + 1]).length() + String(MAd[int(MAd[0]-2)%4 + 1]).length() + String(MAd[int(MAd[0]-1)%4 + 1]).length() + String(MAd[int(MAd[0])%4 + 1]).length() +
                    String(MIntERR[int(MIntERR[0]-3)%4 + 1]).length() + String(MIntERR[int(MIntERR[0]-2)%4 + 1]).length() + String(MIntERR[int(MIntERR[0]-1)%4 + 1]).length() + String(MIntERR[int(MIntERR[0])%4 + 1]).length() + 
                    String(MIntOUT[int(MIntOUT[0]-3)%4 + 1]).length() + String(MIntOUT[int(MIntOUT[0]-2)%4 + 1]).length() + String(MIntOUT[int(MIntOUT[0]-1)%4 + 1]).length() + String(MIntOUT[int(MIntOUT[0])%4 + 1]).length(); 
                    //String(K).length(); 
    break; //                                                                                  + 
    case 3: // DADOS PARA INICIALIZAÇÃO DO FORM                                               Tamanho   Tipo
      Serial.print(",B="); //                                                                  +3 =3    char array
      Serial.print(setpoint);                       // valor setpoint                          +? =??   double
      Serial.print(",C="); //                                                                  +3 =6    char array
      Serial.print(sinalop);                        // valor sinal de operação                 +? =??   double
      Serial.print(",J="); //                                                                  +3 =9    char array
      Serial.print(lambda);                         // valor lambda                            +? =??   double
      Serial.print(",o="); //                                                                  +3 =12    char array
      Serial.print(his);                            // valor histerese relé                    +? =??   double
      Serial.print(",p="); //                                                                  +3 =15   char array
      Serial.print(biashis);                        // valor bias histerese                    +? =??   double
      Serial.print(",q="); //                                                                  +3 =18   char array
      Serial.print(d);                              // valor amplitude relé                    +? =??   double
      Serial.print(",r="); //                                                                  +3 =21   char array
      Serial.print(biasd);                          // valor bias amplitude                    +? =??   double
      Serial.print(",u="); //                                                                  +3 =24   char array
      Serial.print(Modelo);                         // modelo utilizado                        +? =??   int
      Serial.print(",v="); //                                                                  +3 =27   char array
      Serial.print(Malha);                          // malha utilizada                         +? =??   int
      Serial.print(",w="); //                                                                  +3 =30   char array
      Serial.print(Metodo);                         // método de parametrização                +? =??   int
      Serial.print(",x="); //                                                                  +3 =33   char array
      Serial.print(SampleTime);                     // taxa de amostragemm                     +? =??   int
      Serial.print(",y="); //                                                                  +3 =36   char array
      Serial.print(pid.GetKp());                    // valor ganho proporcional                +? =??   ?
      Serial.print(",z="); //                                                                  +3 =39   char array
      Serial.print(pid.GetKi());                    // valor ganho integral                    +? =??   ?
      Serial.print(",{="); //                                                                  +3 =39   char array
      Serial.print(pid.GetKd());                    // valor ganho derivativo                  +? =??   ?
      //                                                                                   TOTAL = 42 + ?
      sizetoSend += 42 + String(setpoint).length() + String(sinalop).length() + String(lambda).length() + String(his).length()  + String(biashis).length() + String(d).length() + String(biasd).length() +  String(Malha).length() + 
                    String(Modelo).length() + String(Metodo).length() + String(SampleTime).length() + String(pid.GetKp()).length() + String(pid.GetKi()).length() + String(pid.GetKd()).length(); 
      if (regrele) parametros = true; //                                                       +
    break; //                                                                                  +
    case 4: // VALOR DO SETPOINT ALTERADO PELO 'Tracking'                                     Tamanho   Tipo            
      Serial.print(",B="); //                                                                  +3 =3    char array
      Serial.print(setpoint); //    valor setpoint                                             +? =??   double 
      Serial.print(",C="); //                                                                  +3 =6    char array
      Serial.print(sinalop); //     valor sinalop                                              +? =??   double
      sizetoSend += 6 + String(setpoint).length() + String(sinalop).length(); //           TOTAL = 6 + ?
    break; //                                                                                  +
    case 5: // PEDIDO DE REENVIO DE DADO EM CASO DE ERRO                                      Tamanho   Tipo
      Serial.print(",|="); //                                                                  +3 =3    char array
      sizetoSend += 3; //                                                                  TOTAL = 3 
    break; //                                                                                  +
  } //                                                                                        Tamanho   Tipo
  Serial.print(",~="); // CheckSum                                                             +3       char array
  checkSize = String(sizetoSend).length(); //                                                  +                                                   
  sizetoSend += 5 + String(sizetoSend).length(); //                                            +
  if (String(sizetoSend).length() > checkSize) //                                              +
    sizetoSend += String(sizetoSend).length() - checkSize; //                                  +
  Serial.print(sizetoSend); // Checksum                                                        +? =??   int
  Serial.println(","); // Fim do dado                                                          +2 =5    char + /r
  Serial.flush(); //                                                                       TOTAL = 5 + ? 
}

//FUNÇÃO PARA LEITURA DOS DADOS RECEBIDOS PELO C#
void read() {  
  char *text;                                                        // Variável para auxiliar a leitura do dado
  text = (char*)malloc(sizeof(char)* (sizeReceived + 1));            // Reserva um espaço de memória no Arduino do tamanho do dado + 1
  for (char pos = 0; pos < sizeReceived; pos++)                      // Lê e armazena byte a byte o dado 
    text[pos] = Serial.read();
  text[sizeReceived+1] = 0;                                          // Adiciona um zero ao final do dado indicando o término do pacote recebido 
  ReadComp(text);                                                    // Chama a função que irá processar o dado
  free(text);                                                        // Libera o espaço reservado pela váriavel
}

// FUNÇÃO PARA PROCESSAMENTO DOS DADOS
// OBS: Toda vez que executa essa lógica a função dataPrint é chamada uma única vez exceto quando timerenvio é acionado
void ReadComp(char *text) {                                          // Função para processar as informações vindas do C# 
  char *aux;                                                         // Variável para auxiliar o processamento do dado
  double value;                                                      // Variavel para armazenar a parte numérica do dado recebido 
  if (strncmp(text, "}", 1) == 0) {                                  // Checa se o dado recebido do C# possui o Header (}) 
    aux = text + 2;                                                  // Armazena o endereço do 3º byte da mensagem
    value = strtod(aux, &aux);                                       // A variável value recebe a partir do 3º byte o valor lido em string convertido em double  
    commandC = strncmp(text, "}@", 2);                               // Compara os 2 primeiros char depois da mensagem com "}@" e recebe o valor da diferença em Int
    switch (commandC) {                                              // Switch Case do comando (aux[0]) recebido do C#
      case 2://........................................................ }B (B - @ = 2) - Comando para alterar o valor do setpoint
        setpoint = value;                                            // Armazena o novo valor de setpoint
        dadosgrafico = true;                                         // Aciona flag informando que é para enviar dados para o gráfico do C#
      break;
      case 3://........................................................ }C (C - @ = 3) - Comando para alterar o valor do sinal de operação 
        sinalop = value;                                             // Armazena o novo valor do sinal de operação
        dadosgrafico = true;                                         // Aciona flag do gráfico informando que é para enviar dados para o gráfico pro C#
      break;
      case 4://........................................................ }D (D - @ = 4) - Comando para alterar o valor da variação de VP para estabilidade
        VPvar = value;                                               // Armazena o novo valor da variação de VP para estabilidade
        dadosgrafico = true;                                         // Aciona flag do gráfico informando que é para enviar dados para o gráfico pro C#
      break;
      case 5://........................................................ }E (E - @ = 5) - Comando para alterar o valor máximo de VP para estabilidade
        VPmax = value;                                               // Armazena o novo valor máximo de VP para estabilidade
        dadosgrafico = true;                                         // Aciona flag do gráfico informando que é para enviar dados para o gráfico pro C#
      break;
      case 6://....................................................... }F (F - @ = 6) - Comando para alterar o valor mínimo de VP para estabilidade
        VPmin = value;                                               // Armazena o novo valor mínimo de VP para estabilidade
        dadosgrafico = true;                                         // Aciona flag do gráfico informando que é para enviar dados para o gráfico pro C#
      break; 
      case 7://....................................................... }G (G - @ = 7) - Comando para alterar o valor da variação de OUT para estabilidade
        OUTvar = value;                                              // Armazena o novo valor da variação de OUT para estabilidade
        dadosgrafico = true;                                         // Aciona flag do gráfico informando que é para enviar dados para o gráfico pro C#
      break;
      case 8://....................................................... }H (H - @ = 8) - Comando para alterar o valor máximo de OUT para estabilidade
        OUTmax = value;                                              // Armazena o novo valor  máximo de OUT para estabilidade
        dadosgrafico = true;                                         // Aciona flag do gráfico informando que é para enviar dados para o gráfico pro C#
      break;
      case 9://....................................................... }I (I - @ = 9) - Comando para alterar o valor mínimo de OUT para estabilidade
        OUTmin = value;                                              // Armazena o novo valor mínimo de OUT para estabilidade
        dadosgrafico = true;                                         // Aciona flag do gráfico informando que é para enviar dados para o gráfico pro C#
      break;
      case 10://....................................................... }J (J - @ = 10) - Comando para alterar o valor de Lambda
        lambda = value;                                              // Armazena o novo valor mínimo de Lambda
        dadosgrafico = true;                                         // Aciona flag do gráfico informando que é para enviar dados para o gráfico pro C#
      break;
      case 11://....................................................... }K (K - @ = 11) - Comando para alterar a ação do controlador
        if (value) {                                                 // Ação Direta                                                  
          Acao = 1;  
          pid.SetControllerDirection(DIRECT);
        }
        else {                                                       // Ação Reversa
          Acao = -1; 
          pid.SetControllerDirection(REVERSE);
        }
        dadosgrafico = true;                                         // Aciona flag do gráfico informando que é para enviar dados para o gráfico pro C#
      break;
      case 47://....................................................... }o (o - @ = 47) - Comando para alterar o valor da histerese do relé
        his = value;                                                 // Armazena o novo valor da histerese do relé
        dadosgrafico = true;                                         // Aciona flag do gráfico informando que é para enviar dados para o gráfico pro C#
      break;
      case 48://....................................................... }p (p - @ = 48) - Comando para alterar o valor da bias histerese
        biashis = value;                                             // Armazena o novo valor da bias histerese
        dadosgrafico = true;                                         // Aciona flag do gráfico informando que é para enviar dados para o gráfico pro C#
      break;
      case 49://....................................................... }q (q - @ = 49) - Comando para alterar o valor da amplitude do relé 
        d = value;                                                   // Armazena o novo valor da amplitude do relé
        dadosgrafico = true;                                         // Aciona flag do gráfico informando que é para enviar dados para o gráfico pro C#
      break;
      case 50://....................................................... }r (r - @ = 50) - Comando para alterar o valor da bias amplitude  
        biasd = value;                                               // Armazena o novo valor da bias amplitude 
        dadosgrafico = true;                                         // Aciona flag do gráfico informando que é para enviar dados para o gráfico pro C#
      break;
      case 51://....................................................... }s (s - @ = 51) - Comando para enviar dados para inicialização do form no C#
        dadosgrafico = false;                                        // Desaciona flag do gráfico
        dataPrint(3);                                                // Chama a função dataPrint() enviando o comando (3) 
        lastSent = 3;                                                // Armazena o último comando enviado (3)
      break;
      case 52://....................................................... }t (t - @ = 52) - Comando para enviar dados para o gráfico do C#
        dadosgrafico = true;                                         // Aciona flag do gráfico informando que é para enviar dados para o gráfico pro C#
      break;
      case 53://....................................................... }u (u - @ = 52) - Comando para enviar dados para o gráfico do C#
        Modelo = value;                                              // Armazena o novo modelo utilizado 
        dadosgrafico = true;                                         // Aciona flag do gráfico informando que é para enviar dados para o gráfico pro C#
      break;
      case 54://....................................................... }v (v - @ = 54) - Comando para alterar a malha (Aberta, Relé, PID)
        if (value == 0) {                                            // Comando para iniciar malha Aberta 
          Malha = 0;                                                 // Seleciona a malha Aberta
          pid.SetMode(MANUAL);                                       // Seleciona o modo manual pro PID
          sinalop = OUT;                                             // O sinal de operação recebe o valor da saída do controlador 
          dataPrint(4);                                              // Chama a função dataPrint() enviando o comando (4) 
          lastSent = 4;                                              // Armazena o último comando enviado (4)
        }
        if (value == 1) {                                            // Comando para iniciar lógica relé
          sentrele = true;                                           // Sentido do relé acima do ponto de operação
          contador = 0;                                              // Zera o contador de transições do relé
          mOUT = medi(&OUTmatriz[1],20);                             // Cálcula o valor médio do output dos últimos 10 segundos
          mVP = medi(&VPmatriz[1],20);                               // Cálcula o valor médio do input dos últimos 10 segundos
          OUT = mOUT + biasd + d;                                    // Seta a saída com o valor do ponto de operação mais a amplitude do relé
          Malha = 1;                                                 // Seleciona a malha Relé 
          pid.SetMode(MANUAL);                                       // Seleciona o modo manual pro PID
          dadosgrafico = true;                                       // Aciona flag do gráfico informando que é para enviar dados para o gráfico pro C#
        }
        if (value == 2) {                                            // Comando para iniciar lógica relé
          sentrele = false;                                          // Sentido do relé abaixo do ponto de operação
          contador = 0;                                              // Zera o contador de transições do relé
          mOUT = medi(&OUTmatriz[1],20);                             // Cálcula o valor médio do output dos últimos 10 segundos
          mVP = medi(&VPmatriz[1],20);                               // Cálcula o valor médio do input dos últimos 10 segundos
          OUT = mOUT - biasd - d;                                    // Seta a saída com o valor do ponto de operação mais a amplitude do relé
          Malha = 2;                                                 // Seleciona a malha Relé 
          pid.SetMode(MANUAL);                                       // Seleciona o modo manual pro PID
          dadosgrafico = true;                                       // Aciona flag do gráfico informando que é para enviar dados para o gráfico pro C#
        }
        if (value == 3) {                                            // Comando para iniciar PID automático
          Malha = 3;                                                 // Seleciona a malha PID automático 
          pid.SetMode(AUTOMATIC);                                    // Seleciona o modo automático pro PID
          setpoint = VP;                                             // Lógica de Tracking Setpoint para evitar alterações bruscas no controle 
          dataPrint(4);                                              // Chama a função dataPrint() enviando o comando (4) 
          lastSent = 4;                                              // Armazena o último comando enviado (4)
        }
        if (value == 4) {                                            // Comando para iniciar PID simples
          Malha = 4;                                                 // Seleciona a malha PID simples 
          pid.SetMode(MANUAL);                                       // Seleciona o modo manual pro PID
          errSum = 0;                                                // Zera a integral do erro da lógica PID simples
          lastErr = 0;                                               // Zera o último erro da lógica PID simples
          setpoint = VP;                                             // Lógica de Tracking Setpoint para evitar alterações bruscas no controle 
          dataPrint(4);                                              // Chama a função dataPrint() enviando o comando (4) 
          lastSent = 4;                                              // Armazena o último comando enviado (4)
        }
      break;
      case 55://....................................................... }w (w - @ = 55) - Comando para armazenar o método usado na obtenção dos parâmetros do PID 
        Metodo = value;                                              // Armazena o método usado na obtenção dos parâmetros do PID
        dadosgrafico = true;                                         // Aciona flag do gráfico informando que é para enviar dados para o gráfico pro C#
      break;
      case 56://....................................................... }x (x - @ = 56) - lógica para alterar o valor da taxa de amostragem
        pid.SetSampleTime(value);                                    // Armazena a nova taxa de amostragem pro PID automático
        pidsimSetSampleTime(value);                                  // Armazena a nova taxa de amostragem pro PID simples
        dadosgrafico = true;                                         // Aciona flag do gráfico informando que é para enviar dados para o gráfico pro C#
      break;
      case 57://....................................................... }y (y - @ = 57) - Comando para alterar o valor do ganho proporcional
        pid.SetTunings(value, pid.GetKi(), pid.GetKd());             // Armazena o valor de Kp no PID automático
        pidsimSetTunings(value, pid.GetKi(), pid.GetKd());           // Armazena o valor de Kp no PID simples
        dadosgrafico = true;                                         // Aciona flag do gráfico informando que é para enviar dados para o gráfico pro C#
      break;
      case 58://....................................................... }z (z - @ = 58) - Comando para alterar o valor do ganho integral 
        pid.SetTunings(pid.GetKp(), value, pid.GetKd());             // Armazena o valor de Ki no PID automático
        pidsimSetTunings(pid.GetKp(), value, pid.GetKd());           // Armazena o valor de Ki no PID simples
        dadosgrafico = true;                                         // Aciona flag do gráfico informando que é para enviar dados para o gráfico pro C#
      break;
      case 59://....................................................... }{ ({ - @ = 59) - Comando para alterar o valor do ganho derivativo 
        pid.SetTunings(pid.GetKp(), pid.GetKi(), value);             // Armazena o valor de Kd no PID automático
        pidsimSetTunings(pid.GetKp(), pid.GetKi(), value);           // Armazena o valor de Kd no PID simples
        dadosgrafico = true;                                         // Aciona flag do gráfico informando que é para enviar dados para o gráfico pro C#
      break;
      case 60://....................................................... }| (| - @ = 60) - lógica para reenviar dados que não foram transferidos corretamente para o C#
        dataPrint(lastSent);                                         // Chama a função dataPrint() enviando o comando último comando enviado
      break;
      default://....................................................... Lógica para requisitar reenvio de dado caso não receba nenhum comando
        dataPrint(5);                                                // Chama a função dataPrint() enviando o comando (5) 
      break; 
    }
    // A flag do gráfico é acionada nos 'case' que não chamam a função dataPrint(). É usada na lógica para garantir que algum dado seja enviado ao C#
    if (dadosgrafico){                                               // Confere se a flag do gráfico está acionada 
      if (parametros)                                                // Confere se a flag de parametros está acionada 
      {
        dataPrint(2);                                                // Chama a função dataPrint() enviando o comando (2)
        lastSent = 2;                                                // Armazena o último comando enviado (2)
        parametros = false;                                          // Desaciona flag dos parâmetros
      }
      else 
        timerenvio = true;                                           // Aciona flag de envio para ser utilizada no Loop
    }
    dadosgrafico = false;                                            // Desaciona flag do gráfico 
  }
  else {                                                             // Lógica para requisitar reenvio de dado caso não receba o Header
    commandC = 0;                                                    // Zera commandC (Header) antes de enviar o dado pro C# (para corrigir bug no C#) 
    dataPrint(5);                                                    // Chama a função dataPrint() enviando o comando (5) 
  }
}

// FUNÇÃO PARA PROCESSAMENTO DA LÓGICA RELÉ
void iniciarele(){   
  erro = mVP - VP;
  if (!sentrele)
  {
    // IF que seta a saída do relé para 'OFF' se: 1) o input esta na faixa de histerese e a saída é OFF ou 2) se é maior que o ponto de operação mais a histerese
    if (((erro < (biashis + his)) && (OUT == (mOUT - biasd - (d*Acao))))||(erro <= (biashis - his))){ 
      if (OUT == (mOUT - biasd + (d*Acao))){                           // Se for a primeira vez que esteja entrando no IF anterior, ou seja caso a saída anterior fosse ON   
        Toff0 = now;                                                   // Grava o momento que ocorre a transição de ON pra OFF
        MTon[((int)(MTon[0]++)%4)+1] = now - Ton0;                     // Grava na matriz o total de tempo ON da última transição        
        MTom[((int)(MTom[0]++)%8)+1] = Tom - Ton0;                     // Grava na matriz o delay medido durante o semi-ciclo ON  
        Au = mVP - biashis;                                            // Reseta o valor de pico pro ponto de operação gravado
        if (VP > Au) {                                                 // Compara se o valor atual da entrada é maior que o de pico
          Au = VP;                                                     // Armazena o novo valor do pico 
          Tom = now;                                                   // Armazena o momento que ocorre o pico
        }
        MAd[((int)(MAd[0]++)%4)+1] = Ad - mVP;                         // Grava na matriz o valor do vale da última transição
        OUT = mOUT - biasd - (d*Acao);                                 // Seta a saída com o valor do ponto de operação menos a amplitude do relé
      } else  if (VP > Au) {                                           // Compara se o valor atual da entrada é maior que o de pico
        Au = VP;                                                       // Armazena o novo valor do pico 
        Tom = now;                                                     // Armazena o momento que ocorre o pico
      }
    }   
    // IF que seta a saída do relé para 'ON' se: 1) o input esta na faixa de histerese e a saída é ON ou 2) se é menor que o ponto de operação menos a histerese
    if (((erro > (biashis - his)) && (OUT == (mOUT - biasd + (d*Acao))))||(erro >= (biashis + his))){ 
      if ( OUT == mOUT - biasd - (d*Acao)) {                           // Se for a primeira vez que esteja entrando no IF anterior, ou seja caso a saída anterior fosse OFF 
        contador++;                                                    // Contador de ciclos
        if ((contador >=2) && (contador <= 6)) {                       // Confere se está entre os ciclos utilizados para o cálculo das integrais
          if (contador == 2) { 
            time2 = now;                                               // Confere se está no primeiro ciclo usado para cálculo, e armazena o momento que inicia se verdadeiro
            MIntERR[0] = 0;                                            // Zerando os indices para ordenar os ciclos
            MIntOUT[0] = 0;
            MToff[0] = 0;
            MTon[0] = 0;
            MTom[0] = 0;
            MAu[0] = 0;
            MAd[0] = 0;
          }
          else {
            time3 = now - time2;                                       // Cálcula a diferença entre o momento atual e a última vez que foram calculadas as integrais
            IntERR += erro * time3;                                    // Calculo da integral do erro
            IntOUT += (OUT - mOUT) * time3;                            // Calculo da integral de OUT
            MIntERR[((int)(MIntERR[0]++)%4)+1] = IntERR;               // Grava na matriz o valor da integral do erro
            MIntOUT[((int)(MIntOUT[0]++)%4)+1] = IntOUT;               // Grava na matriz o valor da integral de OUT 
            time2 += time3;                                            // Grava o momento final da integral que será o inicio da próxima
          }
          IntERR = 0;                                                  // Zera a integral do erro
          IntOUT = 0;                                                  // Zera a integral de OUT
        } 
        Ton0 = now;                                                    // Grava o momento que ocorre a transição de OFF pra ON
        MToff[((int)(MToff[0]++)%4)+1] = now - Toff0;                  // Grava na matriz o tempo OFF da última transição        
        MTom[((int)(MTom[0]++)%8)+1] = Tom - Toff0;                    // Grava na matriz o delay medido no semiciclo OFF  
        Ad = mVP - biashis;                                            // Reseta o valor de vale pro ponto de operação gravado      
        if (VP < Ad) {                                                 // Compara se o valor atual da entrada é menor que o de vale 
          Ad = VP;                                                     // Armazena o novo valor de vale 
          Tom = now;                                                   // Armazena o momento que ocorre o vale 
        }
        MAu[((int)(MAu[0]++)%4)+1] = Au - mVP;                         // Grava na matriz o valor do pico da última transição
        OUT = (mOUT - biasd + (d*Acao));                               // Seta a saída com o valor do ponto de operação mais a amplitude do relé   
      } else  if (VP < Ad) {                                           // Compara se o valor atual da entrada é menor que o de vale 
        Ad = VP;                                                       // Armazena o novo valor de vale
        Tom = now;                                                     // Armazena o momento que ocorre o vale 
      }
    }
  } 
  else if (sentrele)
  {
    // IF que seta a saída do relé para 'OFF' se: 1) o input esta na faixa de histerese e a saída é OFF ou 2) se é maior que o ponto de operação mais a histerese
    if (((erro < -(biashis - his)) && (OUT == (mOUT + biasd - (d*Acao))))||(erro <= -(biashis + his))){ 
      if (OUT == (mOUT + biasd + (d*Acao))){                           // Se for a primeira vez que esteja entrando no IF anterior, ou seja caso a saída anterior fosse ON   
        Toff0 = now;                                                   // Grava o momento que ocorre a transição de ON pra OFF
        MTon[((int)(MTon[0]++)%4)+1] = now - Ton0;                     // Grava na matriz o tempo ON da última transição        
        MTom[((int)(MTom[0]++)%8)+1] = Tom - Ton0;                     // Grava na matriz o delay medido durante o semiciclo ON  
        Au = mVP + biashis;                                            // Reseta o valor de pico pro ponto de operação gravado
        if (VP > Au) {                                                 // Compara se o valor atual da entrada é maior que o de pico
          Au = VP;                                                     // Armazena o novo valor do pico 
          Tom = now;                                                   // Armazena o momento que ocorre o pico
        }
        MAd[((int)(MAd[0]++)%4)+1] = Ad - mVP;                         // Grava na matriz o valor do vale da última transição
        OUT = mOUT + biasd - (d*Acao);                                 // Seta a saída com o valor do ponto de operação menos a amplitude do relé
      } else  if (VP > Au) {                                           // Compara se o valor atual da entrada é maior que o de pico
        Au = VP;                                                       // Armazena o novo valor do pico 
        Tom = now;                                                     // Armazena o momento que ocorre o pico
      }
    } 
    // IF que seta a saída do relé para 'ON' se: 1) o input esta na faixa de histerese e a saída é ON ou 2) se é menor que o ponto de operação menos a histerese
    if (((erro > -(biashis + his)) && (OUT == (mOUT + biasd + (d*Acao))))||(erro >= -(biashis - his))){ 
      if ( OUT == mOUT + biasd - (d*Acao)) {                           // Se for a primeira vez que esteja entrando no IF anterior, ou seja caso a saída anterior fosse OFF 
        contador++;                                                    // Contador de ciclos
        if ((contador >=2) && (contador <= 6)) {                       // Confere se está entre os ciclos utilizados para o cálculo das integrais
          if (contador == 2) { 
            time2 = now;                                               // Confere se está no primeiro ciclo usado para cálculo, e armazena o momento que inicia se verdadeiro
            MIntERR[0] = 0;                                            // Zerando os indices para ordenar os ciclos
            MIntOUT[0] = 0;
            MToff[0] = 0;
            MTon[0] = 0;
            MTom[0] = 0;
            MAu[0] = 0;
            MAd[0] = 0;
          }
          else {
            time3 = now - time2;                                       // Cálcula a diferença entre o momento atual e a última vez que foram calculadas as integrais
            IntERR += erro * time3;                                    // Calculo da integral do erro
            IntOUT += (OUT - mOUT) * time3;                            // Calculo da integral de OUT
            MIntERR[((int)(MIntERR[0]++)%4)+1] = IntERR;               // Grava na matriz o valor da integral do erro
            MIntOUT[((int)(MIntOUT[0]++)%4)+1] = IntOUT;               // Grava na matriz o valor da integral de OUT 
            time2 += time3;                                            // Grava o momento final da integral que será o inicio da próxima
          }
          IntERR = 0;                                                  // Zera a integral do erro
          IntOUT = 0;                                                  // Zera a integral de OUT
        } 
        Ton0 = now;                                                    // Grava o momento que ocorre a transição de OFF pra ON
        MToff[((int)(MToff[0]++)%4)+1] = now - Toff0;                  // Grava na matriz o tempo OFF da última transição        
        MTom[((int)(MTom[0]++)%8)+1] = Tom - Toff0;                    // Grava na matriz o delay medido durante o semiciclo OFF  
        Ad = mVP + biashis;                                            // Reseta o valor de vale pro ponto de operação gravado      
        if (VP < Ad) {                                                 // Compara se o valor atual da entrada é menor que o de vale 
          Ad = VP;                                                     // Armazena o novo valor de vale 
          Tom = now;                                                   // Armazena o momento que ocorre o vale 
        }
        MAu[((int)(MAu[0]++)%4)+1] = Au - mVP;                         // Grava na matriz o valor do pico da última transição
        OUT = (mOUT + biasd + (d*Acao));                               // Seta a saída com o valor do ponto de operação mais a amplitude do relé   
      } else  if (VP < Ad) {                                           // Compara se o valor atual da entrada é menor que o de vale 
        Ad = VP;                                                       // Armazena o novo valor de vale
        Tom = now;                                                     // Armazena o momento que ocorre o vale 
      }
    }  
  }
  if ((2 <= contador) && (contador < 6)) {                           // Confere se o relé está entre a quarta e décima segunda transição, ou seja, do terceiro ao sexto ciclo.  
    time3 = now - time2;                                             // Cálcula a diferença entre o momento atual e a última vez que foram calculadas as integrais
    IntERR += erro * time3;                                          // Calculo da integral de VP
    IntOUT += (OUT - mOUT) * time3;                                  // Calculo da integral de VC
    time2 += time3;                                                  // Grava o momento final da integral que será o inicio da próxima
  }
  
  if (contador >= 6) {  
    OUT = mOUT;                                                      // Seta a saída pro valor do ponto de operação gravado
    sinalop = mOUT;                                                  // Seta o sinal de operação pro valor do ponto de operação gravado
    setpoint = mVP;                                                  // Seta o setpoint pro valor do ponto de operação gravado
    Malha = 0;                                                       // Seleciona a malha Aberta
    parametros = true;                                               // Aciona a flag de parâmetros informando que é para enviar os dados do relé pro C# 
    regrele = true;                                                  // Aciona a flag de registro informando que a lógica relé já foi acionada anteriormente
  } 
  return;
}

// FUNÇÃO PARA CÁLCULO DA ESTABILIDADE DO SISTEMA
void estabilidade() {
  if (now > time1 + 500) {                                           // Confere se já passaram 500 milisegundos desde o último cálculo
    time1 = now;                                                     // time1 recebe o valor do momento atual em milisegundos
    VPmatriz[((int)(VPmatriz[0]++)%20)+1] = VP;                      // Adiciona o valor atual do input na matriz
    OUTmatriz[((int)(OUTmatriz[0]++)%20)+1] = OUT;                   // Adiciona o valor atual do output na matriz
  }
  if (((maxi(&VPmatriz[1],20) - mini(&VPmatriz[1],20)) < VPvar) &&   // Confere se os valores estão dentro das faixas de estabilidade escolhidas
      ((maxi(&OUTmatriz[1],20) - mini(&OUTmatriz[1],20)) < OUTvar) &&
      ((VPmin < mini(&VPmatriz[1],20)) && (maxi(&VPmatriz[1],20) < VPmax)) &&                          
      ((OUTmin < mini(&OUTmatriz[1],20)) && (maxi(&OUTmatriz[1],20) < OUTmax)))  
    estavel = true;                                                  // Aciona a flag de estabilidade informando que o sistema está estavel
  else 
    estavel = false;                                                 // Desaciona a flag de estabilidade informando que o sistema está instavel
}

void setup() {
  Serial.begin(115200);                                              // Inicia a comunicação serial com taxa de transferência de 115200
  dac.begin(0x62);                                                   // Inicia o conversor analógico digital
  VP = 4095.0*((double)analogRead(0)) / 1023.0;                      // Realiza a primeira leitura do input fazendo a conversão de 1023 da entrada do Arduino para 4095 usada no controle
  pid.SetOutputLimits(0, 4095);                                      // Seta os limites de output da biblioteca PID
  pid.SetMode(MANUAL);                                               // Seleciona o modo manual pro PID
  pid.SetSampleTime(200);                                            // Seta em 200ms a taxa de amostragem pro PID automático
  pidsimSetSampleTime(200);                                          // Seta em 200ms a nova taxa de amostragem pro PID simples
  setpoint = 0;                                                      // Zera o setpoint
  sinalop = 0;                                                       // Zera o sinal de operação
  for (char a = 0; a < 21; a++){                                     // Zera a matriz usada para cálculo da estabilidade
    VPmatriz[a] = 0;
    OUTmatriz[a] = 0;
  }
}

void loop() {  
  if (Serial.available() > 0) {                                      // Confere se existe algum dado na porta serial para leitura
    if (checkTime == 0) {                                            // Confere se é a primeira vez que entra na lógica desde a última leitura
      checkTime = now;                                               // Armazena o momento atual em milisegundos 
      sizeReceived = Serial.available();                             // Armazena o tamanho do dado na porta serial
    }
    else if ((now - checkTime) > 3) {                                // Confere se já passaram 3 milisegundos desde a primeira vez que entrou na lógica após a última leitura
      if (sizeReceived != Serial.available())                        // Confere se o tamanho do dado mudou (aumentou recebendo mais dados)
        sizeReceived = Serial.available();                           // Armazena o tamanho do dado na porta serial
      else {                                                         // Se o tamanho do dado não mudou 
        read();                                                      // Chama a função read() que irá ler o dado   
        checkTime = 0;                                               // Zera a variável checktime para informar o término da leitura
      }
    }  
  }  
  estabilidade();                                                    // Chama a função estabilidade()    
  if ((now > time0 + 100) && timerenvio) {                           // Confere se a flag de envio está acionada e se passaram ao menos 100 milisegundos desde o último envio de dados
    time0 = now; // 
    dataPrint(1);                                                    // Chama a função dataPrint() enviando o comando (1)
    lastSent = 1;                                                    // Armazena o último comando enviado (1)
    timerenvio = false;                                              // Desaciona a flag de envio
  }  
  pid.Compute();                                                     // Chama a função pid.Compute()
  if ((Malha == 1)||(Malha == 2)) iniciarele();                      // Se a malha relé estiver acionada chama a função iniciarele()
  else if (Malha == 4) pidsimCompute();                              // Senão se a malha PID simples estiver acionada chama a função pidsimCompute()
  else if (Malha == 0) OUT = sinalop;                                // Senão se o sistema estiver em malha aberta a saída recebe o sinal de operação
  if (OUT > 4095) OUT = 4095;                                        // Limita a sáida máxima
  if (OUT < 0) OUT = 0;                                              // Limita a sáida mínima
  VP = 4095.0*((double)analogRead(0)) / 1023.0;                      // Realiza a leitura do input fazendo a conversão de 1023 da entrada do Arduino para 4095 usada no controle   
  dac.setVoltage(OUT, false);                                        // Seta a saída do sistema 0-4095 -> 0-5V 
  now = millis();                                                    // Armazena o momento atual                                                                     
}


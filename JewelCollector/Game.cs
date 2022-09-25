using System;
using static System.Console;
using Figgle;

/// <summary>
/// Classe que controla o fluxo do jogo, a leitura das entradas e impressão de informações na tela
/// </summary>
public class Game{ 
    /// <summary>
    /// Mapa que o jogador vai navegar
    /// </summary>
   Map mapa; 
   /// <summary>
   /// Instancia do jogador
   /// </summary>
   /// <returns></returns>
   Robot player = new Robot();
   private bool fimDeFase;
   private bool outOfEnergy;
   
    /// <summary>
    /// Construtor que incia um novo jogo e chama o metodo <c>start</c>
    /// </summary>
    public Game() {
        this.player = new Robot();
        this.mapa =  new Map();
        player.LowEnergyEvent += semEnergia;
        mapa.outOfJewelsEvent += finalDaFase;  
        this.fimDeFase=false;
        this.outOfEnergy=false;
        start();
    }
   
    /// <summary>
    /// Controla as fases do jogo. Iniciando um novo mapa toda vez que o player passa de fase.
    /// </summary>
    public void start(){     
        int i=1;
        while(i<=30 && outOfEnergy==false){        
            mapa.levelDesign(i);
            this.fimDeFase=false;   
            mapa.Add(player);
            RunGameLoop();
            i++;
            player.resetRobot();
        }
    }

    /// <summary>
    /// Determina que o jogador coletou todas as joias e finaliza a fase para o inicio da próxima
    /// </summary>
    /// <param name="sender">Classe que lançou o Evento <c>outOfJewelsEvent</c></param>
    /// <param name="e"><c>outOfJewel</c></param>
    private void finalDaFase(object? sender, EventArgs e)
    {
        this.fimDeFase=true;
    }
    /// <summary>
    /// Determina que o jogador está sem energia disponivel. Finaliza o jogo e chama a <c>TelaGameOver</c>
    /// </summary>
    /// <param name="sender">Classe que lançou o Evento <c>LowEnergyEvent</c></param>
    /// <param name="e"><c>LowEnergyEvent</c></param>
    private void semEnergia(object? sender, EventArgs e)
    {
        this.outOfEnergy=true;
        JewelCollector.TelaGameOver();
    }

    /// <summary>
    /// Chamas os metodos de desenho do Mapa e da bolsa do player
    /// </summary>
    private void Draw(){
        Clear();
        mapa.ImprimirMapa();
        player.ImprimirBag();        
    }
    /// <summary>
    /// Le as entradas do teclado e chama os devidos metodos para mover o player ou interagir com um elemento do mapa
    /// </summary>
    private void ComandoNoTeclado(){
        ConsoleKey key;

        do{
            ConsoleKeyInfo keyInfo = ReadKey();
            key = keyInfo.Key;
        }while(KeyAvailable);

        switch(key){
            case ConsoleKey.W: 
                if (mapa.EAndavel(player.X-1, player.Y)) player.Mover(Robot.DirecaoMovimento.Cima, mapa);                    
                break;
            case ConsoleKey.S:
                if (mapa.EAndavel(player.X+1, player.Y)) player.Mover(Robot.DirecaoMovimento.Baixo, mapa);
                break;
            case ConsoleKey.A:
                if (mapa.EAndavel(player.X, player.Y-1)) player.Mover(Robot.DirecaoMovimento.Esquerda, mapa);
                break;
            case ConsoleKey.D:
                if (mapa.EAndavel(player.X, player.Y+1)) player.Mover(Robot.DirecaoMovimento.Direita, mapa);
                break;
            case ConsoleKey.G:
                if (mapa.TemJoiaPerto(player.X, player.Y)) player.PegarJoia(mapa);
                else if (mapa.TemArvorePerto(player.X, player.Y)) player.RechargeWArvore(mapa);
                break;
        }

    }
    /// <summary>
    /// Mantém o loop do jogo: Apresentar as informações na tela, ler a entrada do usuario e checar pelo fim do jogo ou da fase
    /// </summary>
    private void RunGameLoop(){
        while (true){
            Draw();
            ComandoNoTeclado();
            if (fimDeFase || outOfEnergy) break; //CHECA SE O JOGO ACABOU
            System.Threading.Thread.Sleep(30);
        }
  }
}
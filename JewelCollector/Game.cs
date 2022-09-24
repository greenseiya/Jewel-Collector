using System;
using static System.Console;
using Figgle;

public class Game{ 
   Map mapa; 
   Robot player = new Robot();
   private bool fimDeFase;
   private bool outOfEnergy;
   

    public Game() {
        this.player = new Robot();
        this.mapa =  new Map();
        player.LowEnergyEvent += semEnergia;
        mapa.outOfJewels += finalDaFase;  
        this.fimDeFase=false;
        this.outOfEnergy=false;
        start();
    }
   
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

    private void finalDaFase(object? sender, EventArgs e)
    {
        this.fimDeFase=true;
    }

    private void semEnergia(object? sender, EventArgs e)
    {
        this.outOfEnergy=true;
        JewelCollector.TelaGameOver();
    }

    private void Draw(){
        Clear();
        mapa.ImprimirMapa();
        player.ImprimirBag();        
    }
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

    private void RunGameLoop(){
        while (true){
            Draw();
            ComandoNoTeclado();
            if (fimDeFase || outOfEnergy) break; //CHECA SE O JOGO ACABOU
            System.Threading.Thread.Sleep(30);
        }
  }
}
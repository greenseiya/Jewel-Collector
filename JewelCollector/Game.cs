using System;
using static System.Console;

public class Game{ 
   Map mapa; 
   Robot player;
   
    public void start(int lvl){
        mapa = new Map(lvl+9);
        player = new Robot();
        levelDesign(1);
        mapa.Add(player);
        RunGameLoop();
        Clear();
        WriteLine("FIM DO JOGO!");
  }

    private void levelDesign(int lvl){
        Random rand = new Random();
        int itens = lvl+mapa.Size;

        for (int i=0; i<itens; i++){
            int x = rand.Next(0,2);
            if (x==0){//JOIAS
                x=rand.Next(0,3);
                if(x==0) mapa.Add(new Jewel(rand.Next(0, mapa.Size), rand.Next(0, mapa.Size), Jewel.Type.Red));
                if(x==1)mapa.Add(new Jewel(rand.Next(0, mapa.Size), rand.Next(0, mapa.Size), Jewel.Type.Green));
                if(x==2)mapa.Add(new Jewel(rand.Next(0, mapa.Size), rand.Next(0, mapa.Size), Jewel.Type.Blue));
            }
            else {
                x = rand.Next(0,2);
                if(x==0)mapa.Add(new Obstacle(rand.Next(0, mapa.Size), rand.Next(0, mapa.Size), Obstacle.Type.Tree));
                if(x==1)mapa.Add(new Obstacle(rand.Next(0, mapa.Size), rand.Next(0, mapa.Size), Obstacle.Type.Water));
            }
        }

        
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
                break;
        }

    }
   
    private void RunGameLoop(){

    while (true){
        Draw();
        ComandoNoTeclado();
        if (!mapa.AindaTemjoia()) break; //CHECA SE O JOGO ACABOU
        System.Threading.Thread.Sleep(30);
    }
  }
}
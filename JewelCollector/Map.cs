/*
Map.cs - A classe Map deverá armazenar as informações do mapa 2D e implementar métodos para adição e remoção de joias e obstáculos. Além de um método para imprimir o mapa na tela. A impressão do mapa deverá seguir a seguinte regra: Robo será impresso como ME; Joias Red, como JR; Joias Green, como JG; Joias Blue, como JB; Obstáculos do tipo Tree, como $$; Obstáculos do tipo Water, como ##; Espaços vazios, como --.
*/

using System;
using static System.Console;

public class Map {
    private ObjetoNaTela[,] mapa;
    private int size;
    private int numJoias;
    public int Size { get => size; }
    public event EventHandler? outOfJewels;


    public Map(){
        this.mapa = new ObjetoNaTela[0,1];        
    }

    public void Add(ObjetoNaTela elementoNovo){
        Remove(mapa[elementoNovo.X, elementoNovo.Y]);
        mapa[elementoNovo.X, elementoNovo.Y] = elementoNovo;
        if(elementoNovo is Jewel) this.numJoias++;
    }

    public void Remove(ObjetoNaTela elementoPRemover){
         if (elementoPRemover is Jewel) this.numJoias--;
         if (this.numJoias<=0) OnoutOfJewels();            
         mapa[elementoPRemover.X, elementoPRemover.Y] = new CaminhoLivre(elementoPRemover.X, elementoPRemover.Y);
    }

    public bool EAndavel(int x, int y){
       if(x>=0 && y>=0 && x<size && y<size)  return (mapa[x, y].Walkable);
       return false;
    }

    private bool EJoia(int x, int y){
        if(x>=0 && y>=0 && x<size && y<size) return (mapa[x, y] is Jewel);
        return false;
    }
    public ObjetoNaTela? PegaJoia(int x, int y){
       for (int i=-1; i<2; i++){
            for (int j=-1; j<2; j++){
                if(EJoia(x+i, y+j)) return (mapa[x+i,y+j]);
            }
        }
        return null;
    }

    public bool TemJoiaPerto(int x, int y){
       for (int i=-1; i<2; i++){
            for (int j=-1; j<2; j++){
                if(EJoia(x+i, y+j)) return true;
            }
        }
        return false;
    }

    public bool AindaTemjoia (){
        if (this.numJoias>0) return true;
        return false;
    }

    public void levelDesign(int lvl){
        int size = lvl+9;
        this.size=size;
        this.mapa = new ObjetoNaTela[size,size];
        
        for (int i=0; i<this.Size; i++){
            for (int j=0; j<this.Size; j++){
                this.mapa[i,j] = new CaminhoLivre(i,j);
            }
        }

        Random rand = new Random();

        Title = "JewelCollector - LVL "+lvl;
        //VALORES ALEATORIOS PARA A DISTRIBUIÇÃO DE ITENS NO MAPA BUSCANDO GERAR MAPAS MAIS JUSTOS
        for (int i=0; i<(0.03*(this.Size)*(this.Size));i++) Add(new Jewel(rand.Next(2, this.Size), rand.Next(0, this.Size), Jewel.Type.Red));
        for (int i=0; i<(0.05*(this.Size)*(this.Size));i++) Add(new Jewel(rand.Next(2, this.Size), rand.Next(0, this.Size), Jewel.Type.Green));
        for (int i=0; i<(0.07*(this.Size)*(this.Size));i++) Add(new Jewel(rand.Next(2, this.Size), rand.Next(0, this.Size), Jewel.Type.Blue));
        for (int i=0; i<(0.1*(this.Size)*(this.Size));i++) Add(new Obstacle(rand.Next(2, this.Size), rand.Next(0, this.Size), Obstacle.Type.Tree));
        for (int i=0; i<(0.1*(this.Size)*(this.Size));i++) Add(new Obstacle(rand.Next(2, this.Size), rand.Next(0, this.Size), Obstacle.Type.Water)); 
        if(lvl>=2) Add(new Obstacle(rand.Next(2, this.Size), rand.Next(2, this.Size), Obstacle.Type.Radioativo));
    }

    private bool EArvore(int x, int y){
        if(x>=0 && y>=0 && x<size && y<size && mapa[x, y] is Obstacle) {
           Obstacle var = (Obstacle) mapa[x, y];           
            return ( var.Tipo == Obstacle.Type.Tree);
        }
        return false;
    }

    public bool TemArvorePerto(int x, int y){
       for (int i=-1; i<2; i++){
            for (int j=-1; j<2; j++){
                if(EArvore(x+i, y+j)) return true;
            }
        }
        return false;
    }

    public int QtdArvorePerto(int x, int y){
       int output=0;
       for (int i=-1; i<2; i++){
            for (int j=-1; j<2; j++){
                if(EArvore(x+i, y+j)) output++;
            }
        }
        return output;
    }

    private bool ERadiativo(int x, int y){
        if(x>=0 && y>=0 && x<size && y<size && mapa[x, y] is Obstacle) {
           Obstacle var = (Obstacle) mapa[x, y];           
            return ( var.Tipo == Obstacle.Type.Radioativo);
        }
        return false;
    }
    public bool TemRadiacaoPerto(int x, int y){
       for (int i=-1; i<2; i++){
            for (int j=-1; j<2; j++){
                if(ERadiativo(x+i, y+j)) return true;
            }
        }
        return false;
    }

    public ObjetoNaTela pegaElemento(int x, int y){
        return mapa[x,y];
    }
    
    public virtual void OnoutOfJewels(){
        if (outOfJewels != null) outOfJewels.Invoke(this, EventArgs.Empty);
    } 
    public void ImprimirMapa(){
        for (int i=0; i<this.Size; i++){
            for (int j=0; j<this.Size; j++){
                ObjetoNaTela elemento = mapa[i,j];
                ForegroundColor = elemento.Cor;
                Write(elemento.ToString());
            }
            WriteLine();
        }
        ResetColor();
    }
}
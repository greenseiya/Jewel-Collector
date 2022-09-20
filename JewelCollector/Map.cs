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

    public Map(int size){
        mapa = new ObjetoNaTela[size, size];
        this.size = size;
        for (int i=0; i<this.Size; i++){
            for (int j=0; j<this.Size; j++){
                mapa[i,j]= new CaminhoLivre(i, j);
            }
        }
    }

    public void Add(ObjetoNaTela elementoNovo){
        mapa[elementoNovo.X, elementoNovo.Y] = elementoNovo;
        if(elementoNovo is Jewel) this.numJoias++;
    }

    public void Remove(ObjetoNaTela elementoPRemover){
         mapa[elementoPRemover.X, elementoPRemover.Y] = new CaminhoLivre(elementoPRemover.X, elementoPRemover.Y);
         if (elementoPRemover is Jewel) this.numJoias--;
    }

    public bool EAndavel(int x, int y){
       if(x>=0 && y>=0 && x<size && y<size)  return (mapa[x, y] is CaminhoLivre);
       return false;
    }

    private bool EJoia(int x, int y){
        if(x>=0 && y>=0 && x<size && y<size) return (mapa[x, y] is Jewel);
        return false;
    }
    public ObjetoNaTela PegaJoia(int x, int y){
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
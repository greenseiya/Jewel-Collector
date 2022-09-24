/*
Obstacle.cs - A classe Obstacle deverá armazenar as informações do obstáculo, que será a posição (x, y) e o tipo. Cada obstáculo deverá possuir um tipo, que poderá ser Water (##) ou Tree ($$).
*/


public class Obstacle : ObjetoNaTela{
    private Type tipo;

    public Type Tipo { get => tipo; private set => tipo = value; }

    public enum Type {Water, Tree, Radioativo};

    public Obstacle(int x, int y, Obstacle.Type tipo){
        this.X=x;
        this.Y=y;
        this.Tipo=tipo;

        if (tipo == Obstacle.Type.Water){ 
            this.Symbol = " ## ";
            this.Cor= ConsoleColor.Cyan;
            this.Walkable = false;
        }
        else if (tipo == Obstacle.Type.Tree) {
            this.Symbol = " $$ ";
            this.Cor = ConsoleColor.DarkMagenta;
            this.Walkable = false;
        } else{
            this.Symbol = " !! ";
            this.Cor= ConsoleColor.DarkYellow; 
            this.Walkable = true;
        }
    }
}
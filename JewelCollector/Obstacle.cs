/*
Obstacle.cs - A classe Obstacle deverá armazenar as informações do obstáculo, que será a posição (x, y) e o tipo. Cada obstáculo deverá possuir um tipo, que poderá ser Water (##) ou Tree ($$).
*/

public class Obstacle : ObjetoNaTela{
    private Type tipo;
    public enum Type {Water, Tree};

    public Obstacle(int x, int y, Obstacle.Type tipo){
        this.X=x;
        this.Y=y;
        this.tipo=tipo;

        if (tipo == Obstacle.Type.Water){ 
            this.Symbol = " ## ";
            this.Cor= ConsoleColor.DarkBlue;
        }
        else {
            this.Symbol = " $$ ";
            this.Cor = ConsoleColor.DarkGreen;
        }
        
    }
}
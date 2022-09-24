/*
Jewel.cs - A classe Jewel deverá armazenar as informações da joia, como a posição (x, y) no mapa e o tipo, que poderá ser Red, no valor de 100 pontos; Green, no valor de 50 pontos; e Blue, no valor de 10 pontos.
*/

public class Jewel : ObjetoNaTela{
    private int value;
    private Type tipo;
    public enum Type {Red, Green, Blue};

    public int Value { get => value; set => this.value = value; }
    public Type Tipo { get => tipo; }

    public Jewel(int x, int y, Jewel.Type tipo ){
        this.X=x;
        this.Y=y;
        this.tipo = tipo;
        this.Walkable = false;

        if (tipo == Jewel.Type.Red){
            this.Symbol = " JR ";
            this.Value=100;
            this.Cor=ConsoleColor.Red;
        } else if (tipo == Jewel.Type.Green){
            this.Symbol = " JG ";
            this.Value=50;
            this.Cor=ConsoleColor.Green;
        } else {
            this.Symbol = " JB ";
            this.Value=10; 
            this.Cor=ConsoleColor.Blue;
        }
    }
}

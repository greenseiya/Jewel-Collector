/*
Jewel.cs - A classe Jewel deverá armazenar as informações da joia, como a posição (x, y) no mapa e o tipo, que poderá ser Red, no valor de 100 pontos; Green, no valor de 50 pontos; e Blue, no valor de 10 pontos.
*/

public class Jewel : ObjetoNaTela{
    private int value;
    private Jewel.Collor cor;
    public int Value { get => value; set => this.value = value; }
    public enum Collor {Red, Green, Blue};

    public Jewel(int x, int y, Jewel.Collor cor ){
        this.X=x;
        this.Y=y;

        if (cor == Jewel.Collor.Red){
            this.Symbol = " JR ";
            this.Value=100;
        } else if (cor == Jewel.Collor.Green){
            this.Symbol = " JG ";
            this.Value=50;
        } else {
            this.Symbol = " JB ";
            this.Value=50; 
        }
    }
}

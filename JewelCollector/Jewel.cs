/*
Jewel.cs - A classe Jewel deverá armazenar as informações da joia, como a posição (x, y) no mapa e o tipo, que poderá ser Red, no valor de 100 pontos; Green, no valor de 50 pontos; e Blue, no valor de 10 pontos.
*/
/// <summary>
/// Classe <c>Jewel</c> herda da classe ObjetoNaTela e representa os três tipos diferentes de jóia presentes no jogo
/// </summary>
public class Jewel : ObjetoNaTela{
    private int value;
    private Type tipo;
    /// <summary>
    /// Tipos de jóia disponiveis no jogo: 
    /// /// <list>
    /// <item> Red (JR)</item>
    /// <item> Green (JG)</item>
    /// <item> Blue (JB)</item>
    /// </list>
    /// </summary>
    public enum Type {Red, Green, Blue};

    /// <summary>
    /// Quatidade de pontos ganhos pelo jogador ao recolher a jóia:
    /// <list>
    /// <item> Red: 100 pontos</item>
    /// <item> Green:50 pontos</item>
    /// <item> Blue: 10 pontos</item>
    /// </list>
    /// </summary>
    /// <value></value>
    public int Value { get => value; }

    /// <summary>
    /// 
    /// </summary>
    /// <value>Tipo da jóia instanciada</value>
    public Type Tipo { get => tipo; }

    /// <summary>
    /// Construtor que define os paremetros herdados, o valor da joia e seu tipo
    /// </summary>
    /// <param name="x">Posição no eixo X para o elemento sendo criado</param>
    /// <param name="y">Posição no eixo Y para o elemento sendo criado</param>
    /// <param name="tipo">Tipo da joia instanciada</param>
    public Jewel(int x, int y, Jewel.Type tipo ){
        this.X=x;
        this.Y=y;
        this.tipo = tipo;
        this.Walkable = false;

        if (tipo == Jewel.Type.Red){
            this.Symbol = " JR ";
            this.value=100;
            this.Cor=ConsoleColor.Red;
        } else if (tipo == Jewel.Type.Green){
            this.Symbol = " JG ";
            this.value=50;
            this.Cor=ConsoleColor.Green;
        } else {
            this.Symbol = " JB ";
            this.value=10; 
            this.Cor=ConsoleColor.Blue;
        }
    }
}

/*
Obstacle.cs - A classe Obstacle deverá armazenar as informações do obstáculo, que será a posição (x, y) e o tipo. Cada obstáculo deverá possuir um tipo, que poderá ser Water (##) ou Tree ($$).
*/
/// <summary>
/// Classe <c>Obstacle</c> herda de <c>ObjetoNaTela</c> e representa os três tipos de obstaculos presentes no jogo.
/// </summary>

public class Obstacle : ObjetoNaTela{
    private Type tipo;
    /// <summary>
    /// Tipo do obstaculo instanciado
    /// </summary>
    /// <value></value>
    public Type Tipo { get => tipo; private set => tipo = value; }

    /// <summary>
    /// Tipos de obstaculos disponiveis no jogo:
    /// /// <list>
    /// <item> Water: (##)</item>
    /// <item> Tree: ($$)</item>
    /// <item> Radioativo: (!!)</item>
    /// </list>
    /// </summary>
    public enum Type {Water, Tree, Radioativo};
    /// <summary>
    /// Construtor que define os paremetros herdados e o tipo do obstaculo
    /// </summary>
    /// <param name="x">Posição no eixo X para o elemento sendo criado</param>
    /// <param name="y">Posição no eixo Y para o elemento sendo criado</param>
    /// <param name="tipo">Tipo do obstaculo instanciada</param>
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
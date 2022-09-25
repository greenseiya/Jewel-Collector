/// <summary>
/// Class <c> ObjetoNaTela</c> é um classe abstrata que armazena as informações comuns a todos os elementos que serão impressos na tela
/// </summary>
public abstract class ObjetoNaTela{
    private int x;
    private int y;
    private string symbol="";
    private ConsoleColor cor;
    private bool walkable;

    /// <summary>
    /// 
    /// </summary>
    /// <value>Representa a posição do elemento no eixo X</value>
    public int X { get => x; set => x = value; }
    /// <summary>
    /// 
    /// </summary>
    /// <value>Representa a posição do elementos no eixo Y</value>
    public int Y { get => y; set => y = value; }
    /// <summary>
    /// 
    /// </summary>
    /// <value>Simbolo que representa o elemtento e será exibido na tela</value>
    public string Symbol { set => symbol = value; }
    /// <summary>
    /// 
    /// </summary>
    /// <value>Cor usada para imprimir o simbolo do elemento na tela</value>
    public ConsoleColor Cor { get => cor; set => cor = value; }
    /// <summary>
    /// 
    /// </summary>
    /// <value>Determina se um elemento é transponivél (TRUE) ou é sólido (FALSE)</value>
    public bool Walkable { get => walkable; set => walkable = value; }
    /// <summary>
    /// 
    /// </summary>
    /// <returns>Retorna uma string com o simbolo do elemteno</returns>
    public override string ToString() => this.symbol;
}
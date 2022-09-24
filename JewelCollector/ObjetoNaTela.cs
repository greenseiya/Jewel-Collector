public abstract class ObjetoNaTela{
    private int x;    
    private int y;
    private string symbol="";
    private ConsoleColor cor;
    private bool walkable;

    public int X { get => x; set => x = value; }
    public int Y { get => y; set => y = value; }
    public string Symbol { set => symbol = value; }
    public ConsoleColor Cor { get => cor; set => cor = value; }
    public bool Walkable { get => walkable; set => walkable = value; }

    public override string ToString() => this.symbol;
}
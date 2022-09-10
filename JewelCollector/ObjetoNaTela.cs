public abstract class ObjetoNaTela{
    private int x;    
    private int y;
    private string symbol="";
    
    public string Symbol { set => symbol = value; }
    public int X { get => x; set => x = value; }
    public int Y { get => y; set => y = value; }

    public override string ToString()
    {
        return this.symbol;
    }

}
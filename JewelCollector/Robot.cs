/*
Robot.cs - A classe Robot deverá ser responsável por armazenar as informações do robô, que será a posição (x, y) e uma sacola (bag), em que o robô colocará as joias coletadas no mapa. Além disso, a classe Robot deverá implementar os métodos para que o robô possa interagir com o mapa, isto é, deslocar-se nas quatro direções e coletar as joias. Além disso, implemente um método para imprimir na tela o total de joias armazenadas na sacola e o valor total.
*/

public class Robot : ObjetoNaTela{
    private int bagNumItens;
    private int bagValue;
    private int energy;

    public event EventHandler? LowEnergyEvent;


    public int Energy { get => energy; private set => energy = value; }

    public enum DirecaoMovimento {Esquerda, Direita, Cima, Baixo};
    public Robot(){
        this.X=0;
        this.Y=0;
        this.Symbol=" ME ";
        this.Energy=5;
        this.bagValue=0;
        this.bagNumItens=0;
        this.Cor = ConsoleColor.Yellow;
         this.Walkable = false;
    }

    public void resetRobot(){
        this.X=0;
        this.Y=0;
        this.Energy=5;
        this.bagValue=0;
        this.bagNumItens=0;
    }
    public void Mover (Robot.DirecaoMovimento direcao, Map mapa){
        ObjetoNaTela elementoAnterior=new CaminhoLivre(this.X, this.Y);
        if(this.Energy>0){
            this.Energy--;
            mapa.Remove(this);
            if (direcao is Robot.DirecaoMovimento.Cima) this.X--;
            else if (direcao is Robot.DirecaoMovimento.Baixo) this.X++;
            else if (direcao is Robot.DirecaoMovimento.Direita) this.Y++;
            else if (direcao is Robot.DirecaoMovimento.Esquerda) this.Y--;
            elementoAnterior = (ObjetoNaTela)mapa.pegaElemento(this.X, this.Y); 
            mapa.Add(this);     
            if (mapa.TemRadiacaoPerto(this.X, this.Y)) this.Energy -=10;
            if (elementoAnterior is Obstacle){
                Obstacle anterior = (Obstacle) elementoAnterior;
                if(anterior.Tipo == Obstacle.Type.Radioativo) this.Energy -=30;
            }
        } else OnLowEnergyEvent();
    }

    public void PegarJoia(Map mapa){
        Jewel joia = (Jewel)mapa.PegaJoia(this.X, this.Y)!;
        if(joia.Tipo is Jewel.Type.Blue) this.Energy+=5;
        this.bagValue += joia.Value;
        this.bagNumItens++;
        mapa.Remove(joia);
    }

    public void RechargeWArvore(Map mapa){
        this.Energy += 3* mapa.QtdArvorePerto(this.X, this.Y);
    }

    protected virtual void OnLowEnergyEvent(){
        if (LowEnergyEvent != null) LowEnergyEvent.Invoke(this, EventArgs.Empty);
    } 

    public void ImprimirBag (){
        Console.WriteLine();
        Console.WriteLine("Bag Total Itens: " + this.bagNumItens + " | Bag value: " + this.bagValue+ " | Energy: " + this.Energy);
    }
}
/*
Robot.cs - A classe Robot deverá ser responsável por armazenar as informações do robô, que será a posição (x, y) e uma sacola (bag), em que o robô colocará as joias coletadas no mapa. Além disso, a classe Robot deverá implementar os métodos para que o robô possa interagir com o mapa, isto é, deslocar-se nas quatro direções e coletar as joias. Além disso, implemente um método para imprimir na tela o total de joias armazenadas na sacola e o valor total.
*/

public class Robot : ObjetoNaTela{
    private int bagNumItens;
    private int bagValue;
    private int energy;

    public enum DirecaoMovimento {Esquerda, Direita, Cima, Baixo};
    public Robot(){
        this.X=0;
        this.Y=0;
        this.Symbol=" ME ";
        this.energy=5;
        this.bagValue=0;
        this.bagNumItens=0;
        this.Cor = ConsoleColor.Yellow;
    }

    public void Mover (Robot.DirecaoMovimento direcao, Map mapa){
        mapa.Remove(this);
        if (direcao is Robot.DirecaoMovimento.Cima) this.X--;
        else if (direcao is Robot.DirecaoMovimento.Baixo) this.X++;
        else if (direcao is Robot.DirecaoMovimento.Direita) this.Y++;
        else if (direcao is Robot.DirecaoMovimento.Esquerda) this.Y--;    
        mapa.Add(this);    
    }

    public void PegarJoia(Map mapa){
        Jewel joia = (Jewel)mapa.PegaJoia(this.X, this.Y);
        this.bagValue += joia.Value;
        this.bagNumItens++;
        mapa.Remove(joia);
    }

    public void ImprimirBag (){
        Console.WriteLine();
        Console.WriteLine("Bag Total Itens: " + this.bagNumItens + " | Bag value: " + this.bagValue+ " | Energy: " + this.energy);
    }
}
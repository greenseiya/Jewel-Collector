/*
Robot.cs - A classe Robot deverá ser responsável por armazenar as informações do robô, que será a posição (x, y) e uma sacola (bag), em que o robô colocará as joias coletadas no mapa. Além disso, a classe Robot deverá implementar os métodos para que o robô possa interagir com o mapa, isto é, deslocar-se nas quatro direções e coletar as joias. Além disso, implemente um método para imprimir na tela o total de joias armazenadas na sacola e o valor total.
*/

/// <summary>
/// Classe <c>Robot</c> herda de <c>ObjetoNaTela</c> e representa o jogador gerenciando a quatidade de pontos coletados, quantidade de jóias e a energia disponivel.
/// </summary>
public class Robot : ObjetoNaTela{
    private int bagNumItens;
    private int bagValue;
    private int energy;

    /// <summary>
    /// Evento disparado quando o jogador fica sem energia para se movimentar e tenta se mover.
    /// </summary>
    public event EventHandler? LowEnergyEvent;
    /// <summary>
    /// Armaze a quantidade de energia que o jogar tem disponivel para se locomover.
    /// </summary>
    /// <value></value>
    public int Energy { get => energy; private set => energy = value; }

    /// <summary>
    /// Direções de movimento possiveis para o jogador:
    /// <list>
    /// <item>Cima</item>
    /// <item>Baixo</item>
    /// <item>Esquerda</item>
    /// <item>Direita</item>
    /// </list>
    /// </summary>
    public enum DirecaoMovimento {Esquerda, Direita, Cima, Baixo};

    /// <summary>
    /// Contrutor determina os valores iniciais padrões para o jogador:
    /// <list>
    /// <item>Posição x,y = (0,0)</item>
    /// <item>Energia = 5</item>
    /// </list>
    /// </summary>
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
    /// <summary>
    /// Volta os valores de:
    /// <list>
    /// <item>Posição x,y</item>
    /// <item>Energia</item>
    /// <item>Total de pontos (Value)</item>
    /// <item>Numero de jóias coletadas</item>
    /// </list>
    /// Para o valor padrão quando o jogador avança uma fase
    /// </summary>
    public void resetRobot(){
        this.X=0;
        this.Y=0;
        this.Energy=5;
        this.bagValue=0;
        this.bagNumItens=0;
    }
    /// <summary>
    /// Movimenta o jogador em uma determinada posição.
    /// Durante o movimento a função checa se a quatidade de energia é suficiente. Caso contrario o evento <c>LowEnergyEvent</c> é lançado.
    /// </summary>
    /// <param name="direcao">Direção de movimento do jogador</param>
    /// <param name="mapa">Mapa pelo qual o jogador se movimenta</param>
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

    /// <summary>
    /// Coleta uma joia adjascente ao player no mapa, adiciona seu valor ao total de pontos, soma na quantidade de itens da bolsa e remove do mapa a jóia.
    /// Caso a joia coletada seja Azul aumenta a energia disponivel para o player em 5.
    /// </summary>
    /// <param name="mapa">Mapa pelo qual o jogador se movimenta</param>
    public void PegarJoia(Map mapa){
        Jewel joia = (Jewel)mapa.PegaJoia(this.X, this.Y)!;
        if(joia.Tipo is Jewel.Type.Blue) this.Energy+=5;
        this.bagValue += joia.Value;
        this.bagNumItens++;
        mapa.Remove(joia);
    }

    /// <summary>
    /// Quanto adjascente a uma ou mais arvores recarrega a energia disponivel para o player em 3 unidade por arvore adjascente.
    /// </summary>
    /// <param name="mapa"></param>
    public void RechargeWArvore(Map mapa){
        this.Energy += 3* mapa.QtdArvorePerto(this.X, this.Y);
    }

    /// <summary>
    /// Evento lançado quando o jogador fica sem energia.
    /// </summary>
    protected virtual void OnLowEnergyEvent(){
        if (LowEnergyEvent != null) LowEnergyEvent.Invoke(this, EventArgs.Empty);
    } 

    /// <summary>
    /// Imprime na tela a situação atual do inventário do player: Quantidade total de itens, Quantidade total de pontos e energia disponivel.
    /// </summary>
    public void ImprimirBag (){
        Console.WriteLine();
        Console.WriteLine("Bag Total Itens: " + this.bagNumItens + " | Bag value: " + this.bagValue+ " | Energy: " + this.Energy);
    }
}
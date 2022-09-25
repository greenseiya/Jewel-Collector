/*
Map.cs - A classe Map deverá armazenar as informações do mapa 2D e implementar métodos para adição e remoção de joias e obstáculos. Além de um método para imprimir o mapa na tela. A impressão do mapa deverá seguir a seguinte regra: Robo será impresso como ME; Joias Red, como JR; Joias Green, como JG; Joias Blue, como JB; Obstáculos do tipo Tree, como $$; Obstáculos do tipo Water, como ##; Espaços vazios, como --.
*/

/// <summary>
/// Classe <c>Map</c> representa o mundo que o jogador navega.
/// </summary>
using System;
using static System.Console;

public class Map {
    private ObjetoNaTela[,] mapa;
    private int size;
    private int numJoias;
    /// <summary>
    /// Tamanho do mapa que vaira conforme o level do jogo
    /// </summary>
    /// <value></value>
    public int Size { get => size; }
    /// <summary>
    /// Evento que é lançado quando o jogador coletou todas as joias da fase e pode avançar para a próxima
    /// </summary>
    public event EventHandler? outOfJewelsEvent;

    /// <summary>
    /// Construtor que inicia um matriz de <c>ObjetosNaTela</c> com um tamanho reduzido
    /// </summary>
    public Map(){
        this.mapa = new ObjetoNaTela[0,1];        
    }

    /// <summary>
    /// Adiciona um elemento a matriz mapa usando como indice as posiçoes (x,y) do elemento.
    /// </summary>
    /// <param name="elementoNovo">Elemento a ser adicionado a matriz</param>
    public void Add(ObjetoNaTela elementoNovo){
        Remove(mapa[elementoNovo.X, elementoNovo.Y]);
        mapa[elementoNovo.X, elementoNovo.Y] = elementoNovo;
        if(elementoNovo is Jewel) this.numJoias++;
    }

    /// <summary>
    /// Remove um elemento da matriz. Após a remoção no lugar do mesmo é adicionado um <c>CaminhoLivre</c>
    /// </summary>
    /// <param name="elementoPRemover">Elemento a ser removido da matriz</param>
    public void Remove(ObjetoNaTela elementoPRemover){
         if (elementoPRemover is Jewel) this.numJoias--;
         if (this.numJoias<=0) OnoutOfJewels();            
         mapa[elementoPRemover.X, elementoPRemover.Y] = new CaminhoLivre(elementoPRemover.X, elementoPRemover.Y);
    }

    /// <summary>
    /// Determina se um elemento da matriz é transponivel ou não
    /// </summary>
    /// <param name="x">Indice x do elemento na matriz</param>
    /// <param name="y">Indice y do elemento na matriz</param>
    /// <returns>TRUE caso o elemento seja transponivel</returns>
    /// <returns>FALSE caso seja sólido</returns>
    public bool EAndavel(int x, int y){
        try{
            return (mapa[x, y].Walkable);
        } catch(IndexOutOfRangeException){
            return false;
        }
    }

    /// <summary>
    /// Determina se um elemento da matriz é uma jóia
    /// </summary>
    /// <param name="x">Indice x do elemento na matriz</param>
    /// <param name="y">Indice y do elemento na matriz</param>
    /// <returns>TRUE caso seja uma jóia</returns>
    /// <returns>FALSE caso contrario</returns>
    private bool EJoia(int x, int y){
        if(x>=0 && y>=0 && x<size && y<size) return (mapa[x, y] is Jewel);
        return false;
    }

    /// <summary>
    /// Retorna um elemento adjacente a (x,y) que seja uma jóia.
    /// </summary>
    /// <param name="x">Indice x do elemento na matriz</param>
    /// <param name="y">Indice y do elemento na matriz</param>
    /// <returns><c>ObjetoNaTela</c> caso exista uma jóia adjascente a (x,y)</returns>
    /// <returns>NULL caso contrario</returns>
    public ObjetoNaTela? PegaJoia(int x, int y){
       for (int i=-1; i<2; i++){
            for (int j=-1; j<2; j++){
                if(EJoia(x+i, y+j)) return (mapa[x+i,y+j]);
            }
        }
        return null;
    }

    /// <summary>
    /// Determina se um existe uma jóia adjacente a (x,y).
    /// </summary>
    /// <param name="x">Indice x do elemento na matriz</param>
    /// <param name="y">Indice y do elemento na matriz</param>
    /// <returns>TRUE caso tenha ao menos uma jóia adjacente a (x,y)</returns>
    /// <returns>FALSE caso contrario</returns>
    public bool TemJoiaPerto(int x, int y){
       for (int i=-1; i<2; i++){
            for (int j=-1; j<2; j++){
                if(EJoia(x+i, y+j)) return true;
            }
        }
        return false;
    }

    /// <summary>
    /// Cria um mapa para o jogador navegar baseado no level do jogo.
    /// </summary>
    /// <param name="lvl">Fase atual do jogo (1-30)</param>
    public void levelDesign(int lvl){
        int size = lvl+9;
        this.size=size;
        this.mapa = new ObjetoNaTela[size,size];
        
        for (int i=0; i<this.Size; i++){
            for (int j=0; j<this.Size; j++){
                this.mapa[i,j] = new CaminhoLivre(i,j);
            }
        }

        Random rand = new Random();

        Title = "JewelCollector - LVL "+lvl;
        //VALORES ALEATORIOS PARA A DISTRIBUIÇÃO DE ITENS NO MAPA BUSCANDO GERAR MAPAS MAIS JUSTOS
        for (int i=0; i<(0.03*(this.Size)*(this.Size));i++) Add(new Jewel(rand.Next(2, this.Size), rand.Next(0, this.Size), Jewel.Type.Red));
        for (int i=0; i<(0.05*(this.Size)*(this.Size));i++) Add(new Jewel(rand.Next(2, this.Size), rand.Next(0, this.Size), Jewel.Type.Green));
        for (int i=0; i<(0.05*(this.Size)*(this.Size));i++) Add(new Jewel(rand.Next(2, this.Size), rand.Next(0, this.Size), Jewel.Type.Blue));
        for (int i=0; i<(0.1*(this.Size)*(this.Size));i++) Add(new Obstacle(rand.Next(2, this.Size), rand.Next(0, this.Size), Obstacle.Type.Tree));
        for (int i=0; i<(0.1*(this.Size)*(this.Size));i++) Add(new Obstacle(rand.Next(2, this.Size), rand.Next(0, this.Size), Obstacle.Type.Water)); 
        if(lvl>=2) Add(new Obstacle(rand.Next(2, this.Size), rand.Next(2, this.Size), Obstacle.Type.Radioativo));
    }

    private bool EArvore(int x, int y){
        if(x>=0 && y>=0 && x<size && y<size && mapa[x, y] is Obstacle) {
           Obstacle var = (Obstacle) mapa[x, y];           
            return ( var.Tipo == Obstacle.Type.Tree);
        }
        return false;
    }

    /// <summary>
    /// Determina se um existe uma arvore adjacente a (x,y).
    /// </summary>
    /// <param name="x">Indice x do elemento na matriz</param>
    /// <param name="y">Indice y do elemento na matriz</param>
    /// <returns>TRUE caso tenha ao menos uma arvore adjacente a (x,y)</returns>
    /// <returns>FALSE caso contrario</returns>
    public bool TemArvorePerto(int x, int y){
       for (int i=-1; i<2; i++){
            for (int j=-1; j<2; j++){
                if(EArvore(x+i, y+j)) return true;
            }
        }
        return false;
    }

    /// <summary>
    /// Determina a quantidade de jóias adjacentes a (x,y).
    /// </summary>
    /// <param name="x">Indice x do elemento na matriz</param>
    /// <param name="y">Indice y do elemento na matriz</param>
    /// <returns>Quantidade de arvores adjacentes a (x,y)</returns>
    public int QtdArvorePerto(int x, int y){
       int output=0;
       for (int i=-1; i<2; i++){
            for (int j=-1; j<2; j++){
                if(EArvore(x+i, y+j)) output++;
            }
        }
        return output;
    }

    private bool ERadiativo(int x, int y){
        if(x>=0 && y>=0 && x<size && y<size && mapa[x, y] is Obstacle) {
           Obstacle var = (Obstacle) mapa[x, y];           
            return ( var.Tipo == Obstacle.Type.Radioativo);
        }
        return false;
    }

    /// <summary>
    /// Determina se um existe um elemento radioativo adjacente a (x,y).
    /// </summary>
    /// <param name="x">Indice x do elemento na matriz</param>
    /// <param name="y">Indice y do elemento na matriz</param>
    /// <returns>TRUE caso tenha ao menos um elemento radioativo adjacente a (x,y)</returns>
    /// <returns>FALSE caso contrario</returns>
    public bool TemRadiacaoPerto(int x, int y){
       for (int i=-1; i<2; i++){
            for (int j=-1; j<2; j++){
                if(ERadiativo(x+i, y+j)) return true;
            }
        }
        return false;
    }

    /// <summary>
    /// Retorna um elemento do mapa na posição (x,y)
    /// </summary>
    /// <param name="x">Indice x do elemento na matriz</param>
    /// <param name="y">Indice y do elemento na matriz</param>
    /// <returns><c>ObjetoNaTela</c> na posição (x,y).</returns>
    public ObjetoNaTela pegaElemento(int x, int y){
        return mapa[x,y];
    }
    
    /// <summary>
    /// Lança o evento <c>outOfJewelsEvent</c> quando o jogador coleta todas as jóias do mapa
    /// </summary>
    public virtual void OnoutOfJewels(){
        if (outOfJewelsEvent != null) outOfJewelsEvent.Invoke(this, EventArgs.Empty);
    } 

    /// <summary>
    /// Limpa a tela do console e imprime o mapa.
    /// </summary>
    public void ImprimirMapa(){
        for (int i=0; i<this.Size; i++){
            for (int j=0; j<this.Size; j++){
                ObjetoNaTela elemento = mapa[i,j];
                ForegroundColor = elemento.Cor;
                Write(elemento.ToString());
            }
            WriteLine();
        }
        ResetColor();
    }
}
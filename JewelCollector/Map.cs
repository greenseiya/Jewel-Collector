/*
Map.cs - A classe Map deverá armazenar as informações do mapa 2D e implementar métodos para adição e remoção de joias e obstáculos. Além de um método para imprimir o mapa na tela. A impressão do mapa deverá seguir a seguinte regra: Robo será impresso como ME; Joias Red, como JR; Joias Green, como JG; Joias Blue, como JB; Obstáculos do tipo Tree, como $$; Obstáculos do tipo Water, como ##; Espaços vazios, como --.
*/

public class Map {
    private ObjetoNaTela[,] mapa;

    public ObjetoNaTela[,] Mapa { get => mapa; set => mapa = value; }

    public Map( ObjetoNaTela[,] novo){
        this.Mapa = novo;
    }

    public void Add(ObjetoNaTela elementoNovo){
        Mapa[elementoNovo.X,elementoNovo.Y] = elementoNovo;
    }

    public void Remove(int x, int y){
        Mapa[x,y]=null;
    }

    public void imprimirMapa(){
        //Console.Clear();
        for (int i=0; i<10; i++){
            for (int j=0; j<10; j++){
                if (Mapa[i,j] is ObjetoNaTela) Console.Write(Mapa[i,j].ToString());
                else Console.Write(" -- ");
            }
            Console.Write("\n");
        }
    }




}
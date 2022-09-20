/*
CaminhoLivre.cs - A classe CaminhoLivre marca locais que o robo pode andar
*/

public class CaminhoLivre : ObjetoNaTela{

    public CaminhoLivre (int x, int y){
        this.X = x;
        this.Y = y;
        this.Symbol = " -- ";
        this.Cor = ConsoleColor.White;
    }
}
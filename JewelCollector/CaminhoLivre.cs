/*
CaminhoLivre.cs - A classe CaminhoLivre marca locais que o robo pode andar
*/
/// <summary>
/// Classe <c>CaminhoLivre</c> herda de <c>ObjetoNaTela</c> e representa um espaço vazio onde podemos navegar pelo mapa
/// </summary>
public class CaminhoLivre : ObjetoNaTela{
    /// <summary>
    /// Construtor define os parametros herdados de ObjetoNaTela
    /// </summary>
    /// <param name="x">Posição no eixo X para o elemento sendo criado</param>
    /// <param name="y">Posição no eixo Y para o elemento sendo criado</param>
    public CaminhoLivre (int x, int y){
        this.X = x;
        this.Y = y;
        this.Symbol = " -- ";
        this.Cor = ConsoleColor.White;
         this.Walkable = true;
    }
}
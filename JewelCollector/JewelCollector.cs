using static System.Console;
using Figgle;
/// <summary>
/// Classe <c>JewelCollector</c> inicia o jogo e exibe algumas informações para o jogador
/// </summary>
public class JewelCollector {
  /// <summary>
  /// Main configura a tela do console, chama as funções que exibem informações na tela e inicia o jogo
  /// </summary>
  public static void Main() {
    Title = "JewelCollector";
    CursorVisible = false;
    TeladeInicio();
    Game currentGame = new Game();
    TeladeCreditos();
  }

  /// <summary>
  /// Exibe informações para o jogador com o titulo do jogo e como jogar.
  /// </summary>
  public static void TeladeInicio(){
        Console.Clear();
        WriteLine(FiggleFonts.Slant.Render("  Jewel Collector"));

        WriteLine("      Use as teclas   W    para se locomover");
        WriteLine("                    A S D    ");
        WriteLine("\n      Quando estiver próximo a uma jóia pressione G para coletar.");
        WriteLine("      Colete jóias azuis (JB) e arvores ($$) para recuperar energia");

        WriteLine("\n      Precione qualquer tecla para iniciar...");
        ReadKey(true);
  }
  /// <summary>
  /// Tela final do jogo com os créditos ao desenvolverdor
  /// </summary>
  public static void TeladeCreditos(){
        Clear();
        WriteLine(FiggleFonts.Slant.Render("  Jewel Collector"));

        WriteLine("      Obrigado por jogar!");
        Write("      Desenvolvido por: ");
        ForegroundColor = ConsoleColor.DarkBlue;
        WriteLine("Evandro Luis Araujo de Sousa");
        ResetColor();
        Write("      Durante o Curso de Extensão: ");
        ForegroundColor = ConsoleColor.DarkBlue;
        WriteLine("Tecnologias Microsoft - 2022");
        ResetColor();
        WriteLine("\n      Precione qualquer tecla para sair...");
        ReadKey(true);
  }
  /// <summary>
  /// Tela de GameOver exibida quando <c>Robot</c> fica sem energia para se movimentar
  /// </summary>
  public static void TelaGameOver(){
    Clear();
        WriteLine(FiggleFonts.Slant.Render("  Game Over!"));
        WriteLine("      Você ficou sem energia!");
        WriteLine("\n      Precione qualquer tecla para continuar...");
        ReadKey(true);
  }
}
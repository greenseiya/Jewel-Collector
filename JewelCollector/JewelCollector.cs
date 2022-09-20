using static System.Console;

public class JewelCollector {
  public static void Main() {
    Title = "JewelCollector";
    CursorVisible = false;
    Game currentGame = new Game();
    currentGame.start(1);
  }
}
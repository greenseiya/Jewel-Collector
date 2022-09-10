public class JewelCollector {

  public static void Main() {
    Map mapa = new Map( new ObjetoNaTela[10,10]);
    Robot robo = new Robot();
    
    bool running = true;
    do {
      mapa.Add(robo);
      mapa.imprimirMapa();
      robo.ImprimirBag();
      Console.WriteLine("Enter the command: ");
      string command = Console.ReadLine();

      if (command.Equals("quit")) {
          running = false;
      } else if (command.Equals("w")) {
        robo.Mover(Robot.DirecaoMovimento.Cima, mapa);
      }
    }while(running);




  }
}
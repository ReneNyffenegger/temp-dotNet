class W {

  public static void Main(string[] argv) {

     for (int i=0; i<argv.Length; i++) {
        System.Console.WriteLine("argv[{0}] = {1}", i, argv[i]);
     }
  }
}

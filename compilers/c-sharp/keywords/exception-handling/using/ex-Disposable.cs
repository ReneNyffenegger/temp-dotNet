using System;

class pretendUnamanaged : IDisposable {

   public void doSomething(int i) {
      Console.WriteLine("Doing {i}");
   }

   void IDisposable.Dispose() {
      Console.WriteLine("Disposing of object");
   }

}

class Prg {

   static void Main() {

      using pretendUnamanaged u = new pretendUnamanaged();
      u.doSomething(1);
      u.doSomething(2);
      u.doSomething(3);
      throw new Exception("should not happen");
      u.doSomething(4);
      u.doSomething(5);

   }

}

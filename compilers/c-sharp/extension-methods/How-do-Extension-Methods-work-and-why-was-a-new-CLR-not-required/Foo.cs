using System;

namespace Foo {

    class Program {

        static void Main(string[] args) {
            Console.WriteLine(2.DoubleThenAdd(3));   // NOTE here: IntHelper35::DoubleThenAdd invoked with 2.
            Console.WriteLine(IntHelper20.DoubleThenAdd(2, 3));
            Console.ReadLine();
        }
    }
 
    public static class IntHelper20 {

        public static int DoubleThenAdd(int myInt, int x) {
            Console.WriteLine("IntHelper20::DoubleThenAdd");
            return myInt + (2 * x);
        }
    }

 
    public static class IntHelper35 {
        public static int DoubleThenAdd(this int myInt, int x) {
            Console.WriteLine("IntHelper35::DoubleThenAdd");
            return myInt + (2 * x);
        }
    }

}

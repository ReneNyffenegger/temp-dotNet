//
//     https://stackoverflow.com/questions/295104/what-is-the-difference-between-a-field-and-a-property
//
public class C {

   private string field;

   public string prop {
      get { return field;         }
      set {        field = value; }
   }

// AutoProperty generates private field for us
   public int auto_prop{get; set;}

// public int XYZ {
//   int  get(     ) { return XYZ;}
//   void set(int v) { XYZ = v   ;}
// }
}

public class M {

   public static void Main() {

      C c1 = new C();
//    C c2 = new C();

      c1.auto_prop = 42;
      c1.prop      ="Hello World";

      System.Console.WriteLine($"{c1.auto_prop} - {c1.prop}");

   }
}

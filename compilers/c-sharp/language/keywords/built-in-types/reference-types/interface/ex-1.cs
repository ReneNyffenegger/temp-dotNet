using System;

interface Itq84 {
// Any class that implements Itq84 must define a method
// that matches the following signature.
    void SampleMethod();

    string text { get; set; }

 //
 // error CS8701: Target runtime doesn't support default interface implementation.
 //
 // void M() {
 //    Console.WriteLine("M");
 // }

}

class TQ84 : Itq84 {

    private string text_;

 // Explicit interface member implementation: 
 // void                  SampleMethod()   // error CS0737: 'TQ84' does not implement interface member 'Itq84.SampleMethod()'
    void Itq84.SampleMethod()  
    {
         Console.WriteLine($"TQ84.SampleMethod was called, text = {text}");
    }

    public string text {
       set { text_ = value; }
       get { return text_ ; }
    }

}

class Prg {

    static void Main() {
        // Declare an interface instance.
        Itq84 obj = new TQ84();

        obj.text = "foo, bar baz";

        // Call the member.
        obj.SampleMethod();
    }
}

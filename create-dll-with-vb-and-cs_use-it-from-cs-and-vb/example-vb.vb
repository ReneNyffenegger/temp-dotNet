imports System

class Example

  public shared sub Main()
     dim dbl as double
     dbl = 0.0 - Double.Epsilon
     Console.WriteLine(NumericLib.NearZero(dbl))
  
     dim s as string
       
     s = "war and peace"
     Console.WriteLine(s.ToTitleCase())
  end sub

end class

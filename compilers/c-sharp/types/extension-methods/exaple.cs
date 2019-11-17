//
// Without using System.Linq:
//    error CS1061: 'int[]' does not contain a definition for 'OrderBy' and no accessible extension method 'OrderBy' accepting a first argument of type 'int[]' could be found
//
using System.Linq;

class ExtensionMethods2  {
    
    static void Main() {            
        int[] ints = { 10, 45, 15, 39, 21, 26 };
        var result = ints.OrderBy(g => g);

        foreach (var i in result) {
            System.Console.Write(i + " ");
        }           
    }        
}

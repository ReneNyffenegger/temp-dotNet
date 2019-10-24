//
// Any lambda expression can be converted to a delegate type
//
// https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/lambda-operator
//
using System;
public class L { static void Main() {

     Func<int, int> square = x => x * x;
     Console.WriteLine(square(5));

     Func<int, char, int, double> evalOp = (val1, op, val2) => {
        if (op == '+') return (double)val1 + val2;
        if (op == '*') return (double)val1 * val2;
        if (op == '-') return (double)val1 - val2;
        if (op == '/') return (double)val1 / val2;
        return 0;
     }; 

     Console.WriteLine(evalOp(5, '/', 3));

     Console.WriteLine(evalOp.GetType());


//   string[] words = { "bot", "apple", "apricot" };
//   int minimalLength = words
//     .Where(w => w.StartsWith("a"))
//     .Min(w => w.Length);
//   Console.WriteLine(minimalLength);   // output: 5
//   
//   int[] numbers = { 1, 4, 7, 10 };
//   int product = numbers.Aggregate(1, (interim, next) => interim * next);
//   Console.WriteLine(product);   // output: 280

}}


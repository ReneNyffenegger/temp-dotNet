using System;
using System.Linq;
using System.Collections.Generic;

class Prg {

   static void q() {

      string[] words = { "apple", "strawberry", "grape", "peach", "banana", "gogagola" };
      IEnumerable<string> res = from word in words
                      where word[0] == 'g'
                      select word;

      Console.WriteLine(String.Join(" - ", res));
   }

// ----------------------------------------
//
//     https://docs.microsoft.com/en-us/dotnet/csharp/tutorials/working-with-linq

   static IEnumerable<string> Suits() {
     yield return "clubs"; yield return "diamonds"; yield return "hearts"; yield return "spades";
   }

   static IEnumerable<string> Ranks() {
     yield return "two"; yield return "three"; yield return "four"; yield return "five"; yield return "six"; yield return "seven"; yield return "eight"; yield return "nine"; yield return "ten"; yield return "jack"; yield return "queen"; yield return "king"; yield return "ace";
   }  

   static void p() {
      var startingDeck = from s in Suits()
                       from r in Ranks()
                       select new { Suit = s, Rank = r };

      Console.WriteLine(String.Join(" - ", startingDeck));
   }
   static void p_alternative() {

     var startingDeck =
       Suits().SelectMany(
         suit => Ranks().Select(
              rank => new { Suit = suit, Rank = rank }
         )
       );

      Console.WriteLine(String.Join(" - ", startingDeck));
   }


   static void Main () {

      q();
//    p();
      p_alternative();

   }

}

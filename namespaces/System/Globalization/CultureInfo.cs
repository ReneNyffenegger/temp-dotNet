//
//    https://docs.microsoft.com/en-us/dotnet/api/system.globalization.cultureinfo?redirectedfrom=MSDN&view=netframework-4.8
//

using System;
using System.Collections;
using System.Globalization;

public class SamplesCultureInfo {

   public static void Main() {

   // Creates and initializes the CultureInfo which uses the international sort.
      CultureInfo esES = new CultureInfo("es-ES", false);

   // Creates and initializes the CultureInfo which uses the traditional sort.
      CultureInfo x040A = new CultureInfo(0x040A, false);

   // Displays the properties of each culture.
      Console.WriteLine("{0,-31}{1,-47}{2,-25}", "PROPERTY"                      , "INTERNATIONAL"                        , "TRADITIONAL");
      Console.WriteLine("{0,-31}{1,-47}{2,-25}", "CompareInfo"                   , esES.CompareInfo                   , x040A.CompareInfo);
      Console.WriteLine("{0,-31}{1,-47}{2,-25}", "DisplayName"                   , esES.DisplayName                   , x040A.DisplayName);
      Console.WriteLine("{0,-31}{1,-47}{2,-25}", "EnglishName"                   , esES.EnglishName                   , x040A.EnglishName);
      Console.WriteLine("{0,-31}{1,-47}{2,-25}", "IsNeutralCulture"              , esES.IsNeutralCulture              , x040A.IsNeutralCulture);
      Console.WriteLine("{0,-31}{1,-47}{2,-25}", "IsReadOnly"                    , esES.IsReadOnly                    , x040A.IsReadOnly);
      Console.WriteLine("{0,-31}{1,-47}{2,-25}", "LCID"                          , esES.LCID                          , x040A.LCID);
      Console.WriteLine("{0,-31}{1,-47}{2,-25}", "Name"                          , esES.Name                          , x040A.Name);
      Console.WriteLine("{0,-31}{1,-47}{2,-25}", "NativeName"                    , esES.NativeName                    , x040A.NativeName);
      Console.WriteLine("{0,-31}{1,-47}{2,-25}", "Parent"                        , esES.Parent                        , x040A.Parent);
      Console.WriteLine("{0,-31}{1,-47}{2,-25}", "TextInfo"                      , esES.TextInfo                      , x040A.TextInfo);
      Console.WriteLine("{0,-31}{1,-47}{2,-25}", "ThreeLetterISOLanguageName"    , esES.ThreeLetterISOLanguageName    , x040A.ThreeLetterISOLanguageName);
      Console.WriteLine("{0,-31}{1,-47}{2,-25}", "ThreeLetterWindowsLanguageName", esES.ThreeLetterWindowsLanguageName, x040A.ThreeLetterWindowsLanguageName);
      Console.WriteLine("{0,-31}{1,-47}{2,-25}", "TwoLetterISOLanguageName"      , esES.TwoLetterISOLanguageName      , x040A.TwoLetterISOLanguageName);
      Console.WriteLine();

   // Compare two strings using esES.
      Console.WriteLine("Comparing \"llegar\" and \"lugar\"");
      Console.WriteLine("   With esES.CompareInfo.Compare: {0}" , esES.CompareInfo.Compare("llegar", "lugar"));
      Console.WriteLine("   With x040A.CompareInfo.Compare: {0}", x040A.CompareInfo.Compare("llegar", "lugar"));

   }

}

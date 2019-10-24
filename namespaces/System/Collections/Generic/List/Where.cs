using System;
using System.Collections.Generic;

public class L { static void Main() {

// https://stackoverflow.com/a/5653749/180275
// 
  List<string> items = new List<string>();
  
  var results = items.Where(i => 
       {
                bool result;

                if (i == "THIS")
                    result = true;
                else if (i == "THAT")
                    result = true;
                else
                    result = false;

                return result;
            }
        );

}}

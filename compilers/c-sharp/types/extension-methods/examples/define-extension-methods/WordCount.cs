using System;

namespace ExtensionMethods {

    public static class MyExtensions {

        public static int WordCount(
            this String str // Note the keyword this
        ) {

            return str.Split(new char[] { ' ', '.', '?' }, StringSplitOptions.RemoveEmptyEntries).Length;
        }
    }   

}


using System;
using System.Data;
using System.Windows.Forms;

public class C : Form {
   private DataGridView grid;

  [System.STAThreadAttribute]
   public static void Main() {

      C c = new C();

//    c.MakeDataTables();

      c.FillGrid(new object[,] {
             { 1 , "one"   , "eins" },
             { 2 , "two"   , "zwei" },
             { 3 , "three" , "drei" },
             { 4 , "four"  , "vier" },
             { 5 , "five"  , "fünf" },
      });

      Application.Run(c);

   }

   private C() {
       grid = new DataGridView();

       grid.Top    =   20;
       grid.Left   =   20;
       grid.Width  = 1000; // TODO: This width does not seem to have any influence.
       grid.Height =  600;
       this.Controls.Add(grid);

   }

   private void FillGrid(object[,] values) {

      int nofRows  = values.GetLength(0);
      int nofCols  = values.GetLength(1);

      for (int col = 0; col < nofCols; col++) {
         grid.Columns.Add(
           "col_" + col.ToString(), // Column name
           "col " + col.ToString()  // Column text
        );
      }

      for (int row = 0; row < nofRows; row++) {

          object[] row_values = new object[nofCols];

          for (int col = 0; col < nofCols; col++)
             row_values[col] = values[row, col];

          grid.Rows.Add(row_values);
//        grid.Rows.Add(values[row,]);
    }


   }


}

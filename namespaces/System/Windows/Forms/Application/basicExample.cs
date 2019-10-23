//
//   https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.application?view=netframework-4.8
//
public class tq84App : System.Windows.Forms.Form {


    int exitCounter = 1;

   [System.STAThreadAttribute]
    public static void Main() {
        // Start the application.
        System.Windows.Forms.Application.Run(new tq84App());
    }
 
    private System.Windows.Forms.Button   button1;
    private System.Windows.Forms.ListBox lb;

    public tq84App() {

        lb       = new System.Windows.Forms.ListBox();
        button1  = new System.Windows.Forms.Button ();

        button1.Left   =  200;
        button1.Text   = "Exit";
        button1.Click += new System.EventHandler(button1_Click);

        this.Controls.Add(button1);
        this.Controls.Add(lb);

        lb.Items.Add("First line");
        lb.Items.Add("Second line");
        lb.Items.Add("Third line");
    }

    private void button1_Click(object sender, System.EventArgs e) {


        // Check to see whether the user wants to exit the application.
        // If not, add a number to the list box.

        if (System.Windows.Forms.MessageBox.Show("Exit application?", "", System.Windows.Forms.MessageBoxButtons.YesNo)==System.Windows.Forms.DialogResult.Yes) {
            System.Windows.Forms.Application.Exit();
        }

        lb.Items.Add("Not exited: " + exitCounter);
        exitCounter ++;

    }
}

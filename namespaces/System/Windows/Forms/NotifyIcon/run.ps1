#
#   https://www.systanddeploy.com/2020/09/build-powershell-systray-tool-with.html
#

$Systray_Tool_Icon = New-Object System.Windows.Forms.NotifyIcon
$Systray_Tool_Icon.Text = "A propos de mon ordinateur"

# Systray icon
$Systray_Tool_Icon.Icon    = "$pwd\help2.ico"
$Systray_Tool_Icon.Visible = $true

#
# Hide the PowerShell window when the systray tool:
#
$windowcode = '[DllImport("user32.dll")] public static extern bool ShowWindowAsync(IntPtr hWnd, int nCmdShow);'
$asyncwindow = Add-Type -MemberDefinition $windowcode -name Win32ShowWindowAsync -namespace Win32Functions -PassThru
$null = $asyncwindow::ShowWindowAsync((Get-Process -PID $pid).MainWindowHandle, 0)

#
#  Force a garbae collection (to manage RAM usage):
#
[System.GC]::Collect()

#
# Create an application context for it to all run within.
#
$appContext = New-Object System.Windows.Forms.ApplicationContext
[void][System.Windows.Forms.Application]::Run($appContext)


# Create object for the systray 
$contextmenu = New-Object System.Windows.Forms.ContextMenuStrip

$Menu_1 = $contextmenu.Items.Add("Menu 1");
$Menu_2 = $contextmenu.Items.Add("Menu 2");
$Menu_Restart = $contextmenu.Items.Add("Restart the tool");
$Menu_Exit = $contextmenu.Items.Add("Exit");


#Sub menus for Menu 1
$Menu1_SubMenu1 = New-Object System.Windows.Forms.ToolStripMenuItem
$Menu1_SubMenu1.Text = "Menu 1 - Sub menu 1"
$Menu_1.DropDownItems.Add($Menu1_SubMenu1)
 
$Menu1_SubMenu2 = New-Object System.Windows.Forms.ToolStripMenuItem
$Menu1_SubMenu2.Text = "Menu 1 - Sub menu 2"
$Menu_1.DropDownItems.Add($Menu1_SubMenu2)
 
#Sub menus for Menu 2
$Menu2_SubMenu1 = New-Object System.Windows.Forms.ToolStripMenuItem
$Menu2_SubMenu1.Text = "Menu 2 - Sub menu 1"
$Menu_2.DropDownItems.Add($Menu2_SubMenu1)
 
$Menu2_SubMenu2 = New-Object System.Windows.Forms.ToolStripMenuItem
$Menu2_SubMenu2.Text = "Menu 2 - Sub menu 2"
$Menu_2.DropDownItems.Add($Menu2_SubMenu2)

$Menu_1 = $contextmenu.Items.Add("Menu 1");
$Menu_1_Picture =[System.Drawing.Bitmap]::FromFile("exit.png")
$Menu_1.Image = $Menu_1_Picture
 
$Menu_2 = $contextmenu.Items.Add("Menu 2");
$Menu_2_Picture =[System.Drawing.Bitmap]::FromFile("exit.png")
$Menu_2.Image = $Menu_2_Picture
 
$Menu_Restart = $contextmenu.Items.Add("Restart the tool");
$Menu_Restart_Picture =[System.Drawing.Bitmap]::FromFile("exit.png")
$Menu_Restart.Image = $Menu_Restart_Picture
 
$Menu_Exit = $contextmenu.Items.Add("Exit");
$Menu_Exit_Picture =[System.Drawing.Bitmap]::FromFile("exit.png")
$Menu_Exit.Image = $Menu_Exit_Picture

$SubMenu1_Part1 = New-Object System.Windows.Forms.ToolStripMenuItem
$SubMenu1_Part1.Text = "Menu 1 - Sub menu 1"
$SubMenu1_Part1_Picture =[System.Drawing.Bitmap]::FromFile("exit.png")
$SubMenu1_Part1.Image = $SubMenu1_Part1_Picture
 
$SubMenu1_Part2 = New-Object System.Windows.Forms.ToolStripMenuItem
$SubMenu1_Part2.Text = "Menu 1 - Sub menu 2"
$SubMenu1_Part2_Picture =[System.Drawing.Bitmap]::FromFile("exit.png")
$SubMenu1_Part2.Image = $SubMenu1_Part2_Picture

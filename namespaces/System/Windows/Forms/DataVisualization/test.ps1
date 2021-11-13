Add-Type -AssemblyName System.Windows.Forms
Add-Type -AssemblyName System.Windows.Forms.DataVisualization


$Chart      = New-object System.Windows.Forms.DataVisualization.Charting.Chart
$ChartArea  = New-Object System.Windows.Forms.DataVisualization.Charting.ChartArea
$Series     = New-Object -TypeName System.Windows.Forms.DataVisualization.Charting.Series
$ChartTypes = [System.Windows.Forms.DataVisualization.Charting.SeriesChartType]

$Series.ChartType = $ChartTypes::Pie

$Chart.Series.Add($Series)
$Chart.ChartAreas.Add($ChartArea)



$Processes = Get-Process | Sort-Object WS -Descending | Select-Object -First 10

$Chart.Series['Series1'].Points.DataBindXY($Processes.Name, $Processes.WS)

$Chart.Width = 700
$Chart.Height = 400
$Chart.Left = 10
$Chart.Top = 10
$Chart.BackColor = [System.Drawing.Color]::White
$Chart.BorderColor = 'Black'
$Chart.BorderDashStyle = 'Solid'

$ChartTitle = New-Object System.Windows.Forms.DataVisualization.Charting.Title
$ChartTitle.Text = 'Top 5 Processes by Working Set Memory'
$Font = New-Object System.Drawing.Font @('Microsoft Sans Serif','12', [System.Drawing.FontStyle]::Bold)
$ChartTitle.Font =$Font
$Chart.Titles.Add($ChartTitle)

$Chart.Series['Series1']['PieLabelStyle'] = 'Disabled'

$Legend = New-Object System.Windows.Forms.DataVisualization.Charting.Legend
$Legend.IsEquallySpacedItems = $True
$Legend.BorderColor = 'Black'
$Chart.Legends.Add($Legend)
$chart.Series['Series1'].LegendText = "#VALX (#VALY)"

$Chart.Series['Series1']['PieLineColor'] = 'Black'
$Chart.Series['Series1']['PieLabelStyle'] = 'Outside'
$Chart.Series['Series1'].Label = "#VALX (#VALY)"

#region Windows Form to Display Chart
$AnchorAll = [System.Windows.Forms.AnchorStyles]::Bottom -bor [System.Windows.Forms.AnchorStyles]::Right -bor [System.Windows.Forms.AnchorStyles]::Top -bor [System.Windows.Forms.AnchorStyles]::Left
$Form = New-Object Windows.Forms.Form
$Form.Width = 740
$Form.Height = 490
$Form.controls.add($Chart)
$Chart.Anchor = $AnchorAll
 
# add a save button
$SaveButton = New-Object Windows.Forms.Button
$SaveButton.Text = "Save"
$SaveButton.Top = 420
$SaveButton.Left = 600
$SaveButton.Anchor = [System.Windows.Forms.AnchorStyles]::Bottom -bor [System.Windows.Forms.AnchorStyles]::Right
# [enum]::GetNames('System.Windows.Forms.DataVisualization.Charting.ChartImageFormat')
$SaveButton.add_click({
    $Result = Invoke-SaveDialog
    If ($Result) {
        $Chart.SaveImage($Result.FileName, $Result.Extension)
    }
})
 
$Form.controls.add($SaveButton)
$Form.Add_Shown({$Form.Activate()})
[void]$Form.ShowDialog()
#endregion Windows Form to Display Chart

#
# https://superuser.com/a/760632
#

$null = [System.Reflection.Assembly]::LoadWithPartialName("System.Drawing")
  $fontColl = new-object System.Drawing.Text.InstalledFontCollection
# $fontColl = new-object System.Drawing.Text.PrivateFontCollection

# $fontColl.GetType().FullName

# $fontColl | select *
# $fontColl.Families.GetType().FullName

foreach ($fontFamily in $fontColl.Families) {
   $fontFamily
}

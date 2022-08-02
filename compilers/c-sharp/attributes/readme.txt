Without the [assembly:AllowPartiallyTrustedCallers] attribute declaration (a
custom attribute of the System.Security.AllowPartiallyTrustedCallersAttribute
class) in the assembly configuration file, only fully trusted callers will be
able to use the assembly. This attribute makes the assembly callable from any
other partially or fully trusted assembly. 

The AllowPartiallyTrustedCallers attribute removes the implicit LinkDemand (the
permission check conducted on the caller) for the FullTrust permission set that
is otherwise automatically placed on each assembly. Following are just some of
the .NET Framework assemblies that have the AllowPartiallyTrustedCallers
attribute declared:
  - System.dll
  - mscorlib.dll
  - System.XML.dll
  - System.Web.Services.dll
  - System.Data.dll
  - System.Windows.Forms.dll
  - System.Drawing.dll

Also note that even with the AllowPartiallyTrustedCallers attribute enabled,
assemblies cannot be called by partially trusted code if one of the following
security attributes is declared in the code:
  [PermissionSet(SecurityAction.LinkDemand, Name="FullTrust")]
  [SecurityPermission(SecurityAction.LinkDemand, UnmanagedCode=true)]
  [PermissionSet(SecurityAction.InheritanceDemand, Name="FullTrust")]
  [FileIOPermissionAttribute(SecurityAction.RequestMinimum, Unrestricted=true)]

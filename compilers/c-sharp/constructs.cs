internal static T TypeTableGetMemberDelegate<T>(PSObject msjObj, string name) where T : PSMemberInfo
{
    TypeTable table = msjObj.GetTypeTable();
    return TypeTableGetMemberDelegate<T>(msjObj, table, name);
}

****


private static T AdapterGetMemberDelegate<T>(PSObject msjObj, string name) where T : PSMemberInfo {
 ...
    T adaptedMember = msjObj.AdaptedMembers[name] as T;
 ...
}

*****


public PSObject()
{
    CommonInitialization(PSCustomObject.SelfInstance);
}


public PSObject(int instanceMemberCapacity) : this()
{
    _instanceMembers = new PSMemberInfoInternalCollection<PSMemberInfo>(instanceMemberCapacity);
}


******

var objType = obj as Type ?? obj.GetType();


******


object obj = context?.GetVariableValue(SpecialVariables.OFSVarPath);


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


internal static PSMemberInfoInternalCollection<U> TransformMemberInfoCollection<T, U>(PSMemberInfoCollection<T> source) where T : PSMemberInfo where U : PSMemberInfo



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


**********



public object BaseObject
{
    get
    {
        object returnValue;
        PSObject mshObj = this;
        do
        {
            returnValue = mshObj._immediateBaseObject;
            mshObj = returnValue as PSObject;
        } while (mshObj != null);

        return returnValue;
    }
}


******


/// Gets the object we are directly wrapping.
///    If the ImmediateBaseObject is another PSObject,
///    that PSObject will be returned.
public object ImmediateBaseObject => _immediateBaseObject;



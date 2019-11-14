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


******

_typeNames = s_typeNamesResurrectionTable.GetValue(
                GetKeyForResurrectionTables(this),
                _ => new ConsolidatedString(_typeNames));


*******


private readonly object _lockObject = new object();

       ...
           
       
         lock (_lockObject)    {
             if (_instanceMembers == null)
             {
                 _instanceMembers =
                     s_instanceMembersResurrectionTable.GetValue(
                        GetKeyForResurrectionTables(this),
                        _ => new PSMemberInfoInternalCollection<PSMemberInfo>());
      
             }
         }
           

********

   Array initialization
     C# 4: section 7.6.10.4 "Array Creation Expressions".

      new int[3]                    ; Foo(new int[2])
      new int[3] { 10, 20, 30 }     ; Foo(new int[2] { 1, 2 })
      new int[] { 10, 20, 30 }      ; Foo(new int[] { 1, 2 })
      new[] { 10, 20, 30 }          ; Foo(new[] { 1, 2 })

      new int[,] {
         { 3, 7 },
         { 103, 107 },
         { 10003, 10007 },
      };

      // ---------------

      var contacts = new[]
      {
          new {
              Name = " Eugene Zabokritski",
              PhoneNumbers = new[] { "206-555-0108", "425-555-0001" }
          },
          new {
              Name = " Hanying Feng",
              PhoneNumbers = new[] { "650-555-0199" }
          }
      };

      // ---------------

          object[,] values = new object[,] {
             { 1 , "one"   , "eins" },
             { 2 , "two"   , "zwei" },
             { 3 , "three" , "drei" },
             { 4 , "four"  , "vier" },
             { 5 , "five"  , "fünf" }
          };

          int valuesHeight = values.GetLength(0);
          int valuesWidth  = values.GetLength(1);


      // ---------------

      public class DummyUser {
          public string email { get; set; }
          public string language { get; set; }
      }

      private DummyUser[] arrDummyUser = new DummyUser[] {
          new DummyUser{
             email = "abc.xyz@email.com",
             language = "English"
          },
          new DummyUser{
             email = "def@email.com",
             language = "Spanish"
          }
      };

      // ---------------
      
      var arr1 = Enumerable.Repeat(new object(), 10).ToArray(); // you get 10 references to the same object.

          // To create 10 distinct objects, you can use 

      var arr2 = Enumerable.Repeat(/* dummy: */ false, 10).Select(x => new object()).ToArray(); // or similar.

      // ---------------

      NewArrayExpression expr = Expression.NewArrayInit(
          typeof(int),
          new[] { Expression.Constant(2),
          Expression.Constant(3)
      });

      int[] array = Expression.Lambda<Func<int[]>>(expr).Compile()(); // compile and call callback



******* 


      int n = Convert.ToInt16(Console.ReadLine());

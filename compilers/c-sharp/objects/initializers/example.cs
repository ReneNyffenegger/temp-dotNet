class obj {

   public int    m_num;
   public string m_text;

   public obj() {} // requiref for new obj { … }
   public obj(string text) { m_text = text; }
   public obj(int num, string text) { m_num = num; m_text = text; }

}

class C {

  public static void Main() {
     obj o = new obj { m_text = "foo", m_num = 42 };

     System.Console.WriteLine(o.ToString());
     System.Console.WriteLine(o.m_num );
     System.Console.WriteLine(o.m_text);

     obj p = new obj("bar") { m_num = 43 };
     System.Console.WriteLine(p.m_num );
     System.Console.WriteLine(p.m_text);

     System.Collections.Generic.List<obj> l = new System.Collections.Generic.List<obj> { new obj(1, "one"), new obj(2, "two") };
     System.Console.WriteLine(l[0].m_num );
     System.Console.WriteLine(l[0].m_text);
  }

}

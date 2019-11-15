//
//    https://stackoverflow.com/a/18856933/180275
//
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace LINQTest {
    class Program {
        class Schedule {
            public int empid { get; set; }
            public int hours { get; set; }
            public DateTime date { get; set; }
            public DateTime weekending { get; set; }
        }

        static void Main(string[] args) {
            List<Schedule> Schedules = new List<Schedule>();

            var bla = from s in Schedules
                      group s by new { s.empid, s.weekending} into g
                      select new { g.Key.empid, g.Key.weekending, Sum = g.Sum(s=>s.hours)};
//                    select new { g.Key.empid, g.Key.weekending, g.Sum(s=>s.hours)};
        }
    }
}

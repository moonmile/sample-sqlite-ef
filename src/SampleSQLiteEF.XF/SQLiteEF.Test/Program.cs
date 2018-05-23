using System;
using System.Linq;

namespace SQLiteEF.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello SQLite World!");

            // redmine.sqlite3 をロードする
            var ent = new RedmineModel.RedmineEntities();
            foreach ( var it in ent.issues.ToList())
            {
                Console.WriteLine(string.Format("{0} : {1}", it.id, it.subject));
            }
        }
    }
}

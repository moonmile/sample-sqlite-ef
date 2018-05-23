using Microsoft.EntityFrameworkCore;
using RedmineModel;
using System;

namespace MySQL2SQLite
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("copy MySQL to SQLite");

            var mysql = new RedmineEntitiesMySql();
            var sqlite = new RedmineEntities();

            // projectsとisseusの中身を消す
            sqlite.Database.ExecuteSqlCommand("delete from projects");
            sqlite.Database.ExecuteSqlCommand("delete from issues");
            // データをコピーする
            sqlite.projects.AddRange(mysql.projects.ToListAsync().Result);
            sqlite.issues.AddRange(mysql.issues.ToListAsync().Result);
            sqlite.SaveChanges();
            Console.WriteLine("コピーしました");
        }
    }

    public partial class RedmineEntitiesMySql : DbContext
    {
        public RedmineEntitiesMySql()
        {

        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            // SSH フォワーディングしておく
            // ssh -L 19000:localhost:3306 pi@raspi3.local
            optionsBuilder.UseMySQL(@"server=localhost;user id=redmine;password=redmine;database=redmine;port=19000;sslmode=None");
        }

        public DbSet<projects> projects { get; set; }
        public DbSet<issues> issues { get; set; }
    }

}

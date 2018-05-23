using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RedmineModel
{
    public partial class RedmineEntities : DbContext
    {
        public RedmineEntities()
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            var fname = "redmine.sqlite3";
            var docs = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            var path = System.IO.Path.Combine(docs, fname);

            optionsBuilder.UseSqlite($"Data Source={path}");
        }

        public DbSet<projects> projects { get; set; }
        public DbSet<issues> issues { get; set; }
    }

    public class projects
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string homepage { get; set; }
        public int is_public { get; set; }
        public int? parent_id { get; set; }
        public DateTime? created_on { get; set; }
        public DateTime? updated_on { get; set; }
        public string identifier { get; set; }
        public int status { get; set; }
        public int? lft { get; set; }
        public int? rgt { get; set; }
        public int inherit_members { get; set; }
        public int? default_version_id { get; set; }
    }

    public class issues
    {
        public int id { get; set; }
        public int tracker_id { get; set; }
        public int project_id { get; set; }
        public string subject { get; set; }
        public string description { get; set; }
        public DateTime? due_date { get; set; }
        public int? category_id { get; set; }
        public int status_id { get; set; }
        public int? assigned_to_id { get; set; }
        public int priority_id { get; set; }
        public int? fixed_version_id { get; set; }
        public int author_id { get; set; }
        public int lock_version { get; set; }
        public DateTime? created_on { get; set; }
        public DateTime? updated_on { get; set; }
        public DateTime? start_date { get; set; }
        public int done_ratio { get; set; }
        public double? estimated_hours { get; set; }
        public int? parent_id { get; set; }
        public int? root_id { get; set; }
        public int? lft { get; set; }
        public int? rgt { get; set; }
        public int is_private { get; set; }
        public DateTime? closed_on { get; set; }
    }
}

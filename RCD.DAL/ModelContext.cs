using RCD.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCD.DAL
{
    public class ModelContext : DbContext
    {
        public ModelContext() : base("Dbconnection")
        {
        }

        public DbSet<File> Files { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<FileType> FileTypes { get; set; }
        public DbSet<Metadata> Metadata { get; set; }
        public DbSet<MetadataType> MetadataTypes { get; set; }
        public DbSet<Setting> Settings { get; set; }

   }
}

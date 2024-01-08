using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace TODO
{
    public class TodoContext : DbContext
    {
        public DbSet<DataItem> TodoItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder aOptions)
        {
            string aDbFileName = "todoitems.db";
            aOptions.UseSqlite($"Data Source={aDbFileName}");
        }
    }
}

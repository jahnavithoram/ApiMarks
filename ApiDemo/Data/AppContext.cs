using ApiDemo.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiDemo.Data
{
    public class AppContext : DbContext
    {
        public AppContext(DbContextOptions options) : base(options)
        {

        }
        
        public DbSet<StudentModel> StudentModel { get; set; }
        public DbSet<SubjectModel> SubjectModel { get; set; }
        public DbSet<MarksModel> MarksModel { get; set; }

    }
}

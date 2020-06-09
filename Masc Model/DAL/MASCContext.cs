using Masc_Model.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Masc_Model.DAL
{
    public class MASCContext:DbContext
    {
        public MASCContext(DbContextOptions<MASCContext> options)
    : base(options)
        {
        }

        public DbSet<Club> Clubs { get; set; }

        public DbSet<Syllabus> Syllabi { get; set; }

        public DbSet<Disablity> Disablities { get; set; }

        public DbSet<Student> Students { get; set; }

        public DbSet<StudentDisability> StudentDisabilities { get; set; }

        public DbSet<Grade> Grades { get; set; }

        public DbSet<Address> Addresses { get; set; }

    }
}

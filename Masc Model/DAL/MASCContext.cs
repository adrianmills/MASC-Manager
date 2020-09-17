using Masc_Model.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Masc_Model.DAL
{
    public class MASCContext : DbContext, IMASCContext
    {
        public MASCContext(DbContextOptions<MASCContext> options)
    : base(options)
        {
        }

        public virtual DbSet<Club> Clubs { get; set; }

        public virtual DbSet<Syllabus> Syllabi { get; set; }

        public virtual DbSet<Disablity> Disablities { get; set; }

        public virtual DbSet<Student> Students { get; set; }

        public virtual DbSet<StudentDisability> StudentDisabilities { get; set; }

        public virtual DbSet<Grade> Grades { get; set; }

        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<User> Users { get; set; }
    }
}

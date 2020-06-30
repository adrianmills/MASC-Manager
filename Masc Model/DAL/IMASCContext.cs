using Masc_Model.Model;
using Microsoft.EntityFrameworkCore;

namespace Masc_Model.DAL
{
    public interface IMASCContext
    {
        DbSet<Address> Addresses { get; set; }
        DbSet<Club> Clubs { get; set; }
        DbSet<Disablity> Disablities { get; set; }
        DbSet<Grade> Grades { get; set; }
        DbSet<StudentDisability> StudentDisabilities { get; set; }
        DbSet<Student> Students { get; set; }
        DbSet<Syllabus> Syllabi { get; set; }

        DbSet<User> Users { get; set; }
    }
}
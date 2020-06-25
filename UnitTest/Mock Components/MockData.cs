using Business_Logic.DataRetrival.Interface;
using Business_Logic.DTO;
using Business_Logic.DTO.Interface;
using Masc_Model.Model;
using Masc_Model.Model.Interface;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Text;

namespace UnitTest.Mock_Components
{
    public class MockData
    {

       internal List<IClub> MockClubs
        {
            get
            {
                var clubs = new List<IClub>();
                clubs.Add(new Club { ID = 1, Name = "Club Test 1", CreatedBy = "Unit Test", CreatedOn = DateTime.Now, Deleted = false });
                clubs.Add(new Club { ID = 2, Name = "Club Test 2", CreatedBy = "Unit Test", CreatedOn = DateTime.Now, Deleted = false });
                clubs.Add(new Club { ID = 3, Name = "Club Test 3", CreatedBy = "Unit Test", CreatedOn = DateTime.Now, Deleted = true });

                return clubs;
            }
        }

        internal List<ISyllabus> MockSyllabi
        {
            get
            {

                var syllabi = new List<ISyllabus>();

                syllabi.Add(new Syllabus { ID = 1, Name = "Syllabus Test 1", CreatedBy = "Unit Test", CreatedOn = DateTime.Now, Deleted = false });
                syllabi.Add(new Syllabus { ID = 2, Name = "Syllabus Test 2", CreatedBy = "Unit Test", CreatedOn = DateTime.Now, Deleted = false });
                syllabi.Add(new Syllabus { ID = 3, Name = "Syllabus Test 3", CreatedBy = "Unit Test", CreatedOn = DateTime.Now, Deleted = true });

                return syllabi;
            }
        }
        internal List<IClubDTO> MockClubsDTO
        {
            get
            {
                var clubs = new List<IClubDTO>();
                foreach (var c in MockClubs.Where(cl => !cl.Deleted))
                {
                    clubs.Add(new ClubDTO { ID = c.ID, ClubName = c.Name });
                }
                return clubs;
            }
        }

        internal List<ISyllabusDTO> MOCKSyllabusDTOs
        {
            get
            {
                var syallbi = new List<ISyllabusDTO>();


                foreach(var s in MockSyllabi.Where(s=>!s.Deleted))
                {
                    syallbi.Add(new SyllabusDTO { ID = s.ID, SyllabusName = s.Name });
                }


                return syallbi;


            }
        }

    }
}

using AutoMapper;
using Business_Logic.DataRetrival.Interface;
using Business_Logic.View_Model;
using Business_Logic.View_Model.Interface;
using Masc_Model.DAL;
using Masc_Model.Model;
using Masc_Model.Model.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Business_Logic.DataRetrival
{
    public class ClubData : BaseData, IClubData
    {

        public ClubData(MASCContext context, IMapper mapper, IUser user) : base(context, mapper, user)
        {

        }

        public ClubData(MASCContext context, IMapper mapper) : base(context, mapper)
        {

        }
        public IEnumerable<IClubViewModel> Clubs
        {
            get
            {
                var clubs = new List<IClubViewModel>();
               

                    clubs.AddRange( from c in _context.Clubs
                               .Include(m => m.Manager)
                               where !c.Deleted
                               select _mapper.Map<IClub, ClubViewModel>(c));
  


              
                return clubs;


            }
        }

        public void Add(IClubViewModel record)
        {
            var club = _mapper.Map<IClubViewModel, Club>(record);
            AddDetails(club, true);
            _context.Clubs.Add(club);
            _context.SaveChanges();
        }

        public void Delete(long id)
        {
            var club = RetriveClub(id, true);

            club.Deleted = true;

            AddDetails(club);
            _context.Clubs.Update((Club)club);
            _context.SaveChanges();
        }



        public IClubViewModel Detail(long ID)
        {
            var rawData = RetriveClub(ID);

            var club = _mapper.Map<IClub, IClubViewModel>(rawData);

            var students = new List<IStudentViewModel>();

            foreach (var student in rawData.Students.Where(s=>!s.Deleted))
            {
                var studentVM = _mapper.Map<IStudent, IStudentViewModel>(student);
                students.Add(studentVM);
            }

            club.Students = students;

            return club;
        }


        IClub RetriveClub(long id, bool forEdit = false)
        {
            var query = from club in _context.Clubs
                          .Include(c => c.Manager)
                          .Include(c => c.Students)
                        where club.ID == id
                        select club;

            if(!forEdit)
            {
                query = query.AsNoTracking();
            }


            return query.FirstOrDefault();
                           
        }

        public void Update(IClubViewModel record)
        {
            var clubToUpdate = RetriveClub(record.ClubID, true);

            _mapper.Map(record, clubToUpdate);

            if (_context.ChangeTracker.HasChanges())
            {
                AddDetails(clubToUpdate);
                _context.Clubs.Update((Club)clubToUpdate);
                _context.SaveChanges();
            }
        }
    }




}

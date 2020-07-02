using AutoMapper;
using Business_Logic.DataRetrival.Data_Items.Interface;
using Business_Logic.DataRetrival.Interface;
using Business_Logic.View_Model.Interface;
using Masc_Model.DAL;
using Masc_Model.Model;
using Masc_Model.Model.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business_Logic.DataRetrival
{
    public class ClubData : BaseData, IClubData
    {

        public ClubData(MASCContext context, IMapper mapper, IUser user) : base(context, mapper, user)
        {

        }

        public IEnumerable<IClubViewModel> Clubs
        {
            get
            {
                var clubs = new List<IClubViewModel>();
                IEnumerable<IClub> rawClubs;
                if (_user.Manager)
                {
                    rawClubs = from c in _context.Clubs
                               .Include(m => m.Manager)
                               where !c.Deleted
                               select c;
                }
                else
                {
                    rawClubs = from c in _context.Clubs
                               .Include(m => m.Manager)
                               where !c.Deleted && c.ManagerID == _user.ID
                               select c;
                }

                foreach (var rawClub in rawClubs)
                {
                    var club = _mapper.Map<IClub, IClubViewModel>(rawClub);
                    clubs.Add(club);
                }
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
            var club = RetriveData(id, true);

            club.Deleted = true;

            AddDetails(club);
            _context.Clubs.Update((Club)club);
            _context.SaveChanges();
        }



        public IClubViewModel Detail(long ID)
        {
            var rawData = RetriveData(ID);

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


        public bool ProccessClubs(IClubDataItems dataItems)
        {
            throw new NotImplementedException();
        }

        IClub RetriveData(long id, bool isEdit = false)
        {
            IClub clubData;
            if (isEdit)
            {
                clubData = (from club in _context.Clubs
                           .Include(c => c.Manager)
                           .Include(c => c.Students)
                            where club.ID == id
                            select club
                           ).FirstOrDefault();
            }
            else
            {
                clubData = (from club in _context.Clubs
                           .Include(c => c.Manager)
                           .Include(c => c.Students)
                           .AsNoTracking()
                            where club.ID == id
                            select club
                           ).FirstOrDefault();
            }

            return clubData;
        }

        public void Update(IClubViewModel record)
        {
            var clubToUpdate = RetriveData(record.ClubID, true);

            _mapper.Map(record, clubToUpdate);

            AddDetails(clubToUpdate);
            _context.Clubs.Update((Club)clubToUpdate);
            _context.SaveChanges();
        }
    }




}

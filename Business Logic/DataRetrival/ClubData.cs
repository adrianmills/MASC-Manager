using Business_Logic.DataRetrival.Interface;
using Business_Logic.DTO;
using Business_Logic.DTO.Interface;
using Masc_Model.DAL;
using Masc_Model.Model;
using Masc_Model.Model.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;

namespace Business_Logic.DataRetrival
{
    public class ClubData : BaseData, IClubData
    {
        MASCContext _context;

        public ClubData(MASCContext context, IUser user) : base(user)
        {
            _context = context;
        }

        public IEnumerable<IClubDTO  > Clubs 
        { 
            get
            {
                List<IClubDTO> clubs = new List<IClubDTO>();

                clubs.AddRange(from c in _context.Clubs
                               where !c.Deleted
                               select new ClubDTO
                               {
                                   ID = c.ID,
                                   ClubName = c.Name
                               });

                return clubs;
            }
        }

        void Add(IClub record)
        {
            AddDetails(record, true);
            _context.Clubs.Add((Club)record);
        }

        public void Delete(long id)
        {
            Delete(Find(id, true));


        }

        public void Delete(IClub record)
        {
            AddDetails(record, false);
            record.Deleted = true;
        }

        public IClub Find(long id, bool isEdit)
        {
            return Find(c => c.ID == id, isEdit);
        }

        public IClub Find(Expression<Func<IClub, bool>> filter, bool isEdit)
        {
            IClub club;

            if (isEdit)
            {
                club = (from c in _context.Clubs
                        .Where(filter)
                        select c).FirstOrDefault();
            }
            else
            {
                club = (from c in _context.Clubs
                        .AsNoTracking()
                        .Where(filter)
                        select c).FirstOrDefault();
            }



            return club;
        }

        public bool ProccessClubs(IClubDataItems dataItems)
        {
            try
            {
                IClub club=null;
                foreach (IClubDTO c in dataItems.Clubs)
                {
                    if (c.ID == 0)
                    {
                        club = new Club { Name = c.ClubName };
                        AddDetails(club, true);
                        Add(club);
                    }
                    else
                    {
                        club = Find(c.ID, true);

                        if (club.Name != c.ClubName)

                        {
                            club.Name = c.ClubName;
                            AddDetails(club);
                            _context.Clubs.Update((Club)club);
                        }
                    }
                }

                foreach(IClubDTO c in dataItems.DeletedClubs)
                {
                    Delete(c.ID);
                }    
                _context.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        void Update(IClub record)
        {
            AddDetails(record, false);
        }
    }

    public class ClubDataItems : IClubDataItems
    {

        public ClubDataItems()
        {
            Clubs = new List<IClubDTO>();
            DeletedClubs = new List<IClubDTO>();
        }

        public List<IClubDTO> Clubs { get; set; }
        public List<IClubDTO> DeletedClubs { get; set; }
    }
}

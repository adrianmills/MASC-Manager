using Business_Logic.DataRetrival.Interface;
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

        public IEnumerable<IClub> Clubs { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        void Add(IClub record)
        {
            AddDetails(record, true);
            _context.Clubs.Add((Club)record);
        }

        public void Delete(int id)
        {
            Delete(Find(id, true));


        }

        public void Delete(IClub record)
        {
            AddDetails(record, false);
            record.Deleted = true;
        }

        public IClub Find(int id, bool isEdit)
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

        public void ProccessClubs(IEnumerable<IClub> clubs)
        {
            foreach (IClub club in clubs.Where(c => c.Updated || c.New))
            {
                if (club.New)
                {
                    Add(club);
                }
                else
                {
                    Update(club);
                }
            }

            _context.SaveChanges();
        }

        void Update(IClub record)
        {
            AddDetails(record, false);
        }
    }
}

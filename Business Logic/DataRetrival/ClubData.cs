using AutoMapper;
using Business_Logic.DataRetrival.Data_Items.Interface;
using Business_Logic.DataRetrival.Interface;
using Business_Logic.View_Model.Interface;
using Masc_Model.DAL;
using Masc_Model.Model.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Business_Logic.DataRetrival
{
    public class ClubData : BaseData, IClubData
    {

        public ClubData(MASCContext context,IMapper mapper, IUser user) : base(context, mapper, user)
        {
  
        }

        public IEnumerable<IClubViewModel> Clubs
        {
            get
            {
                var clubs = new List<IClubViewModel>();
                IEnumerable<IClub> rawClubs;
                if(_user.Manager)
                {
                    rawClubs = from c in _context.Clubs
                               .Include(m=>m.Manager)
                               where !c.Deleted
                                select c;
                }
                else
                {
                    rawClubs = from c in _context.Clubs
                               .Include(m => m.Manager)
                               where !c.Deleted && c.ManagerID==_user.ID
                               select c;
                }

                foreach(var rawClub in rawClubs)
                {
                    var club = _mapper.Map<IClub, IClubViewModel>(rawClub);
                    clubs.Add(club);
                }
                return clubs;


            }
        }

        public bool Add(IClubViewModel record)
        {
            throw new NotImplementedException();
        }

        public void Delete(long id)
        {
            throw new NotImplementedException();
        }

        public void Delete(IClubViewModel record)
        {
            throw new NotImplementedException();
        }

        public IClubViewModel Detail(long ID)
        {
            throw new NotImplementedException();
        }

        public IClubViewModel Find(long id, bool isEdit)
        {
            throw new NotImplementedException();
        }

        public IClubViewModel Find(Expression<Func<IClubViewModel, bool>> filter, bool isEdit)
        {
            throw new NotImplementedException();
        }

        public bool ProccessClubs(IClubDataItems dataItems)
        {
            throw new NotImplementedException();
        }

        public bool Update(IClubViewModel record)
        {
            throw new NotImplementedException();
        }
    }

    


}

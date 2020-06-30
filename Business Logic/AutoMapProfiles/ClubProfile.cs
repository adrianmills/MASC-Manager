using AutoMapper;
using Business_Logic.View_Model.Interface;
using Masc_Model.Model.Interface;

namespace Business_Logic.AutoMapProfiles
{
    public class MASCProfiles:Profile
    {
        public MASCProfiles()
        {
            CreateMap<IClub, IClubViewModel>()
                .ForMember(s => s.ClubID, d => d.MapFrom(src => src.ID))
                .ForMember(s => s.ClubName, d => d.MapFrom(src => src.Name))
                .ForMember(s => s.Manager, d => d.MapFrom(src => src.Manager.UserName));

            CreateMap<IClubViewModel, IClub>();
        }
    }
    
}

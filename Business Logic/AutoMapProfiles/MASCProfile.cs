using AutoMapper;
using Business_Logic.View_Model.Interface;
using Masc_Model.Model;
using Masc_Model.Model.Interface;

namespace Business_Logic.AutoMapProfiles
{
    public class MASCProfiles:Profile
    {
        public MASCProfiles()
        {
            CreateMap<IClub, IClubViewModel>()
                .ForMember(dest => dest.ClubID, d => d.MapFrom(src => src.ID))
                .ForMember(dest => dest.ClubName, d => d.MapFrom(src => src.Name))
                .ForMember(dest => dest.Manager, d => d.MapFrom(src => src.Manager.UserName))
                .ForMember(dest => dest.Students, act => act.Ignore());

            CreateMap<IClubViewModel, Club>()
                .ForMember(dest => dest.Name, d => d.MapFrom(src => src.ClubName))
                .ForMember(dest => dest.ID, d => d.MapFrom(src => src.ClubID))
                .ForMember(dest => dest.ManagerID, d => d.MapFrom(src => src.ManagerID))
                .ForMember(dest => dest.Manager, act => act.Ignore())
                .ForMember(dest => dest.Students, act => act.Ignore())
                ;

            CreateMap<ISyllabus, ISyllabusViewModel>()
                .ForMember(dest => dest.SyllabusName, d => d.MapFrom(src => src.Name))
                .ForMember(dest => dest.SyllabusID, d => d.MapFrom(src => src.ID))
                .ForMember(dest => dest.Grades, d => d.Ignore())
                .ForMember(dest => dest.Students, d => d.Ignore());

            CreateMap<ISyllabusViewModel,Syllabus>()
            .ForMember(dest => dest.Name, d => d.MapFrom(src => src.SyllabusName))
            .ForMember(dest => dest.ID, d => d.MapFrom(src => src.SyllabusID))
            .ForMember(dest => dest.Grades, d => d.Ignore())
            .ForMember(dest => dest.Students, d => d.Ignore());

            CreateMap<IGrade, IGradeViewModel>()
                .ForMember(dest => dest.GradeName, d => d.MapFrom(src => src.Name))
                .ForMember(dest => dest.GradeID, d => d.MapFrom(src => src.ID))
                .ForMember(dest => dest.SyallbusID, d=>d.MapFrom(src => src.SyllabusID))
                .ForMember(dest => dest.Syllabus, d => d.MapFrom(src => src.Syllabus.Name));

            CreateMap<IGradeViewModel, Grade>()
                .ForMember(dest => dest.Name, d => d.MapFrom(src => src.GradeName))
                .ForMember(dest => dest.ID, d => d.MapFrom(src => src.GradeID));


            CreateMap<IStudent, IStudentViewModel>()
                .ForMember(dest => dest.StudentID, d => d.MapFrom(src => src.ID))
                .ForMember(dest => dest.ClubName, d => d.MapFrom(src => src.Club.Name))
                .ForMember(dest => dest.SyllabusName, d => d.MapFrom(src => src.Syllabus.Name));





        }
    }
    
}

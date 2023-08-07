using AutoMapper;
using StudentApi.DataModels;
using StudentApi.DTOs;

namespace StudentApi.Profiles
{
    public class AutoMapperProfiles:Profile
    {

        public AutoMapperProfiles()
        {
            CreateMap<StudentApi.DTOs.Student, StudentApi.DataModels.Student>().ReverseMap();
            
        }
    }
}

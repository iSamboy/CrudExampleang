using AutoMapper;
using CrudExampleAng.DTOs;
using CrudExampleAng.Models;
using System.Globalization;

namespace CrudExampleAng.Utilities
{
    // Configuration class for the model to become DTO

    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            #region Office
            CreateMap<Office, OfficeDTO>().ReverseMap();
            #endregion

            #region Employee
            CreateMap<Employee, EmployeeDTO>()
                .ForMember(destiny =>
                destiny.NameOffice,
                opt => opt.MapFrom(origin => origin.IdOfficeNavigation.OfficeName)
                )
                .ForMember(destiny =>
                destiny.ContractDate,
                opt => opt.MapFrom(origin => origin.ContractDate.Value.ToString("dd/MM/yyyy"))
                );

            // i've to reverse the last method - DTO to model

            CreateMap<EmployeeDTO, Employee>()
                .ForMember(destiny =>
                destiny.IdOfficeNavigation,
                opt => opt.Ignore()
                );
            CreateMap<EmployeeDTO, Employee>()
                .ForMember(destiny =>
                destiny.ContractDate,
                opt => opt.MapFrom(origin=> DateTime.ParseExact(origin.ContractDate,"dd/MM/yyyy", CultureInfo.InvariantCulture))
                );
            #endregion
        }
    }
}

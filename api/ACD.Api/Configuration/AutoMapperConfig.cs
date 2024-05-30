using ACD.Api.Dto;
using ACD.Domain.Models;
using AutoMapper;



namespace ACD.Api.Configuration;



/// <summary>
/// Configuration class for AutoMapper profiles. 
/// This class defines the mappings between domain entities and their corresponding DTOs (Data Transfer Objects).
/// </summary>
public class AutoMapperConfig : Profile
{

    /// <summary>
    /// Constructor of AutoMapperConfig
    /// </summary>
    public AutoMapperConfig()
    {

        CreateMap<BalanceServiceProvider, BalanceServiceProviderDTO>().ReverseMap();
        CreateMap<BalanceServiceProviderDTO, BalanceServiceProvider>().ReverseMap();

    }

}
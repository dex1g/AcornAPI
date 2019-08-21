using Acorn.BL.Models;
using AcornAPI.Dtos;
using AcornAPI.Queries;
using AutoMapper;

namespace AcornAPI.Configurations
{
    public class MappingProflie : Profile
    {
        public MappingProflie()
        {
            CreateMap<Account, AccountDto>();
            CreateMap<AccountDto, Account>();
            CreateMap<Bot, BotDto>();
            CreateMap<BotDto, Bot>();
            CreateMap<Config, ConfigDto>();
            CreateMap<ConfigDto, Config>();
            CreateMap<Log, LogDto>();
            CreateMap<LogDto, Log>();
            CreateMap<User, RegisterQuery>();
            CreateMap<RegisterQuery, User>();
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
            CreateMap<FreshAccount, Account>();
            CreateMap<Account, FreshAccount>();
            CreateMap<Account, ReadyAccount>();
        }
    }
}

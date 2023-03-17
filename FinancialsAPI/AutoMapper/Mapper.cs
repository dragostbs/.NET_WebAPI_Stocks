using FinancialsAPI.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FinancialsAPI.Models;

namespace FinancialsAPI.AutoMapper
{
    /*public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<Transaction, TransactionDto>().ReverseMap();

            CreateMap<TransactionDto, Transaction>()
                .ForMember(s => s.Stock, opt => opt.MapFrom(src => src.Symbol))
                .ForMember(p => p.Stock, opt => opt.MapFrom(src => src.Price));
        }
    }*/
}

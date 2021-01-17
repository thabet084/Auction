using Auction.Domain;
using Auction.Services.ViewModels;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Auction.Services
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Item, ItemViewModel>()
                  .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.StartingPrice))
                .ReverseMap();
        }
    }
}

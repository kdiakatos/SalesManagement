using AutoMapper;
using SalesManagement.BusinessLayer.Models;
using SalesManagement.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SalesManagement.BusinessLayer.Utilities
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Sale, SaleModel>().ReverseMap();
            CreateMap<Seller, SellerModel>().ReverseMap();
        }
    }
}

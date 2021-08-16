using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using NWEB.Practice.T01.Core.Models;
using NWEB.Practice.T01.Web.Areas.Admin.ViewModel;

namespace NWEB.Practice.T01.Web.Areas.Admin.Mapper
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Flower, FlowerViewModel>();
            CreateMap<FlowerViewModel, Flower>();
            CreateMap<Color, ColorViewModel>();
            CreateMap<ColorViewModel, Color>();
            CreateMap<Category, CategoryViewModel>();
            CreateMap<CategoryViewModel,Category>();

        }
    }
}
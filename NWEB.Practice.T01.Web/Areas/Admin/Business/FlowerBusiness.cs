using NWEB.Practice.T01.DataAccessLayer.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NWEB.Practice.T01.Web.Areas.Admin.ViewModel;
using NWEB.Practice.T01.Core.Models;

namespace NWEB.Practice.T01.Web.Areas.Admin.Business
{
    public static class FlowerBusiness
    {
        private static readonly FlowerService flowerService = new FlowerService();

        public static List<FlowerViewModel> GetAll()
        {
            return AutoMapper.Mapper.Map<IEnumerable<FlowerViewModel>>(flowerService.GetAll()).ToList();
        }

        public static FlowerViewModel FindById(int id)
        {
            return AutoMapper.Mapper.Map<FlowerViewModel>(flowerService.FindById(id));
        }

        public static bool Create(FlowerViewModel obj)
        {
            var a = AutoMapper.Mapper.Map<FlowerViewModel, Flower>(obj);
            return flowerService.Add(a);
        }
        public static bool CreateSaleOff(SaleOfViewModel obj)
        {

            var a = AutoMapper.Mapper.Map<SaleOfViewModel, Flower>(obj);
            a.SalePrice = a.Price - (a.Price) * obj.SaleOff;
            return flowerService.Add(a);
        }

        public static bool Edit(FlowerViewModel obj)
        {
            return flowerService.Update(AutoMapper.Mapper.Map<FlowerViewModel, Flower>(obj));
        }

        public static bool Delete(int id)
        {
            return flowerService.Delete(id);
        }
    }
}
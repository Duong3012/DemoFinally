using NWEB.Practice.T01.DataAccessLayer.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NWEB.Practice.T01.Web.Areas.Admin.ViewModel;
using System.Drawing;
using Color = NWEB.Practice.T01.Core.Models.Color;

namespace NWEB.Practice.T01.Web.Areas.Admin.Business
{
    public static class ColorBusiness
    {
        private static ColorService colorService = new ColorService();

        public static List<ColorViewModel> GetAll()
        {
            return AutoMapper.Mapper.Map<IEnumerable<ColorViewModel>>(colorService.GetAll()).ToList();
        }

        public static ColorViewModel FindById(int id)
        {
            return AutoMapper.Mapper.Map<ColorViewModel>(colorService.FindById(id));
        }

        public static bool Create(ColorViewModel obj)
        {
            return colorService.Add(AutoMapper.Mapper.Map<ColorViewModel, Color>(obj));
        }

        public static bool Edit(ColorViewModel obj)
        {
            return colorService.Update(AutoMapper.Mapper.Map<ColorViewModel, Color>(obj));
        }

        public static bool Delete(int id)
        {
            return colorService.Delete(id);
        }
    }
}
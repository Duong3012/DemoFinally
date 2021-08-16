using NWEB.Practice.T01.DataAccessLayer.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NWEB.Practice.T01.Core.Models;
using NWEB.Practice.T01.Web.Areas.Admin.ViewModel;

namespace NWEB.Practice.T01.Web.Areas.Admin.Business
{
    public static class CategoryBusiness
    {
        private static readonly CategoryService _categoryService = new CategoryService();

        public static List<CategoryViewModel> GetAll()
        {
            var categories = _categoryService.GetAll();
            if (categories.Any())
            {
                return AutoMapper.Mapper.Map<IEnumerable<CategoryViewModel>>(categories).ToList();
            }

            return null;

        }

        public static CategoryViewModel FindById(int id)
        {
            return AutoMapper.Mapper.Map<CategoryViewModel>(_categoryService.FindById(id));
        }

        public static bool Create(CategoryViewModel categoryViewModel)
        {
            var category = AutoMapper.Mapper.Map<CategoryViewModel, Category>(categoryViewModel);
            return _categoryService.Add(category);
        }

        public static bool Edit(CategoryViewModel obj)
        {
           return _categoryService.Update(AutoMapper.Mapper.Map<CategoryViewModel, Category>(obj));
        }

        public static bool Delete(int id)
        {
            return _categoryService.Delete(id);
        }

    }
}
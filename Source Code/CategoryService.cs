using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NetsmartzOnlineStore.DB;
using NetsmartzOnlineStore.Models;

namespace NetsmartzOnlineStore.Services
{
    public class CategoryService : ICategoryService
    {
        NetsmartzStore_DBEntities _dbentity = new NetsmartzStore_DBEntities();

        public List<CategoryModels.CategoryDisplayModel> GetCategoryList()
        {
            try
            {
                var catLst = from a in _dbentity.CatagoryTbls

                             select new CategoryModels.CategoryDisplayModel
                             {
                                 CategoryID_PK = a.CategoryID_PK,
                                 CategoryName = a.CategoryName,
                                 CategoryDescription = a.CategoryDescription,
                                 MinPriceRange = a.MinPrice,
                                 MaxPriceRange = a.MaxPrice,
                                 DisplayOrder = a.DisplayOrder,
                                 ProductCount = a.ProductTbls.Where(x => x.CategoryID_FK == a.CategoryID_PK).Count()
                             };
                return catLst.ToList();
            }
            catch (Exception ex)
            {

                throw;
            }
            
        }

        public int CreateCategory(CategoryModels obj)
        {
            try
            {
                var dbData = new CatagoryTbl();
                dbData.CategoryName = obj.CategoryName;
                dbData.CategoryDescription = obj.CategoryDescription;
                dbData.MinPrice = obj.MinPriceRange;
                dbData.MaxPrice = obj.MaxPriceRange;
                dbData.DisplayOrder = obj.DisplayOrder;
                _dbentity.CatagoryTbls.Add(dbData);
                _dbentity.SaveChanges();
                return dbData.CategoryID_PK;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public CategoryModels GetCategoryByID(int id)
        {
            try
            {
                CatagoryTbl catDtls = _dbentity.CatagoryTbls.Where(x => x.CategoryID_PK == id).FirstOrDefault();
                CategoryModels obj = new CategoryModels();
                obj.CategoryID_PK = catDtls.CategoryID_PK;
                obj.CategoryName = catDtls.CategoryName;
                obj.CategoryDescription = catDtls.CategoryDescription;
                obj.MinPriceRange = catDtls.MinPrice;
                obj.MaxPriceRange = catDtls.MaxPrice;
                obj.DisplayOrder = catDtls.DisplayOrder;

                return obj;
            }
            catch (Exception ex)
            {

                throw;
            }            
        }
        public bool UpdateCategory(CategoryModels editObj)
        {
            try
            {
                CatagoryTbl dbObj = _dbentity.CatagoryTbls.Where(x => x.CategoryID_PK == editObj.CategoryID_PK).FirstOrDefault();
                dbObj.CategoryName = editObj.CategoryName;
                dbObj.CategoryDescription = editObj.CategoryDescription;
                dbObj.MinPrice = editObj.MinPriceRange;
                dbObj.MaxPrice = editObj.MaxPriceRange;
                dbObj.DisplayOrder = editObj.DisplayOrder;
                _dbentity.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                throw;
            }         
        }
        public bool DeleteCategory(int id)
        {
            try
            {
                CatagoryTbl obj = _dbentity.CatagoryTbls.Where(x => x.CategoryID_PK == id).FirstOrDefault();
                _dbentity.CatagoryTbls.Remove(obj);
                _dbentity.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                throw;
            }           
        }
    }
    public interface ICategoryService
    {
        List<CategoryModels.CategoryDisplayModel> GetCategoryList();
        int CreateCategory(CategoryModels obj);
        CategoryModels GetCategoryByID(int id);
        bool UpdateCategory(CategoryModels editObj);
        bool DeleteCategory(int id);
    }
}
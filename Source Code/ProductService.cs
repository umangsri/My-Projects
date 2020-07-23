using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NetsmartzOnlineStore.DB;
using NetsmartzOnlineStore.Models;

namespace NetsmartzOnlineStore.Services
{
    public class ProductService : IProductService
    {
        NetsmartzStore_DBEntities _dbentity = new NetsmartzStore_DBEntities();

        public List<ProductModels.ProductModelsDisplay> GetProductList(int id)
        {
            try
            {
                var catLst = from a in _dbentity.ProductTbls
                             where a.CategoryID_FK == id
                             select new ProductModels.ProductModelsDisplay
                             {
                                 ProductID_PK = a.ProductID_PK,
                                 CategoryID_FK = a.CategoryID_FK,
                                 ProductName = a.ProductName,
                                 ProductDescription = a.ProductDescription,
                                 ProductQuantity = a.ProductQuantity,
                                 ProductPrice = a.ProductPrice,
                                 Discount = a.Discount,
                                 ExpiryDate = a.ExpiryDate
                             };
                return catLst.ToList();
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public int CreateProduct(ProductModels obj)
        {
            try
            {
                var dbData = new ProductTbl();
                dbData.CategoryID_FK = obj.CategoryID_FK;
                dbData.ProductName = obj.ProductName;
                dbData.ProductDescription = obj.ProductDescription;
                dbData.ProductQuantity = obj.ProductQuantity;
                dbData.ProductPrice = obj.ProductPrice;
                dbData.Discount = obj.Discount;
                dbData.ExpiryDate = obj.ExpiryDate;
                _dbentity.ProductTbls.Add(dbData);
                _dbentity.SaveChanges();
                return dbData.ProductID_PK;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public ProductModels GetProductByID(int id, int catID)
        {
            try
            {
                ProductTbl productDtls = _dbentity.ProductTbls.Where(x => x.ProductID_PK == id && x.CategoryID_FK == catID).FirstOrDefault();
                ProductModels obj = new ProductModels();
                obj.ProductID_PK = productDtls.ProductID_PK;
                obj.CategoryID_FK = productDtls.CategoryID_FK;
                obj.ProductName = productDtls.ProductName;
                obj.ProductDescription = productDtls.ProductDescription;
                obj.ProductQuantity = productDtls.ProductQuantity;
                obj.ProductPrice = productDtls.ProductPrice;
                obj.Discount = productDtls.Discount;
                obj.ExpiryDate = productDtls.ExpiryDate;

                return obj;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public bool UpdateProduct(ProductModels editObj)
        {
            try
            {
                ProductTbl dbObj = _dbentity.ProductTbls.Where(x => x.ProductID_PK == editObj.ProductID_PK && x.CategoryID_FK == editObj.CategoryID_FK).FirstOrDefault();
                dbObj.ProductName = editObj.ProductName;
                dbObj.ProductDescription = editObj.ProductDescription;
                dbObj.ProductQuantity = editObj.ProductQuantity;
                dbObj.ProductPrice = editObj.ProductPrice;
                dbObj.Discount = editObj.Discount;
                dbObj.ExpiryDate = editObj.ExpiryDate;
                _dbentity.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public bool DeleteProduct(int id, int catID)
        {
            try
            {
                ProductTbl obj = _dbentity.ProductTbls.Where(x => x.ProductID_PK == id && x.CategoryID_FK == catID).FirstOrDefault();
                _dbentity.ProductTbls.Remove(obj);
                _dbentity.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
    public interface IProductService
    {
        List<ProductModels.ProductModelsDisplay> GetProductList(int id);
        int CreateProduct(ProductModels obj);
        ProductModels GetProductByID(int id, int catID);
        bool UpdateProduct(ProductModels editObj);
        bool DeleteProduct(int id, int catID);
    }
}
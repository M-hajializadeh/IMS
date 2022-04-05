
using IMS.CoreBusiness.Model;
using IMS.UseCases.DataStorePluginInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Plugin.DataStore
{
    public class ProductRepository : IProductRepository
    {
        private List<Product> _products;
        public ProductRepository()
        {
            _products = new List<Product>()
            {
                new Product(){ Id = 1, Name ="دوربین پرتابل", Description ="توضیحات محصول", Quntity =2, CategoryId=1},
                new Product(){ Id = 2, Name ="دوربین استدیو", Description ="توضیحات محصول", Quntity =3, CategoryId=1},
                new Product(){ Id = 3, Name ="میکریفون پرتابل", Description ="توضیحات محصول",  Quntity =20, CategoryId=2},
                new Product(){ Id = 4, Name ="کانورتور به HDMI", Description ="توضیحات محصول", Quntity =12, CategoryId=3},
                new Product(){ Id = 5, Name ="سه پایه پرتابل", Description ="توضیحات محصول", Quntity =15, CategoryId=4},
            };

        }
        public IEnumerable<Product> GetProducts()
        {
            return _products;
        }
        public Product GetProduct(int id)=> _products?.FirstOrDefault(p=>p.Id== id);
       
        public Product GetProduct(string name)=> _products?.FirstOrDefault(p=>p.Name.Contains(name));

        public void AddProduct(Product product)
        {
            if (product == null) return;
            if (_products.Any(p => p.Id == product.Id)) return;
            var maxId = 0;
            if(_products.Count()>0 && _products!=null)
                maxId=_products.Max(p=>p.Id);
            product.Id = ++maxId;
            _products.Add(product);
        }

        public void UpdateProduct(Product product)
        {
            if(product == null) return;
            var pro=GetProduct(product.Id); 
            if (pro!=null)
            {
                pro.Id=product.Id;
                pro.Picture=product.Picture;
                pro.CategoryId=product.CategoryId;
                pro.Description=product.Description;
                pro.Name=product.Name;
                pro.Quntity=product.Quntity;
            }
        }

        public void DeleteProduct(int productId)
        {
            if(productId==0) return;
            _products?.Remove(GetProduct(productId));
        }

        public IEnumerable<Product> GetProductByCategoryId(int categoryId)
        {
            return _products.Where(p => p.CategoryId == categoryId);
        }
    }
}

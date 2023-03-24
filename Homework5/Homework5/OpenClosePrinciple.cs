using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework5
{
    public class OpenClosePrinciple
    {
        public OpenClosePrinciple()
        {
            //OpenClosePrinciple bir kodun değişime kapalı gelişime açık olması gerektiğini vurgular
            //Örneğin projede entityframework kullanılırken hibernate e geçilmek istendiğinde proje içerisinde bir aşırı bir değişiklik yapmadan sistemi hibernate geçirmemiz gerekir.

            IProductDal entityframewotkProductDal = new EntityFrameworkProductDal();
            IProductDal hibernateProductDal = new HibernateProductDal();

            //var productService = new ProductService(entityframewotkProductDal);
            var productService = new ProductService(hibernateProductDal);

        }
    }
    public class ProductService
    {
        private readonly IProductDal _productDal;
        public ProductService(IProductDal productDal)
        {
            _productDal = productDal;
        }
    }

    public interface IProductDal
    {
        void AddProduct();
    }

    public class EntityFrameworkProductDal : IProductDal
    {
        public void AddProduct()
        {
            Console.WriteLine("Product Added with Entityframework");
        }
    }

    public class HibernateProductDal : IProductDal
    {
        public void AddProduct()
        {
            Console.WriteLine("Product Added with Hibernate");
        }
    }

}

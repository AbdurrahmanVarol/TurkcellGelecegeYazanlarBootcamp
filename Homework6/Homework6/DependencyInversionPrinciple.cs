using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework6
{
    public class DependencyInversionPrinciple
    {
        public DependencyInversionPrinciple()
        {

        }
    }

    public class AnotherService
    {
        private readonly IProductService _productService;

        //1.Yöntem Constructor a enjekte ekme
        public AnotherService(IProductService productService)
        {
            _productService = productService;
        }

        //2.yöntem property ile
        public IProductService ProductService { get; set; }

        //3.yöntme metot parametresi ile
        void AddProduct(IProductService productService)
        {
            _productService.Add();
            ProductService.Add();
            productService.Add();
        }
    }



    public interface IProductService
    {
        void Add();
    }

    public class ProductService : IProductService
    {
        public void Add()
        {
            throw new NotImplementedException();
        }
    }

}

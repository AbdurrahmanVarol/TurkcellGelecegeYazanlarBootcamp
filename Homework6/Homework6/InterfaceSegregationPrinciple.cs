using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework6
{
    internal class InterfaceSegregationPrinciple
    {
    }
    public class Product
    {

    }
    public class Category
    {

    }
    public interface IEntityRepository<T>
    {
        List<T> GetAll();
    }
    public interface IProductService : IEntityRepository<Product>
    {
        List<Product> GetProductsByCategoryId(int categoryId);
    }
    public interface ICategoryService : IEntityRepository<Category>
    {

    }
}

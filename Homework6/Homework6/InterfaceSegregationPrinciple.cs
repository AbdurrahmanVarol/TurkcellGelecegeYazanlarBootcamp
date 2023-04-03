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
    public class brand
    {

    }
    public class Category
    {

    }
    public interface IEntityRepository<T>
    {
        List<T> GetAll();
    }
    public interface IBrandService : IEntityRepository<brand>
    {
        List<brand> GetProductsByCategoryId(int categoryId);
    }
    public interface ICategoryService : IEntityRepository<Category>
    {

    }
}

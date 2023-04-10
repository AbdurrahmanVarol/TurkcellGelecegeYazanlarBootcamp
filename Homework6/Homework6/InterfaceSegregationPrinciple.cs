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
    public class Brand
    {

    }
    public class Category
    {

    }
    public class Vehicle
    {

    }
    public interface IEntityRepository<T>
    {
        List<T> GetAll();
        T GetById(int id);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
    public interface IBrandService : IEntityRepository<Brand>
    {
        List<Brand> GetProductsByCategoryId(int categoryId);
    }
    public interface IVehicleService : IEntityRepository<Vehicle>
    {

    }
    public interface ICategoryService
    {
        List<Category> GetAll();
        Category GetById(int id);
        void Add(Category category);
    }
}

namespace Homework4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // "In"
            //Generic interface lerde "in" key word ü interface in içerisindeki metot imzalarına gelen parametrelerin tipini belirler
            //"in" parametresi ile işaretletmiş bir generic parametre metot imzalarında return tipi olarak kullanılamaz

            //"Out"
            //Generic interface lerde "out" key word ü interface in içerisindeki metot imzalarının return tipini belirler
            //"out" parametresi ile işaretletmiş bir generic parametre metot imzalarına gelen parametre tipi olarak kullanılamaz

            //Generic parametresinde "in" key word u kullanılan interface ler parametre olarak Parent class ı alır ise interface in implementasyonlarında child class i da parametre olarak geçebiliriz
            /* Örnek 
              var fihh = new Fish();
              var animal = new Animal();
              var inRepository = new Repository<Animal>();
              inRepository.Add(animal);
              inRepository.Add(fihh);
             */

            //Generic parametresinde "out" key word u kullanılan interface ler parametre olarak Child class ı alır ise interface in implementasyonlarında Parent class i da return edebiliriz

            var fihh = new Fish();
            var animal = new Animal();
            var inRepository = new Repository<Animal>();
            inRepository.Add(fihh);
            inRepository.Add(animal);

        }
    }

    class Animal
    {

    }
    class Fish : Animal
    {

    }
    class Cat : Animal
    {

    }

    interface IInRepository<in T>
    {
        void Add(T item);
    }
    class Repository<T> : IInRepository<T>
    {
        public void Add(T item)
        {
            Console.WriteLine(nameof(T) + " Added!");
        }
    }

    interface IOutRepository<out T>
    {
        T Add();
    }
    class OutRepository<T> : IOutRepository<T> where T : class, new()
    {
        public T Add()
        {

            Console.WriteLine(nameof(T) + " Added!");
            return new T();
        }
    }

}
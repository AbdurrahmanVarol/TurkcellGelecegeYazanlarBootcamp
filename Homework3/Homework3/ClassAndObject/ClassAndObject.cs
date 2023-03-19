using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework3.ClassAndObject
{
    public class ClassAndObject
    {
        //Class oluşturmak istediğimiz nesnenin özelliklerini ya da davyanışların belirlediğimiz yapıdır.
        //bir class ın new key word u ile ületilip bellekte bir alan kaplamış haline ise nesne ya da instance denir
        public ClassAndObject()
        {
            //aşağıda özellikleri ile birlikte tanımlanmış product class ını görmekteyiz
            var product = new Product()
            {
                Category= "Elektronik",
                Description = "Kırmızı Telefon",
                 Name= "Telefon",
                 Id = 1
            };
            // new key word ü ile oluşturulan product a ile instance denir
        }
    }
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
    }
}

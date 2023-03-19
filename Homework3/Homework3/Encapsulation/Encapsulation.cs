using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework3.Encapsulation
{
    public class Encapsulation
    {
        //encapsulation bir sınıfa ait olan özelliklerin dışarıdan erişime kapatılması ve bu özelliklere erişimin yine o class a olan metotlar tarafından kontrollü bir şekilde sağlanmasıdır.

        private string _name;

        public string GetName()
        {
            return _name;
        }
        public void SetName(string name)
        {
            _name = name;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework6
{
    public class LiskovSubstitutionPrinciple
    {

    }
    public interface IRentable
    {
        void Rent();
    }

    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }

    }
    public class BusinessBase : BaseEntity, IRentable
    {
        public void Rent()
        {
            throw new NotImplementedException();
        }
    }


    public class Car : BaseEntity, IRentable
    {
        public void Rent()
        {
            throw new NotImplementedException();
        }
    }
    public class HotelRoom : BaseEntity, IRentable
    {
        public void Rent()
        {
            throw new NotImplementedException();
        }
    }

    public class SeminarRoom : BusinessBase
    {

    }
    public class MeetingRoom : BusinessBase
    {

    }

}

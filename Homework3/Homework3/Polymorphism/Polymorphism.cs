using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework3.Polymorphism
{
    public class Polymorphism
    {
        //polymorphism bir üst class ın miras verdiği alt sınıfların referansını tutabilmesi ve alt sınıfların üst sınıftan aldığı metotları ihtiyaca göre override edebilmesi ya da olduğu gibi kullanabilmedisir.
        public Polymorphism()
        {
            MessageSender messageSender = new MessageSender();
            MessageSender emailSender = new EmailSender();
            MessageSender smsSender = new SmsSender();

            messageSender.Send();
            emailSender.Send();
            smsSender.Send();
        }
    }
    public class MessageSender
    {
        public virtual void Send()
        {
            Console.WriteLine("Message Sended!");
        }
    } 

    public class EmailSender : MessageSender
    {
        public override void Send()
        {
            // bir takım işlemler 
            Console.WriteLine("Email Sended");
        }
    }

    public class SmsSender : MessageSender
    {
        public override void Send()
        {
            // bir takım işlemler 
            Console.WriteLine("Sms Sended");
        }
    }
}

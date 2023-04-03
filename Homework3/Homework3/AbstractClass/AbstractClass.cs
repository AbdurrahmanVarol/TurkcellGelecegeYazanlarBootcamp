using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework3.AbstractClass
{
    public class AbstractClass
    {
        //içerisinde tamamlanmış ve tamamlanmamış metotlaarı barındıran class tır
        // abstract class ların constructor ları olabilir fakat abstract class ların bir instance ı oluşturulamaz yani new lenemezler.
        public AbstractClass()  
        {
            MessageSenderBase emailSender = new EmailSender("some value");
            MessageSenderBase smsSender = new SmsSender("some value");

            emailSender.Send();
            smsSender.Send();
        }
    }

    public abstract class MessageSenderBase
    {
        public MessageSenderBase(string value)
        {

        }
        protected abstract void Validate();
        protected abstract void Execute();
        public void Send()
        {
            Validate();
            Execute();
        }
    }
    public class EmailSender : MessageSenderBase
    {
        public EmailSender(string value) : base(value)
        {
        }

        protected override void Execute()
        {
            Console.WriteLine("");
        }

        protected override void Validate()
        {
            Console.WriteLine("");
        }
    }
    public class SmsSender : MessageSenderBase
    {
        public SmsSender(string value) : base(value)
        {
        }

        protected override void Execute()
        {
            Console.WriteLine("");
        }

        protected override void Validate()
        {
            Console.WriteLine("");
        }
    }

}

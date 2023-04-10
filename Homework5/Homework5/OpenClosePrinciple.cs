using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework5
{
    class OpenClosePrinciple
    {

        public OpenClosePrinciple()
        {
            //OpenClosePrinciple bir kodun değişime kapalı gelişime açık olması gerektiğini vurgular
            //Bu örnekte projeye yeni logger ya da cache yöntemleri eklendiği halde proje içerisinde çok fazla değişiklik yapılmadığı bir seneryo simüle edilmiştir
            //LoggerBase logger = new DatabaseLogger();
            //ICache cache = new RedisCache();

            //LoggerBase logger = new FileLogger();
            //ICache cache = new RedisCache();

            //LoggerBase logger = new DatabaseLogger();
            //ICache cache = new InMemoryCache();

            LoggerBase logger = new FileLogger();
            ICache cache = new InMemoryCache();


            logger.Log("info");
            cache.Get("info");

        }
    }

    internal abstract class LoggerBase
    {
        internal abstract void Log(string message);
    }

    internal class DatabaseLogger : LoggerBase
    {
        internal override void Log(string message)
        {
            Console.WriteLine("Logged to Database");
        }
    }
    internal class FileLogger : LoggerBase
    {
        internal override void Log(string message)
        {
            Console.WriteLine("Logged to File");
        }
    }

    internal interface ICache
    {
        string Get(string key);
        void Set(string key, string value);
    }
    internal class RedisCache : ICache
    {
        public string Get(string key)
        {
            throw new NotImplementedException();
        }

        public void Set(string key, string value)
        {
            throw new NotImplementedException();
        }
    }
    internal class InMemoryCache : ICache
    {
        public string Get(string key)
        {
            throw new NotImplementedException();
        }

        public void Set(string key, string value)
        {
            throw new NotImplementedException();
        }
    }
}

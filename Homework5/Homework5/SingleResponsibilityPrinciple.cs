namespace Homework5
{
    public class SingleResponsibilityPrinciple
    {
        public SingleResponsibilityPrinciple()
        {
            //SingleResponsibilityRrinciple bir metodun, class ın tek bir sorumluluğu olması gerektiğini vurgulamaktadır.
            //ProductRepository class ının görevi ürünleri eklemese mesaj gönderme işlemi ProductRepository içerisinde yapılmamalıdır
            var messageService = new SmsService();

            var productRepository = new ProductRepository(messageService);

            productRepository.AddProduct();

        }
    }

    public class ProductRepository
    {
        private readonly IMessageService _messageService;

        public ProductRepository(IMessageService messageService)
        {
            _messageService = messageService;
        }

        public void AddProduct()
        {
            Console.WriteLine("Product Added!");
            _messageService.SendMessage("New Product Added!");

        }
    }

    public interface IMessageService
    {
        void SendMessage(string message);
    }

    public class SmsService : IMessageService
    {
        public void SendMessage(string message)
        {
            Console.WriteLine(message);
        }
    }

    public class EmailService : IMessageService
    {
        public void SendMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}

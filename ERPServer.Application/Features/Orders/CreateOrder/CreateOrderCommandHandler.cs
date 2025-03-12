using AutoMapper;
using ERPServer.Domain.Entities;
using ERPServer.Domain.Repository;
using GenericRepository;
using MediatR;
using System.Text;
using TS.Result;

namespace ERPServer.Application.Features.Orders.CreateOrder
{
    internal sealed class CreateOrderCommandHandler(IOrderRepository orderRepository,IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<CreateOrderCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {

            
            string prefix = "TN"; 
            string year = request.Date.Year.ToString(); 
            string sequenceNumber = GenerateRandomNumber(10);            
            string sequencePart = sequenceNumber.ToString().PadLeft(10, '0');          
            string orderNumber = $"{prefix}{year}{sequencePart}";

            List<OrderDetail> details = request.Details.Select(s => new OrderDetail
            {
                Price = s.Price,
                ProductId = s.ProductId,
                Quantity = s.Quantity
            }).ToList();
            Order order = new()
            {
                CustomerId = request.CustomerId,
                Date = request.Date,
                DeliveryDate = request.DeliveryDate,
                OrderNumber = orderNumber,
                Details = details
            };

            await orderRepository.AddAsync(order, cancellationToken);
            await unitOfWork.SaveChangesAsync(cancellationToken);

            return "Sipariş başarıyla oluşturuldu";
            
        }

        private string GenerateRandomNumber(int length)
        {
            Random random = new Random();
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < length; i++)
            {
                sb.Append(random.Next(0, 10)); // 0 ile 9 arasında rastgele bir sayı ekle
            }

            return sb.ToString();
        }
    }
}

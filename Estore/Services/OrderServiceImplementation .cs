using Estore.Models;
using Estore.Protos;
using Grpc.Core;
using System.Threading.Tasks;

namespace Estore.Services
{

    public class OrderServiceImplementation : OrderService.OrderServiceBase
    {
        private readonly InventorygRPC _inventoryService;
        private readonly PaymentgRPC _paymentService;

 
        public OrderServiceImplementation(InventorygRPC inventoryService, PaymentgRPC paymentService)
        {
            _inventoryService = inventoryService;
            _paymentService = paymentService;
        }

      
        public override async Task<OrderResponse> ProcessOrder(Estore.Protos.OrderRequest request, ServerCallContext context)
        {
       
            var inventoryResponse = await _inventoryService.DeductInventoryAsync(request.ProductId, request.Quantity, request.Price);
            if (!inventoryResponse.Success)
            {
               
                return new OrderResponse { Success = false, Message = "Failed to deduct inventory." };
            }

           
            var paymentResponse = await _paymentService.ProcessPaymentAsync(request.ClientId, request.Quantity * request.Price);
            if (!paymentResponse.Success)
            {
               
                return new OrderResponse { Success = false, Message = "Payment processing failed." };
            }

        
            return new OrderResponse { Success = true, Message = "Order processed successfully." };
        }
    }
}

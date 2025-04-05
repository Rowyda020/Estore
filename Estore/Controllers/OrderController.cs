using Estore.Models;
using Microsoft.AspNetCore.Mvc;
using Grpc.Net.Client;
using InventoryService.Protos;
using PaymentService.Protos;
using System.Threading.Tasks;

namespace Estore.Controllers
{
    [ApiController]
    [Route("api/{controller}")]
    public class OrderController : ControllerBase
    {
        private readonly GrpcChannel _inventoryChannel;
        private readonly GrpcChannel _paymentChannel;

        public OrderController()
        {

            _inventoryChannel = GrpcChannel.ForAddress("https://localhost:7188"); 
            _paymentChannel = GrpcChannel.ForAddress("https://localhost:7108"); 
        }

        [HttpPost]
        public async Task<IActionResult> Ordering([FromBody] OrderRequest orderRequest)
        {
           
            var inventoryResponse = await DeductInventory(orderRequest.ProductId, orderRequest.Quantity, orderRequest.Price);
            if (!inventoryResponse.Success)
            {
                return BadRequest("Failed to deduct inventory.");
            }

            
            var paymentResponse = await ProcessPayment(orderRequest.ClientId, orderRequest.Quantity * orderRequest.Price);
            if (!paymentResponse.Success)
            {
                return BadRequest("Payment processing failed.");
            }

            return Ok(new
            {
                Success = true,
                Message = "Order processed successfully.",
                
            });
        }

 
        private async Task<DeductionResponse> DeductInventory(int productId, int quantity, double price)
        {
            var client = new DeductionProcess.DeductionProcessClient(_inventoryChannel);
            var inventoryRequest = new DeductionRequest
            {
                ProductId = productId,
                Quantity = quantity,
                Price = price
            };
            var response = await client.DeductionAsync(inventoryRequest);
            return response;
        }

    
        private async Task<TransactionResponse> ProcessPayment(int clientId, double totalAmount)
        {
            var client = new PaymentPorcess.PaymentPorcessClient(_paymentChannel);
            var paymentRequest = new TransactionRequest
            {
                ClientID = clientId,
                Balance = totalAmount
            };
            var response = await client.TransactionAsync(paymentRequest);
            return response;
        }
    }
}

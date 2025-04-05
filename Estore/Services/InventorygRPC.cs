using Grpc.Net.Client;
using InventoryService.Protos;

namespace Estore.Services
{
    public class InventorygRPC
    {

        private readonly DeductionProcess.DeductionProcessClient _client;

        public InventorygRPC(GrpcChannel channel)
        {
            _client = new DeductionProcess.DeductionProcessClient(channel);
        }

        public async Task<DeductionResponse> DeductInventoryAsync(int productId, int quantity, double price)
        {
            var request = new DeductionRequest
            {
                ProductId = productId,
                Quantity = quantity,
                Price = price
            };

            return await _client.DeductionAsync(request);
        }
    }
}

using Grpc.Net.Client;
using PaymentService.Protos;

namespace Estore.Services
{
    public class PaymentgRPC
    {
        private readonly PaymentPorcess.PaymentPorcessClient _client;

        public PaymentgRPC(GrpcChannel channel)
        {
            _client = new PaymentPorcess.PaymentPorcessClient(channel);
        }

        public async Task<TransactionResponse> ProcessPaymentAsync(int clientId, double amount)
        {
            var request = new TransactionRequest
            {
                ClientID = clientId,
                Balance = amount
            };

            return await _client.TransactionAsync(request);
        }
    }
}

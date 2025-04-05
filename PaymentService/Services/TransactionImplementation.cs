using Grpc.Core;
using PaymentService;
using PaymentService.Protos;
using System.Transactions;

namespace PaymentService.Services
{
    public class TransactionImplementation : PaymentPorcess.PaymentPorcessBase
    {
        private static List<Client> _clients = new List<Client>
{
    new Client { ClientID = 1, Balance = 0 },
    new Client { ClientID = 2, Balance = 3200 },
    new Client { ClientID = 3, Balance = 2002 },
};


        public override Task<TransactionResponse> Transaction(TransactionRequest request, ServerCallContext context)
        {
            var client = _clients.FirstOrDefault(c => c.ClientID == request.ClientID);

            if (client != null)
            {
                if (client.Balance >= request.Balance)
                {
                    client.Balance -= request.Balance;

                    var response = new TransactionResponse
                    {
                        Success = true
                    };
                    return Task.FromResult(response);
                }
                else
                {
                    var response = new TransactionResponse
                    {
                        Success = false
                    };
                    return Task.FromResult(response);
                }
            }
            else
            {
                var response = new TransactionResponse
                {
                    Success = false
                };
                return Task.FromResult(response);
            }
        }


    }
}


public class Client
{
    public int ClientID { get; set; }
    public double Balance { get; set; }
}

using Grpc.Core;
using InventoryService.Protos;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryService.Services
{
    public class InventService : DeductionProcess.DeductionProcessBase
    {
        private static List<Product> _products = new List<Product>
{
    new Product { ProductId = 1, Price = 100, Quantity = 50 },
    new Product { ProductId = 2, Price = 200, Quantity = 30 },
    new Product { ProductId = 3, Price = 300, Quantity = 20 },
};
        public override Task<DeductionResponse> Deduction(DeductionRequest request, ServerCallContext context)
        {
            var product = _products.FirstOrDefault(p => p.ProductId == request.ProductId);

            if (product == null)
            {
                return Task.FromResult(new DeductionResponse
                {
                    Success = false
                });
            }

            if (product.Quantity >= request.Quantity)
            {
                product.Quantity -= request.Quantity;

                return Task.FromResult(new DeductionResponse
                {
                    Success = true
                });
            }

            return Task.FromResult(new DeductionResponse
            {
                Success = false
            });
        }

    }
}
public class Product
{
    public int ProductId { get; set; }
    public double Price { get; set; }
    public int Quantity { get; set; }
}

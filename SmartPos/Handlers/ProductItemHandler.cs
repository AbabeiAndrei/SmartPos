using System.Threading.Tasks;

using SmartPos.DomainModel.Entities;

namespace SmartPos.Desktop.Handlers
{
    public delegate Task ProductItemHandler(object sender, IProductItemArgs args);

    public class ProductItemArgs : IProductItemArgs
    {
        public Product Product { get; }

        public float Quantity { get; set; }

        public ProductItemArgs(Product product, float quantity = 1f)
        {
            Product = product;
            Quantity = quantity;
        }
    }
    
    public interface IProductItemArgs
    {
        float Quantity { get; }
        Product Product { get; }
    }
}

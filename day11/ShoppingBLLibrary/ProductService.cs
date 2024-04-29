using ShoppingDALLibrary;
using ShoppingModelLibrary;
using ShoppingModelLibrary.Exceptions;
using System.Threading.Tasks;

namespace ShoppingBLLibrary
{
    public class ProductService
    {
        private ProductRepository productRepository;

        public ProductService()
        {
            productRepository = new ProductRepository();
        }

        public async Task<Product> GetProductByIdAsync(int productId)
        {
            return await productRepository.GetByKeyAsync(productId);
        }
    }
}


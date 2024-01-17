using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;
using UseCases.UseCaseInterfaces;

namespace UseCases.ProductUseCases
{
    public class SellProductUseCase : ISellProductUseCase
    {
        private readonly IProductRepository _productRepository;
        private readonly IRecordTransactionUseCase _recordTransactionUseCase;

        public SellProductUseCase(IProductRepository productRepository,IRecordTransactionUseCase recordTransactionUseCase)
        {
            _productRepository = productRepository;
            _recordTransactionUseCase = recordTransactionUseCase;
        }
        public void Execute(string cashierName,int productId, int qtyToSell, int pts, string firstName, string lastName, string address, string city,
    string postalCode, string phone, string UserId)
        {
            var product = _productRepository.GetProductById(productId);
            if (product == null) return;
            _recordTransactionUseCase.Execute(cashierName, productId, qtyToSell, pts, firstName, lastName, address,
        city, postalCode, phone, UserId);
            product.Quantity -= qtyToSell;
            _productRepository.UpdateProduct(product);
            

        }
    }
}

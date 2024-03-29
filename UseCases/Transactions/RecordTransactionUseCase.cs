﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;
using UseCases.UseCaseInterfaces;

namespace UseCases.Transactions
{
    public class RecordTransactionUseCase : IRecordTransactionUseCase
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IGetProductByIdUseCase _getProductByIdUseCase;

        public RecordTransactionUseCase(ITransactionRepository transactionRepository, IGetProductByIdUseCase getProductByIdUseCase)
        {
            _transactionRepository = transactionRepository;
            _getProductByIdUseCase = getProductByIdUseCase;
        }
        public void Execute(string cashierName, int productId, int qty, int pts, string firstName, string lastName, string address, string city,
    string postalCode, string phone, string UserId)
        {

            var product = _getProductByIdUseCase.Execute(productId);
            _transactionRepository.Save(cashierName, productId, product.Name, 
                product.Price.Value, product.Quantity.Value, qty, product.Points.Value,
                product.Points.Value, pts, firstName, lastName, address,
        city, postalCode, phone,  UserId);
        }
    }
}

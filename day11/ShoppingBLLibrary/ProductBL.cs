﻿using ShoppingDALLibrary;
using ShoppingModelLibrary;
using ShoppingModelLibrary.Exceptions;
using System.Collections.Generic;

namespace ShoppingBLLibrary
{
    public class ProductBL
    {
        private ProductRepository productRepository;

        public ProductBL()
        {
            productRepository = new ProductRepository();
        }

        public async Product AddProduct(string name, decimal price)
        {
            // You can add additional validation logic here if needed
            Product newProduct = new Product { Id = GenerateProductId(), Name = name, Price = (double)price };
            productRepository.Add(newProduct);
            return newProduct;
        }

        public async Product GetProductById(int id)
        {
            return productRepository.GetByKey(id);
        }
        public async Product UpdateProduct(int id, string name, decimal price)
        {
            // You can add additional validation logic here if needed
            Product updatedProduct = new Product { Id = id, Name = name, Price = (double)price };
            return productRepository.Update(updatedProduct);
        }

        public async bool DeleteProduct(int id)
        {
            Product deletedProduct = productRepository.Delete(id);
            return deletedProduct != null;
        }

        private async int GenerateProductId()
        {
            Random random = new Random();
            return random.Next(1000, 9999);
        }
    }
}

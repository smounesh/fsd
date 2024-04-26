using NUnit.Framework;
using ShoppingDALLibrary;
using ShoppingModelLibrary;
using System.Collections.Generic;

namespace ShoppingDALL.Tests
{
    [TestFixture]
    public class ProductRepositoryTests
    {
        private ProductRepository repository;

        [SetUp]
        public void Setup()
        {
            // Initialize the repository with some sample data
            repository = new ProductRepository();
            repository.Add(new Product { Id = 1, Name = "Product 1", Price = 10 });
            repository.Add(new Product { Id = 2, Name = "Product 2", Price = 20 });
            repository.Add(new Product { Id = 3, Name = "Product 3", Price = 30 });
        }

        [Test]
        public void Add_Product_Valid()
        {
            // Arrange
            Product newProduct = new Product { Id = 4, Name = "New Product", Price = 40 };

            // Act
            repository.Add(newProduct);

            // Assert
            Product retrievedProduct = repository.GetByKey(4);
            Assert.AreEqual(newProduct, retrievedProduct);
        }

        [Test]
        public void GetByKey_Product_Exists()
        {
            // Act
            Product product = repository.GetByKey(1);

            // Assert
            Assert.IsNotNull(product);
            Assert.AreEqual(1, product.Id);
        }

        [Test]
        public void GetByKey_Product_Does_Not_Exist()
        {
            // Assert
            Assert.Throws<ProductNotFoundException>(() => repository.GetByKey(10));
        }



        [Test]
        public void Update_Product_Not_Found()
        {
            // Arrange
            Product updatedProduct = new Product { Id = 10, Name = "Updated Product", Price = 25 };

            // Assert
            Assert.Throws<ProductNotFoundException>(() => repository.Update(updatedProduct));
        }

        [Test]
        public void Delete_Product_Valid()
        {
            // Act
            Product deletedProduct = repository.Delete(3);

            // Assert
            Assert.IsNotNull(deletedProduct);
            Assert.AreEqual(3, deletedProduct.Id);
            Assert.Throws<ProductNotFoundException>(() => repository.GetByKey(3));
        }

        [Test]
        public void Delete_Product_Not_Found()
        {
            // Assert
            Assert.Throws<ProductNotFoundException>(() => repository.Delete(10));
        }
    }
}

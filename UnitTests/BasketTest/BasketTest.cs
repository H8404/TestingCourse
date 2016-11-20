using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BasketNS;
using System.Collections.Generic;

namespace BasketTest
{
    [TestClass]
    public class BasketTest
    {
        List<String> c;
        Basket basket;

        [TestInitialize]
        public void Initialize()
        {
            c = new List<string>(new string[] { "Banaani", "Maito", "Muna" });
            basket = new Basket("Jari", c, 15.0);
        }

        [TestCleanup()]
        public void Cleanup()
        {
            basket = null;
        }

        [TestMethod]
        public void Basket_CustomerIsString()
        {

            Assert.IsInstanceOfType(basket.Customer, typeof(String),"Customer ei ollut string muotoa");
        }

        [TestMethod]
        public void Basket_ContentsIsList()
        {

            Assert.IsInstanceOfType(basket.Contents, typeof( List<String>));
        }

        [TestMethod]
        public void Basket_PriceIsNumber()
        {

            Assert.IsInstanceOfType(basket.Price, typeof(double));
        }

        [TestMethod]
        public void Basket_AddProductIsWorking()
        {

            string newProduct = "Vanukas";
            basket.AddProduct(newProduct, 6.0);
            CollectionAssert.Contains(basket.Contents, newProduct);
        }

        [TestMethod]
        public void Basket_DeleteProductIsWorking()
        {

            string deleteProduct = "Maito";
            basket.DeleteProduct(deleteProduct, 4.5);
            CollectionAssert.DoesNotContain(basket.Contents, deleteProduct, "Korissa ei pitäisi olla tuotetta");
        }
    }
}

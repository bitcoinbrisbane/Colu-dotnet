using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Colu.Client.Tests
{
    [TestClass]
    public class ClientTests
    {
        [TestMethod]
        public void Should_get_address_info()
        {
            //n3TjZPvivsP5xHgRS5zbs83vcYcqDzC8J4
            Models.Settings settings = new Models.Settings() { Network = "Testnet" };
            Client client = new Client(settings);

            Colu.Client.Models.GetAddressResponse actual = client.GetAddressInfoAsync("n3TjZPvivsP5xHgRS5zbs83vcYcqDzC8J4").Result;
            Assert.IsNotNull(actual);
        }
    }
}

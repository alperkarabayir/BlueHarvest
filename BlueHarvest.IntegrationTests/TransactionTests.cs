using BlueHarvest.Api;
using BlueHarvest.Api.Resources;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Xunit;

namespace BlueHarvest.IntegrationTests
{
    public class TransactionTests
    {
        private readonly HttpClient _client;

        public TransactionTests()
        {
            var appFactory = new WebApplicationFactory<Startup>();
            //Arrange
            _client = appFactory.CreateClient();
        }

        [Fact]
        public async Task CreateTransaction_ShouldReturnOK()
        {
            // Create New Customer
            var newCustomer = new SaveCustomerResource() { Name = "Elon", Surname = "Musk" };
            JsonContent contentCustomer = JsonContent.Create(newCustomer);
            // Act Create Customer First
            var response = await _client.PostAsync($"/api/Customers", contentCustomer);
            var createdCusContents = await response.Content.ReadAsStringAsync();
            var createdCustomer = JsonConvert.DeserializeObject<CustomerResource>(createdCusContents);


            //Create New Account
            var newAccount = new SaveAccountResource() { Balance = 20 };
            JsonContent contentAccount = JsonContent.Create(newAccount);
            //Act Create Account
            var createdAccResponse = await _client.PostAsync($"api/Customers/{createdCustomer.Id}/Accounts", contentAccount);
            var createdAccContents = await createdAccResponse.Content.ReadAsStringAsync();
            var createdAcc = JsonConvert.DeserializeObject<AccountResource>(createdAccContents);


            //Create New Transaction
            var newTransaction = new SaveTransactionResource() { Amount = 10 };
            JsonContent createTrxContent = JsonContent.Create(newTransaction);

            //Act Create Transaction
            var createdTrxResponse = await _client.PostAsync($"api/Customers/{createdCustomer.Id}/Accounts/{createdAcc.Id}/Transactions", createTrxContent);
            

            // Assert
            Assert.Equal(HttpStatusCode.OK, createdTrxResponse.StatusCode);
        }
    }
}

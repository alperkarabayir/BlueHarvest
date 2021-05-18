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
    public class AccountTests
    {
        private readonly HttpClient _client;

        public AccountTests()
        {
            var appFactory = new WebApplicationFactory<Startup>();
            //Arrange
            _client = appFactory.CreateClient();
        }

        [Fact]
        public async Task CreateAccount_ShouldReturnCreatedAccount()
        {
            // Create New Customer
            var newCustomer = new SaveCustomerResource() { Name = "Elon", Surname = "Musk" };
            JsonContent content = JsonContent.Create(newCustomer);

            // Act Create Customer First
            var response = await _client.PostAsync($"/api/Customers", content);
            var contents = await response.Content.ReadAsStringAsync();
            var createdCustomer = JsonConvert.DeserializeObject<CustomerResource>(contents);

            //Create New Account
            var newAccount = new SaveAccountResource() { Balance = 20 };
            JsonContent contentAccount = JsonContent.Create(newAccount);

            //Act
            var createdAccResponse = await _client.PostAsync($"api/Customers/{createdCustomer.Id}/Accounts", contentAccount);

            // Assert
            Assert.Equal(HttpStatusCode.OK, createdAccResponse.StatusCode);
        }
    }
}

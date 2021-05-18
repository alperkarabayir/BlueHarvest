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
    public class CustomerTests
    {
        private readonly HttpClient _client;

        public CustomerTests()
        {
            var appFactory = new WebApplicationFactory<Startup>();
            //Arrange
            _client = appFactory.CreateClient();
        }

        [Fact]
        public async Task GetAllCustomer_ShouldReturnCustomerList()
        {
            //Act
            var response = await _client.GetAsync("/api/Customers");

            //Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task CreateCustomer_ShouldReturnNewCustomerData()
        {
            // Create New Customer
            var newCustomer = new SaveCustomerResource() { Name = "Elon", Surname = "Musk" };
            JsonContent content = JsonContent.Create(newCustomer);
            // Act
            var response = await _client.PostAsync($"/api/Customers", content);
            var contents = await response.Content.ReadAsStringAsync();
            var createdCustomer = JsonConvert.DeserializeObject<CustomerResource>(contents);

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal(newCustomer.Name, createdCustomer.Name);
            Assert.Equal(newCustomer.Surname, createdCustomer.Surname);
        }

        [Fact]
        public async Task GetCustomerById_ShouldReturnCustomer()
        {
            //Act
            // Create New Customer
            var newCustomer = new SaveCustomerResource() { Name = "Elon", Surname = "Musk" };
            JsonContent createContent = JsonContent.Create(newCustomer);

            // Act
            var createdResponse = await _client.PostAsync($"/api/Customers", createContent);
            var createdContents = await createdResponse.Content.ReadAsStringAsync();
            var createdCustomer = JsonConvert.DeserializeObject<CustomerResource>(createdContents);

            //Get created user data
            var response = await _client.GetAsync($"/api/Customers/{createdCustomer.Id}");
            var contents = await response.Content.ReadAsStringAsync();
            var customer = JsonConvert.DeserializeObject<CustomerResource>(contents);

            //Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal(customer.Name, createdCustomer.Name);
            Assert.Equal(customer.Surname, createdCustomer.Surname);
        }
    }
}


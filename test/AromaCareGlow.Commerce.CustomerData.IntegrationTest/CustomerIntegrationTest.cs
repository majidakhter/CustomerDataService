using AromaCareGlow.Commerce.CustomerData.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AromaCareGlow.Commerce.CustomerData.IntegrationTest
{
    public class CustomerIntegrationTest: IClassFixture<TestFixture>
    {
        private HttpClient Client { get; }

        public CustomerIntegrationTest(TestFixture fixture)
        {
            Client = fixture.Client;
            Initialize();
        }
        private string customerGetUri = @"v1/Customer/GetCustomerByEmail/{0}";

        private string customerSaveUri = @"v1/Customer/Save";

        private async void Initialize()
        {

        }
        [Fact]
        public async Task GetCustomerByEmail()
        {
            //Arrange
            string request = string.Format(customerGetUri, "xyz@yahoo.com");

            //Act
            var response = await Client.GetAsync(request);

            //Assert
            response.EnsureSuccessStatusCode();
            var data = await response.Content.ReadAsStringAsync();
            Assert.NotNull(data);
            var model = JsonConvert.DeserializeObject<Customer>(data);
            Assert.NotNull(model);
            Assert.Equal("xyz@yahoo.com", model.Email);
            Assert.Equal("xyz@yahoo.com", model.Username);
        }
    }
}

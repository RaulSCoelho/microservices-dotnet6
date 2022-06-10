using GeekShopping.CartAPI.Data.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Http.Headers;
using System.Text.Json;
using TechTalk.SpecFlow;

namespace GeekShopping.CartAPI.Test.StepDefinitions
{
    [Binding]
    public class CartAPIStepDefinitions
    {
        private static MediaTypeHeaderValue contentType
            = new MediaTypeHeaderValue("application/json");
        private string URL = "https://localhost:4445/api/v1/Cart/";
        private readonly ScenarioContext _scenarioContext;

        public CartAPIStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"que o userId do carrinho e (.*)")]
        public void GivenQueOUserIdDoCarrinhoE(string userId)
        {
            _scenarioContext["UserId"] = userId;
        }

        [Given(@"o metodo e (.*)")]
        public void GivenOMetodoE(string method)
        {
            _scenarioContext["Method"] = method;
            string userId = (string)_scenarioContext["UserId"];
            switch (method)
            {
                case "GET":
                    URL += $"find-cart/{userId}";
                    break;
                case "POST":
                    URL += "add-cart";
                    break;
                case "PUT":
                    URL += "update-cart";
                    break;
                case "DELETE":
                    URL += $"remove-cart/{userId}";
                    break;
            }
        }

        [When(@"o metodo for executado")]
        public async Task WhenOMetodoForExecutado()
        {
            string userId = (string)_scenarioContext["UserId"];
            string method = (string)_scenarioContext["Method"];
            var client = new HttpClient();

            switch (method)
            {
                case "GET":
                    string response = await client.GetStringAsync(URL);
                    _scenarioContext["Response"] = response;
                    break;
                case "POST":
                    var cartDetail = new List<CartDetailVO>();
                    cartDetail.Add(new CartDetailVO
                    {
                        Id = 0,
                        CartHeaderId = 0,
                        CartHeader = new CartHeaderVO()
                        {
                            Id = 0,
                            UserId = userId,
                            CouponCode = ""
                        },
                        ProductId = 1,
                        Product = new ProductVO()
                        {
                            Id = 1,
                            Name = "Carne",
                            Price = 39,
                            Description = "Contra filé",
                            CategoryName = "CONTRA FILE",
                            ImageURL = "https://github.com/leandrocgsi/erudio-microservices-dotnet6/blob/main/ShoppingImages/10_milennium_falcon.jpg?raw=true"
                        },
                        Count = 12
                    });

                    var cart = new CartVO()
                    {
                        CartHeader = new CartHeaderVO()
                        {
                            Id = 0,
                            UserId = userId,
                            CouponCode = ""
                        },
                        CartDetails = cartDetail,
                    };

                    var dataAsString = JsonSerializer.Serialize(cart);
                    var content = new StringContent(dataAsString);
                    content.Headers.ContentType = contentType;
                    var result = await client.PostAsync(URL, content);
                    _scenarioContext["Response"] = result;
                    break;
                case "PUT":
                    URL += "update-cart";
                    break;
                case "DELETE":
                    URL += $"remove-cart";
                    break;
            }
        }

        [Then(@"statuscode da resposta devera ser OK")]
        public void ThenStatuscodeDaRespostaDeveraSerOK()
        {
            var response = _scenarioContext["Response"];
            Assert.IsTrue(response != null);
        }
    }
}

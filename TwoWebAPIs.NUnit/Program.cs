using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace TwoWebAPIs.NUnit
{
    public class WebAPITest
    {
        private HttpClient client;

        private HttpResponseMessage response;

        [SetUp]
        public void SetUp()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8383");

            response = client.GetAsync("v1/twowebapis/items/ItemName").Result;

        }

        [Test]
        public void GetResponseSucces()
        {
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [Test]
        public void GetResponseIsJson()
        {
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            Assert.AreEqual("application/json", response.Content.Headers.ContentType.MediaType);
        }
    }
}

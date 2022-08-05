﻿using Microsoft.AspNetCore.Mvc.Testing;
using NST.Simple.Api;
using NUnit.Framework;

namespace IntegrationTest.Controllers.NotificationsController
{
    [TestFixture]
    public class GetSavedMethod
    {
        private readonly HttpClient _httpClient;

        public GetSavedMethod()
        {
            var appFactory = new WebApplicationFactory<Startup>();
            _httpClient = appFactory.CreateClient();
        }

        [Test]
        public async Task GetSaved_NoParametrs_Sesccess()
        {
            //Arrange
            var request = new HttpRequestMessage(HttpMethod.Get, $"/api/Simple/saved");

            //Act
            var response = await _httpClient.SendAsync(request);

            //Assert
            response.EnsureSuccessStatusCode();
            Assert.That(response.Content.ReadAsStringAsync().Result, Is.EqualTo("2"));
        }
    }
}

using CarsManagement.Shared.DTO;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System.Net;
using System.Text;
using CarsManagement.Server.Presentation;
using Xunit.Abstractions;

namespace ControllersTests;

public class AuthControllerIntegrationTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;
    private readonly ITestOutputHelper _output;

    public AuthControllerIntegrationTests(WebApplicationFactory<Program> factory, ITestOutputHelper output)
    {
        _factory = factory;
        _output = output;
    }

    [Fact]
    public async Task Login_ValidCredentials_ReturnsOk()
    {
        // Arrange
        var client = _factory.CreateClient();
        var loginRequest = new LoginRequest("Mick Jagger", "Qwerty123$");
        var content = new StringContent(JsonConvert.SerializeObject(loginRequest), Encoding.UTF8, "application/json");

        // Act
        var response = await client.PostAsync("/auth/login", content);
        var responseContent = await response.Content.ReadAsStringAsync();

        // Log
        _output.WriteLine($"Request: {JsonConvert.SerializeObject(loginRequest)}");
        _output.WriteLine($"Response: {response}");
        _output.WriteLine($"Response Content: {responseContent}");

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async Task Login_InvalidCredentials_ReturnsUnauthorized()
    {
        // Arrange
        var client = _factory.CreateClient();
        var loginRequest = new LoginRequest("invalidUsername", "invalidPassword");
        var content = new StringContent(JsonConvert.SerializeObject(loginRequest), Encoding.UTF8, "application/json");

        // Act
        var response = await client.PostAsync("/auth/login", content);
        var responseContent = await response.Content.ReadAsStringAsync();

        // Log
        _output.WriteLine($"Request: {JsonConvert.SerializeObject(loginRequest)}");
        _output.WriteLine($"Response: {response}");
        _output.WriteLine($"Response Content: {responseContent}");

        // Assert
        Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
    }
}

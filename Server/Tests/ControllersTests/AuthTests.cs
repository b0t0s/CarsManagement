using AutoMapper;
using CarsManagement.Server.Application;
using CarsManagement.Server.Domain.Entities;
using CarsManagement.Server.Presentation;
using CarsManagement.Server.Presentation.Controllers;
using CarsManagement.Shared.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;

namespace ControllersTests
{
    public class AuthTests
    {
        [Fact]
        public async Task Login_ValidCredentials_ReturnsLoginSuccessful()
        {
            // Arrange
            var mockLogger = new Mock<ILogger<AuthController>>();
            var mockRepository = new Mock<IRepository<ManagerModel>>();
            var mockMapper = new Mock<IMapper>();
            var mockOptions = new Mock<IOptions<ApiSettings>>();
            var controller = new AuthController(mockLogger.Object, mockRepository.Object, mockMapper.Object, mockOptions.Object);

            var username = "Mick Jagger";
            var password = "Qwerty123$";
            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);

            mockRepository.Setup(repo => repo.GetItems())
                .Returns(new List<ManagerModel> { new ManagerModel { AccountName = username, PasswordHash = hashedPassword } }.ToList());

            var loginRequest = new LoginRequest(username, password);

            var httpContext = new DefaultHttpContext();
            controller.ControllerContext.HttpContext = httpContext;

            // Act
            var result = await controller.Login(loginRequest) as ObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
            Assert.Equal("Login successful", result.Value);
        }

        [Fact]
        public async Task Login_InvalidCredentials_ReturnsUnauthorized()
        {
            // Arrange
            var mockLogger = new Mock<ILogger<AuthController>>();
            var mockRepository = new Mock<IRepository<ManagerModel>>();
            var mockMapper = new Mock<IMapper>();
            var mockOptions = new Mock<IOptions<ApiSettings>>();
            var controller = new AuthController(mockLogger.Object, mockRepository.Object, mockMapper.Object, mockOptions.Object);

            var username = "invaliduser";
            var password = "invalidpass";
            var loginRequest = new LoginRequest(username, password);

            // Act
            var result = await controller.Login(loginRequest) as ObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(401, result.StatusCode);
            Assert.Equal("Username Incorrect or User is not exist", result.Value);
        }

        [Fact]
        public async Task Register_SuccessfulRegistration_ReturnsOk()
        {
            // Arrange
            var mockLogger = new Mock<ILogger<AuthController>>();
            var mockRepository = new Mock<IRepository<ManagerModel>>();
            var mockMapper = new Mock<IMapper>();
            var mockOptions = new Mock<IOptions<ApiSettings>>();
            var controller = new AuthController(mockLogger.Object, mockRepository.Object, mockMapper.Object, mockOptions.Object);

            var username = "newuser";
            var email = "MoveLikeNoOne@gmail.com";
            var password = "newpass";
            var registerRequest = new RegistrationRequest(username, email, password);

            // Act
            var result = await controller.Register(registerRequest) as OkResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
        }

        [Fact]
        public async Task Register_ExistingUser_ReturnsUserAlreadyExists()
        {
            // Arrange
            var mockLogger = new Mock<ILogger<AuthController>>();
            var mockRepository = new Mock<IRepository<ManagerModel>>();
            var mockMapper = new Mock<IMapper>();
            var mockOptions = new Mock<IOptions<ApiSettings>>();
            var controller = new AuthController(mockLogger.Object, mockRepository.Object, mockMapper.Object, mockOptions.Object);

            var username = "Mick Jagger";  // Assuming this user already exists
            var email = "MoveLikeJagger@gmail.com";
            var password = "newpass";

            var registerRequest = new RegistrationRequest(username, email, password);

            // Act
            var result = await controller.Register(registerRequest) as ObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(401, result.StatusCode);
            Assert.Equal("User already exist", result.Value);
        }

        [Fact]
        public async Task Logout_SuccessfulLogout_ReturnsOk()
        {
            // Arrange
            var mockLogger = new Mock<ILogger<AuthController>>();
            var mockRepository = new Mock<IRepository<ManagerModel>>();
            var mockMapper = new Mock<IMapper>();
            var mockOptions = new Mock<IOptions<ApiSettings>>();
            var controller = new AuthController(mockLogger.Object, mockRepository.Object, mockMapper.Object, mockOptions.Object);

            // Act
            var result = await controller.Logout() as OkResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
        }
    }
}
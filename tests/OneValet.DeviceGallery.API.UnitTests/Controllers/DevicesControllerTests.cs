using AutoMapper;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using OneValet.DeviceGallery.API.Controllers;
using OneValet.DeviceGallery.API.UnitTests.MockData;
using OneValet.DeviceGallery.Application.DTOs.Device;
using OneValet.DeviceGallery.Application.Interfaces;
using OneValet.DeviceGallery.Application.Interfaces.Services;
using OneValet.DeviceGallery.Application.ResourceParameters;
using OneValet.DeviceGallery.Application.Services;
using OneValet.DeviceGallery.Application.Wrappers;
using OneValet.DeviceGallery.Infrastructure.Persistence;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace OneValet.DeviceGallery.API.UnitTests.Controllers
{
    public class DevicesControllerTests
    {
        private readonly DevicesController _controller;
        private readonly Mock<IDeviceService> _service;
        public DevicesControllerTests()
        {
            _service = new Mock<IDeviceService>();
            _controller = new DevicesController(_service.Object);
        }


        [Fact]
        public async Task GetDevicesAsync_ShouldReturn200Status()
        {
            //Arrange
            var devicesResourceParameters = new DevicesResourceParameters()
            {
                Online = "",
                SearchQuery = ""
            };
            var deviceService = new Mock<IDeviceService>();
            deviceService.Setup(_ => _.GetAllDevicesAsync(devicesResourceParameters)).Returns(Task.FromResult(DeviceMockData.GetDevices()));
            var sut = new DevicesController(deviceService.Object);

            //Act
            var result = await sut.GetDevicesAsync(devicesResourceParameters);

            //Assert

            result.GetType().Should().Be(typeof(OkObjectResult));
            (result as OkObjectResult).StatusCode.Should().Be(200);

    }

        [Fact]
        public async Task GetDeviceByIdAsync_ShouldReturn200Status()
        {
            var result = await _controller.GetDeviceByIdAsync(11);
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task GetDeviceByIdAsync_ShouldReturnExactNumberOfDevices()
        {
            //Arrange
            var devicesResourceParameters = new DevicesResourceParameters()
            {
                Online = "",
                SearchQuery = ""
            };   
            _service.Setup(_ => _.GetAllDevicesAsync(devicesResourceParameters)).Returns(Task.FromResult(DeviceMockData.GetDevices()));

            //Act
            var result = await _controller.GetDevicesAsync(devicesResourceParameters);

            //Assert
            var viewResult = Assert.IsType<OkObjectResult>(result);
            var devices = Assert.IsType<Response<IEnumerable<DeviceResponse>>>(viewResult.Value);
            Assert.Equal(2, devices.Data.Count());
        }


        //[Theory]
        //[InlineData("11", "419")]
        //public async Task GetBookByIdTest(string guid1, string guid2)
        //{
        //    //Arrange
        //    var validGuid = Convert.ToInt32(guid1);
        //    var invalidGuid = Convert.ToInt32(guid2);

        //    Mock<IRepositoryProvider> mockRepo = new Mock<IRepositoryProvider>();

        //    var devices = DeviceMockData.GetDevicesEntity();

        //    mockRepo.Setup(m => m.DeviceRepository.GetDeviceByIdAsync(validGuid)).Returns(Task.FromResult(devices.First(x=>x.Id == validGuid)));
        //    var mockMapper = new Mock<IMapper>();
        //    _service = new DeviceService(mockRepo.Object, mockMapper.Object);
        //    _controller = new DevicesController(_service);




        //    //Act
        //    var notFoundResult = await _controller.GetDeviceByIdAsync(invalidGuid);
        //    var okResult = await _controller.GetDeviceByIdAsync(validGuid);

        //    //Assert
        //    Assert.IsType<NotFoundResult>(notFoundResult);
        //    Assert.IsType<OkObjectResult>(okResult);


        //    //Now we need to check the value of the result for the ok object result.
        //    var item = okResult as OkObjectResult;

        //    //We Expect to return a single book
        //    Assert.IsType<DeviceGallery.Domain.Entities.Device>(item.Value);

        //    //Now, let us check the value itself.
        //    var bookItem = item.Value as Domain.Entities.Device;
        //    Assert.Equal(validGuid, bookItem.Id);
        //    Assert.Equal("Nokia 7 Plus", bookItem.Name);
        //}

        [Fact]
        public async Task GetDeviceByIdAsync_ExistingIdPassed_ReturnsRightItem()
        {
            // Arrange
            var testId = 9;
            _service.Setup(_ => _.GetDeviceByIdAsync(testId)).Returns(Task.FromResult(new Response<DeviceResponse>(DeviceMockData.GetDevices().Data.First(x=>x.Id ==testId))));
         
            // Act
            var okResult = await _controller.GetDeviceByIdAsync(testId) as OkObjectResult;

            // Assert
            okResult.GetType().Should().Be(typeof(OkObjectResult));
            (okResult as OkObjectResult).StatusCode.Should().Be(200);

            Assert.IsType<Response<DeviceResponse>>(okResult.Value);

            var value = okResult.Value as Response<DeviceResponse>;

            Assert.Equal(testId, value.Data.Id);
        }


        [Fact]
        public async Task AddDeviceAsync_ShouldCallAddDeviceAsyncOnce()
        {
            //Arrange
            var deviceService = new Mock<IDeviceService>();
            var newDevice = DeviceMockData.AddDevice();
            var sut = new DevicesController(deviceService.Object);

            //Act
            var result = await sut.AddDeviceAsync(newDevice);
            var created = result as CreatedAtActionResult;
            var item = created.Value as DeviceRequest;
            
            
            //Assert
            deviceService.Verify(_ => _.AddDeviceAsync(newDevice), Times.Once());

        }




        [Fact]
        public async Task AddDeviceAsync_ValidObjectPassed_ReturnedResponseHasCreatedItem()
        {
            //Arrange
            var deviceService = new Mock<IDeviceService>();
            var newDevice = DeviceMockData.AddDevice();
            var sut = new DevicesController(deviceService.Object);

            //Act
            var result = await sut.AddDeviceAsync(newDevice);
            var created = result as CreatedAtActionResult;
            var item = created.Value as DeviceRequest;


            //Assert
            Assert.Equal("Nokia 3310", item.Name);

            //deviceService.Verify(_=>_.AddDeviceAsync(newDevice), Times.Once());

        }



        //[Fact]
        //public async Task GetDevices_Returns_The_Correct_Number_Of_Devices()
        //{
        //    //Arrange
        //    int count = 5;
        //    var devicesResourceParameters = new DevicesResourceParameters()
        //    {
        //        Online = "",
        //        SearchQuery = ""
        //    };

        //    //var fakeDevices = A.CollectionOfDummy<DeviceGallery.Domain.Entities.Device>(count).AsEnumerable();   
        //    //Task < Response < IEnumerable < DeviceResponse >>
        //    var fakeDevices = A.CollectionOfDummy<DeviceGallery.Application.DTOs.Device.DeviceResponse>(count).AsEnumerable();
        //    var dataStore = A.Fake<IDeviceService>();

        //    A.CallTo(() =>  dataStore.GetAllDevicesAsync(devicesResourceParameters)).Returns(Task.FromResult(fakeDevices));

        // var controller = new DevicesController(dataStore);

        //    //Act
        //    var actionResult = await controller.GetDevices(devicesResourceParameters);

        //    //Assert
        //    var result =  actionResult.Result as OkObjectResult;
        //}
    }
}

//Arrange
//Act
//Assert 


//GetDevicesAsync
//GetDeviceByIdAsync

//AddDeviceAsync

//UpdateDeviceAsync

//DeleteDeviceAsync
//ToggleDeviceAvailabilityAsync



















//[Theory]
//[InlineData("test@mail.com", "password")]
//public async void LoginReturnsSuccessForValidUser(string email, string password)
//{
//    var authenticateRequest = new AuthenticationRequest { Email = email, Password = password };
//    var authenticateResponse = await _accountService.LoginAsync(authenticateRequest, "0.0.0.1");
//    Assert.IsType<Response<AuthenticationResponse>>(authenticateResponse);
//    Assert.True(authenticateResponse.Succeeded);
//    Assert.True(!string.IsNullOrEmpty(authenticateResponse.Data.JWToken));
//}

//[Theory]
//[InlineData("another1@mail.com", "password")]
//public async void LoginThrowsApiExceptionForInvalidEmail(string email, string password)
//{
//    var authenticateRequest = new AuthenticationRequest { Email = email, Password = password };
//    var exception = await Assert.ThrowsAsync<ApiException>(() => _accountService.LoginAsync(authenticateRequest, "0.0.0.1"));
//    Assert.Equal("Invalid credentials.", exception.Message);
//}

//[Theory]
//[InlineData("test@mail.com", "pass")]
//public async void LoginThrowsApiExceptionForInvalidPassword(string email, string password)
//{
//    var authenticateRequest = new AuthenticationRequest { Email = email, Password = password };
//    var exception = await Assert.ThrowsAsync<ApiException>(() => _accountService.LoginAsync(authenticateRequest, "0.0.0.1"));
//    Assert.Equal("Invalid credentials.", exception.Message);
//}

//[Theory]
//[InlineData("another@mail.com", "password")]
//public async void LoginThrowsApiExceptionForUnconfirmedAccount(string email, string password)
//{
//    var authenticateRequest = new AuthenticationRequest { Email = email, Password = password };
//    var exception = await Assert.ThrowsAsync<ApiException>(() => _accountService.LoginAsync(authenticateRequest, "0.0.0.1"));
//    Assert.Equal($"Account not confirmed for '{email}'.", exception.Message);
//}
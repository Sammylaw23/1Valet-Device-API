using AutoMapper;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Moq;
using OneValet.DeviceGallery.API.UnitTests.MockData;
using OneValet.DeviceGallery.Application.Interfaces;
using OneValet.DeviceGallery.Application.ResourceParameters;
using OneValet.DeviceGallery.Application.Services;
using OneValet.DeviceGallery.Domain.Entities;
using OneValet.DeviceGallery.Infrastructure.Contexts;
using OneValet.DeviceGallery.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace OneValet.DeviceGallery.API.UnitTests.Services
{
    public class DeviceServiceTest : IDisposable
    {
        private readonly DeviceDbContext _dbContext;
        private IRepositoryProvider _repository;
        public DeviceServiceTest()
        {
            var options = new DbContextOptionsBuilder<DeviceDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            _dbContext = new DeviceDbContext(options);
            _dbContext.Database.EnsureCreated();
            _repository = new RepositoryProvider(_dbContext);
        }

        //[Fact]
        //public async Task GetAllDevicesAsync_ReturnsDeviceCollection()
        //{
        //    ///Arrange
        //    var devicesResourceParameters = new DevicesResourceParameters()
        //    {
        //        IsOnline = "",
        //        SearchQuery = ""
        //    };

        //    _dbContext.Devices.AddRange(DeviceMockData.GetDevicesEntity());
        //    _dbContext.SaveChanges();


        //    Mock<IRepositoryProvider> mockRepo = new Mock<IRepositoryProvider>();

        //    var devices = new List<Device>
        //    {
        //          new Device {
        //            Id = 11,
        //            Name = "Nokia 7 Plus",
        //            TemperatureC =  49,
        //            IconBase64String = "FLKLihJHggJJKklKOhjGJkjKLkLJKjhjHHkhhjgJKJLklkh",
        //            IsOnline = true
        //          },
        //          new Device {
        //              Id=12,
        //            Name = "iPad 11",
        //            TemperatureC =  67,
        //            IconBase64String = "FLKLihJHggJJKklKOhjGJkjKLkLJKjhjHHkhhjgJKJLklkh",
        //            IsOnline = false
        //          },
        //          new Device {
        //              Id=13,
        //            Name = "HP Elitebook",
        //            TemperatureC =  72,
        //            IconBase64String = "FLKLihJHggJJKklKOhjGJkjKLkLJKjhjHHkhhjgJKJLklkh",
        //            IsOnline = false
        //          }
        //    };

        //    mockRepo.Setup(m => m.DeviceRepository.GetAllDeviceAsync(devicesResourceParameters)).Returns(Task.FromResult(devices.AsEnumerable()));
        //    //mockRepo.Setup(m => m.DeviceRepository.GetAllDeviceAsync()).Returns(Task.FromResult(DeviceMockData.GetDevicesEntity().AsEnumerable()));

        //    var mockMapper = new Mock<IMapper>();

        //    var sut = new DeviceService(mockRepo.Object, mockMapper.Object);

        //    ///Act
        //    var result = await sut.GetAllDevicesAsync(devicesResourceParameters);

        //    //Assert
        //    //result.Data.Should().HaveCount(x=>x >= 0);
        //    result.Data.Should().HaveCount(DeviceMockData.GetDevicesEntity().Count);
        //}



        public void Dispose()
        {
            _dbContext.Database.EnsureDeleted();
            _dbContext.Dispose();
        }
    }
}

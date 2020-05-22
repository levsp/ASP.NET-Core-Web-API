using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebApi.Controllers;
using WebApi.Services.Interfaces;
using WebApiLogger;
using Xunit;

namespace XUnitTestWebApi
{
    public class TodoTasksControllerTest
    {
        TodoTasksController _controller;
        ITodoTaskService _service;
        IMapper _mapper;
        ILoggerWebApi _logger;

        public TodoTasksControllerTest()
        {
            _service = new TodoTaskServiceFake();
            _controller = new TodoTasksController(_service, _mapper, _logger);
        }

        [Fact]
        public void Remove_NotExistingIdPassed_ReturnsNotFoundResponse()
        {
            // Arrange
            var notExistingId = -1;

            // Act
            var badResponse = _controller.Delete(notExistingId);

            // Assert
            Assert.IsType<NotFoundObjectResult>(badResponse);
        }

        [Fact]
        public void Remove_ExistingIdPassed_ReturnsOkResult()
        {
            // Arrange
            var existingGuid = 1;

            // Act
            var okResponse = _controller.Delete(existingGuid);

            // Assert
            Assert.IsType<NoContentResult>(okResponse);
        }
        [Fact]
        public void Remove_ExistingIdPassed_RemovesOneItem()
        {
            // Arrange
            var existingId = 2;

            // Act
            var okResponse = _controller.Delete(existingId);

            // Assert
            Assert.Equal(2, _service.GetAll().Count());
        }
    }
}

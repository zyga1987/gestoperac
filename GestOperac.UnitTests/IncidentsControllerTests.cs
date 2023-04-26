using GestOperac.Api.Repositories;
using GestOperac.Api.Controllers;
using GestOperac.Api.Models;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;
using System;

namespace GestOperac.UnitTests;
public class IncidentsControllerTests
{

    private readonly Mock<IIncidentsRepository> repositoryStub = new();

    private readonly Mock<ILogger<IncidentsController>> loggerStub =  new();

    [Fact]
    public async Task GetIncidentAsync_WithUnexistingIncident_ReturnsNotFound()
    {
        // Arrange
        repositoryStub.Setup(repo => repo.GetIncidentAsync(It.IsAny<Guid>()))
            .ReturnsAsync((Incident)null);
        

        var controller = new IncidentsController(repositoryStub.Object, loggerStub.Object); 
        
        // Act
        var result = await controller.GetIncidentAsync(Guid.NewGuid());

        // Assert 
        Assert.IsType<NotFoundResult>(result.Result); 

    }

        [Fact]
    public async Task GetIncidentAsync_WithExistingIncident_ReturnsExpectedItem()
    {
        // Arrange

        // Act

        // Assert
    }

    private IncidentsControllerTests CreateRandonIncident()
    {
        return new()
        {
            Id = Guid.NewGuid();
            
        }
    }
}
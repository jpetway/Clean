using Moq;
using Clean.Application.Services;
using Clean.Application.DTOs;
using Clean.Domain.Entities;
using Clean.Domain.Interfaces;
using System;

namespace Clean.Application.Test;

public class PersonServiceTests
{
    private readonly Mock<IPersonRepository> _mockRepo;
    private readonly PersonService _personService;

    public PersonServiceTests()
    {
        _mockRepo = new Mock<IPersonRepository>();
        _personService = new PersonService(_mockRepo.Object );
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnPerson()
    {
        // Arrange
        var person = new PersonEntity { Id = 1, FirstName = "John", LastName = "Doe", IsDeleted = false };
        _mockRepo.SetupGet(repo => repo.GetById(1)).Returns(Task.FromResult(person));

        // Act
        var result = await _personService.GetByIdAsync(1);

        // Assert
        _mockRepo.Verify(repo => repo.GetById(1), Times.Once());
        Assert.NotNull(result);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldFail()
    {
        // Arrange
        _mockRepo.SetupGet(repo => repo.GetById(999)).Returns(Task.FromResult((PersonEntity)null));

        // Act & Assert
        await Assert.ThrowsAsync<NullReferenceException>(() => _personService.GetByIdAsync(999));
    }


    [Fact]
    public async Task GetAllAsync_ShouldReturnAllPersons()
    {
        // Arrange
        var persons = new[] { new PersonEntity { Id = 1, FirstName = "John", LastName = "Doe" } };
        _mockRepo.Setup(repo => repo.GetAll()).Returns(persons);

        // Act
        var result = await _personService.GetAllAsync();

        // Assert
        _mockRepo.Verify(repo => repo.GetAll(), Times.Once());
        Assert.Single(result);
    }

    [Fact]
    public async Task GetAllAsync_ShoudReturnEmpty()
    {
        // Arrange
        _mockRepo.Setup(repo => repo.GetAll()).Returns(Enumerable.Empty<PersonEntity>());

        // Act
        var result = await _personService.GetAllAsync();

        // Assert
        _mockRepo.Verify(repo => repo.GetAll(), Times.Once());
        Assert.Empty(result);
    }

    [Fact]
    public async Task AddAsync_ShouldAddPerson()
    {
        // Arrange
        var personDto = new PersonDto { FirstName = "John", LastName = "Doe" };
        _mockRepo.Setup(repo => repo.Add(It.IsAny<PersonEntity>())).Returns(Task.CompletedTask);

        // Act
        await _personService.AddAsync(personDto);

        // Assert
        _mockRepo.Verify(repo => repo.Add(It.IsAny<PersonEntity>()), Times.Once());
    }

    [Fact]
    public async Task AddAsync_ShouldFail()
    {
        // Arrange
        _mockRepo.Setup(repo => repo.Add(null)).Returns(Task.CompletedTask);

        // Act & Assert
        await Assert.ThrowsAsync<NullReferenceException>(() => _personService.AddAsync(null));
    }

    [Fact]
    public async Task UpdateAsync_ShouldUpdate()
    {
        // Arrange
        var personDto = new PersonDto { Id = 1, FirstName = "John", LastName = "Doe" };
        _mockRepo.Setup(repo => repo.Update(It.IsAny<PersonEntity>())).Returns(Task.CompletedTask);

        // Act
        await _personService.UpdateAsync(personDto);

        // Assert
        _mockRepo.Verify(repo => repo.Update(It.IsAny<PersonEntity>()), Times.Once());
    }

    [Fact]
    public async Task UpdateAsync_ShouldFail()
    {
        // Arrange
        _mockRepo.Setup(repo => repo.Update(null)).Returns(Task.CompletedTask);

        // Act & Assert
        await Assert.ThrowsAsync<NullReferenceException>(() => _personService.UpdateAsync(null));
    }

    [Fact]
    public async Task DeleteAsync_ShouldSoftDelete()
    {
        // Arrange
        var personDto = new PersonDto { FirstName = "John", LastName = "Doe" };
        _mockRepo.Setup(repo => repo.Add(It.IsAny<PersonEntity>())).Returns(Task.CompletedTask);
        _mockRepo.Setup(repo => repo.Delete(1)).Returns(Task.CompletedTask);

        // Act
        await _personService.DeleteAsync(1);

        // Assert
        _mockRepo.Verify(repo => repo.Delete(1), Times.Once());
    }

}
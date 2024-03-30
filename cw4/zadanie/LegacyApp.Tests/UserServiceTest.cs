using System;
using JetBrains.Annotations;
using LegacyApp;
using Xunit;

namespace LegacyApp.Tests;

[TestSubject(typeof(UserService))]
public class UserServiceTest
{

    [Fact]
    public void AddUser_Should_Return_False_When_Email_Without_At_And_Dot()
    {
        //Arrange
        string firstName = "John";
        string lastname = "Doe";
        DateTime birthDate = new DateTime(1988, 1, 1);
        int clientId = 1;
        string email = "doe";
        var service = new UserService();
        
        //Act
        bool result = service.AddUser(firstName, lastname, email, birthDate, clientId);

        //Assert
        Assert.Equal(false,result);
    }
    
    [Fact]
    public void AddUser_Should_Return_False_When_Younger_Than_21()
    {
        //Arrange
        var service = new UserService();
        
        //Act
        var result = service.AddUser("John", "Doe", "@.",
            new DateTime(2012, 1, 1), 1);
        
        //Assert
        Assert.Equal(false,result);
    }

    [Fact]
    public void AddUser_Should_Return_False_When_Name_Null_Or_Empty()
    {
        //Arrange
        var service = new UserService();
        
        //Act
        var result = service.AddUser("", "", "@.",
            new DateTime(1988, 1, 1), 1);
        
        //Assert
        Assert.Equal(false,result);
    }

    [Fact]
    public void AddUser_Should_Return_False_When_Normal_Client_With_No_Credit_Limit()
    {
        //Arrange
        var service = new UserService();
        
        //Act
        var result = service.AddUser("John", "Kowalski", "@.",
            new DateTime(1988, 1, 1), 1);
        
        //Assert
        Assert.Equal(false,result);
    }

    [Fact]
    public void Add_User_Should_Return_True_When_Very_Important_Client()
    {
        //Arrange
        var service = new UserService();
        
        //Act
        var result = service.AddUser("John", "Malewski", "@.",
            new DateTime(1988, 1, 1), 2);
        
        //Assert
        Assert.Equal(true,result);
    }
    
    [Fact]
    public void Add_User_Should_Return_True_When_Important_Client()
    {
        //Arrange
        var service = new UserService();
        
        //Act
        var result = service.AddUser("John", "Doe", "@.",
            new DateTime(1988, 1, 1), 4);
        
        //Assert
        Assert.Equal(true,result);
    }

    [Fact] public void Add_User_Should_Return_True_When_Normal_Client()
    {
        //Arrange
        var service = new UserService();
        
        //Act
        var result = service.AddUser("John", "Kwiatkowski", "@.",
            new DateTime(1988, 1, 1), 5);
        
        //Assert
        Assert.Equal(true,result);
    }
    
}
using System.Net;
using System.Text;
using System.Text.Json;
using FluentAssertions;
using FluentAssertions.Execution;
using USP.BaseTests;
using USP.BaseTests.Builders.Commands;
using USP.BaseTests.Builders.Dto;

namespace USP.UnitTests.Products.Commands;

    public class CreateProductTests : Base
{
    [Fact]
    public async Task CreateProductCommand_PriceNegative_Product_ProductCreated()
    {
        //Given (Arrange) - what is part of request
        var dto = new EditProductDtoBuilder()
            .WithName("Sir")
            .WithDescription("Švajcarski Švajcarski ŠvajcarskiŠvajcarski Švajcarski")
            .WithPrice(-5)
            .WithCategory("0")
            .Build();

        var command = new EditProductCommandBuilder()
            .WithDto(dto)
            .Build();
        
        var json = JsonSerializer.Serialize(command);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        //When (Act) - what we do with that data
        var response = await AnonymousClient.PostAsync("api/Product/Create", content);

        //Then (Assert) - what is response
        using var _ = new AssertionScope();
    
        response.Should().NotBeNull();
        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        var responseContent = await response.Content.ReadAsStringAsync();
        responseContent.Should().Contain("Price' must be greater than '0'");
    }
    [Fact]
    public async Task CreateProductCommand_PriceZero_Product_ProductCreated()
    {
        //Given (Arrange) - what is part of request
        var dto = new EditProductDtoBuilder()
            .WithName("Sir")
            .WithDescription("Švajcarski Švajcarski ŠvajcarskiŠvajcarski Švajcarski")
            .WithPrice(0)
            .WithCategory("0")
            .Build();

        var command = new EditProductCommandBuilder()
            .WithDto(dto)
            .Build();
        
        var json = JsonSerializer.Serialize(command);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        //When (Act) - what we do with that data
        var response = await AnonymousClient.PostAsync("api/Product/Create", content);

        //Then (Assert) - what is response
        using var _ = new AssertionScope();
    
        response.Should().NotBeNull();
        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        var responseContent = await response.Content.ReadAsStringAsync();
        responseContent.Should().Contain("Price' must be greater than '0'");
    }
}
using USP.Application.Common.Dto;

namespace USP.BaseTests.Builders.Dto;

public class EditProductDtoBuilder
{
    public string _name = "-";
    public string _description = "-";
    public decimal _price = 0;
    private string? _id;
    
    public EditProductDto Build() => new EditProductDto(_name, _description, _price, _id);

    public EditProductDtoBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public EditProductDtoBuilder WithDescription(string description)
    {
        _description = description;
        return this;
    }

    public EditProductDtoBuilder WithPrice(decimal price)
    {
        _price = price;
        return this;
    }

    public EditProductDtoBuilder WithId(string? id)
    {
        _id = id;
        return this;
    }
}
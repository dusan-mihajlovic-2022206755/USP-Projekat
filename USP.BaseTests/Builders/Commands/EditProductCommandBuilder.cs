using USP.Application.Common.Dto;
using USP.Application.Products.Commands;
using USP.Application.Users.Commands;
using USP.BaseTests.Builders.Dto;

namespace USP.BaseTests.Builders.Commands;

public class EditProductCommandBuilder
{
    private EditProductDto _dto = new EditProductDtoBuilder().Build();

    public EditProductCommand Build() => new(_dto);

    public EditProductCommandBuilder WithDto(EditProductDto dto)
    {
        _dto = dto;
        return this;
    }
}
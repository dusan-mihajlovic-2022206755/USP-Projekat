using Microsoft.AspNetCore.Mvc;
using USP.API.Services;
using USP.Application.Products.Commands;
using USP.Application.Products.Queries;

namespace USP.API.Controllers;

public class ProductController(IUserService userService, IProductService productService) : ApiBaseController
{
    [HttpGet]
    public async Task<ActionResult> Get([FromQuery] GetOneProductQuery query) => Ok(await Mediator.Send(query));

    [HttpGet]
    public async Task<ActionResult> GetAll() => Ok(await Mediator.Send(new GetAllProductQuery()));

    [HttpPost]
    public async Task<ActionResult> Create(CreateProductCommand command) => Ok(await Mediator.Send(command));
    [HttpPost]
    public async Task<ActionResult> Edit(EditProductCommand command) => Ok(await Mediator.Send(command));
}
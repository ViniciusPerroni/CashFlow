using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using User = CashFlow.Application.Identification.UseCases.User;

namespace CashFlow.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly User.Create.IUseCase createUseCase;
        private readonly User.Delete.IUseCase deleteUseCase;
        private readonly User.Edit.IUseCase editUseCase;
        private readonly User.GetById.IUseCase getByIdUseCase;
        private readonly User.List.IUseCase listUseCase;

        public UserController(User.Create.IUseCase createUseCase, User.Delete.IUseCase deleteUseCase,
            User.Edit.IUseCase editUseCase, User.GetById.IUseCase getByIdUseCase, User.List.IUseCase listUseCase)
        {
            this.createUseCase = createUseCase;
            this.deleteUseCase = deleteUseCase;
            this.editUseCase = editUseCase;
            this.getByIdUseCase = getByIdUseCase;
            this.listUseCase = listUseCase;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] User.Create.Request request)
        {
            var response = await createUseCase.Execute(request);
            if (!response.Ok)
                return BadRequest(response);

            return Ok(response);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var request = new User.Delete.Request { Id = id };
            var response = await deleteUseCase.Execute(request);
            if (!response.Ok)
                return BadRequest(response);

            return Ok(response);
        }

        [HttpPut("edit")]
        public async Task<IActionResult> Edit([FromBody] User.Edit.Request request)
        {
            var response = await editUseCase.Execute(request);
            if (!response.Ok)
                return BadRequest(response);

            return Ok(response);
        }

        [HttpGet("get-by-id/{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var request = new User.GetById.Request { Id = id };
            var response = await getByIdUseCase.Execute(request);
            if (!response.Ok)
                return NotFound(response);

            return Ok(response);
        }

        [HttpGet("list-all")]
        public async Task<IActionResult> ListUsers(int pageNumber, int pageSize)
        {
            var summary = new Application.lib.PageSummary { PageNumber = pageNumber, PageSize = pageSize };
            var request = new User.List.Request { Summary = summary };
            var response = await listUseCase.Execute(request);
            if (!response.Ok)
                return BadRequest(response);

            return Ok(response);
        }
    }
}

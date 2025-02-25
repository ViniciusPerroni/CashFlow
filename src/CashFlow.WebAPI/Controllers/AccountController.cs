using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Account = CashFlow.Application.Accounting.UseCases.Account;

namespace CashFlow.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AccountController : ControllerBase
    {
        private readonly Account.Create.IUseCase createUseCase;
        private readonly Account.Delete.IUseCase deleteUseCase;
        private readonly Account.Edit.IUseCase editUseCase;
        private readonly Account.GetById.IUseCase getByIdUseCase;
        private readonly Account.List.IUseCase listUseCase;

        public AccountController(Account.Create.IUseCase createUseCase, Account.Delete.IUseCase deleteUseCase, 
            Account.Edit.IUseCase editUseCase, Account.GetById.IUseCase getByIdUseCase, Account.List.IUseCase listUseCase)
        {
            this.createUseCase = createUseCase;
            this.deleteUseCase = deleteUseCase;
            this.editUseCase = editUseCase;
            this.getByIdUseCase = getByIdUseCase;
            this.listUseCase = listUseCase;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] Account.Create.Request request)
        {
            var response = await createUseCase.Execute(request);
            if (!response.Ok)
                return BadRequest(response);

            return Ok(response);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var request = new Account.Delete.Request { Id = id };
            var response = await deleteUseCase.Execute(request);
            if (!response.Ok)
                return BadRequest(response);

            return Ok(response);
        }

        [HttpPut("edit")]
        public async Task<IActionResult> Edit([FromBody] Account.Edit.Request request)
        {
            var response = await editUseCase.Execute(request);
            if (!response.Ok)
                return BadRequest(response);

            return Ok(response);
        }

        [HttpGet("get-by-id/{id}")]
        public async Task<IActionResult> GetById(long id)
        { 
            var request = new Account.GetById.Request { Id = id };
            var response = await getByIdUseCase.Execute(request);
            if (!response.Ok)
                return NotFound(response);

            return Ok(response);
        }

        [HttpGet("list-all")]
        public async Task<IActionResult> ListAccounts(int pageNumber, int pageSize)
        {
            var summary = new Application.lib.PageSummary { PageNumber = pageNumber, PageSize = pageSize };
            var request = new Account.List.Request { Summary = summary };
            var response = await listUseCase.Execute(request);
            if (!response.Ok)
                return BadRequest(response);

            return Ok(response);
        }
    }
}

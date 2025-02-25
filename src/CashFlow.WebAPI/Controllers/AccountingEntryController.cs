using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using AccountingEntry = CashFlow.Application.Accounting.UseCases.AccountingEntry;

namespace CashFlow.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AccountingEntryController : ControllerBase
    {
        private readonly AccountingEntry.Create.IUseCase createUseCase;
        private readonly AccountingEntry.Delete.IUseCase deleteUseCase;
        private readonly AccountingEntry.GetById.IUseCase getByIdUseCase;
        private readonly AccountingEntry.List.IUseCase listUseCase;

        public AccountingEntryController(AccountingEntry.Create.IUseCase createUseCase, AccountingEntry.Delete.IUseCase deleteUseCase,
            AccountingEntry.GetById.IUseCase getByIdUseCase, AccountingEntry.List.IUseCase listUseCase)
        {
            this.createUseCase = createUseCase;
            this.deleteUseCase = deleteUseCase;
            this.getByIdUseCase = getByIdUseCase;
            this.listUseCase = listUseCase;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] AccountingEntry.Create.Request request)
        {
            var response = await createUseCase.Execute(request);
            if (!response.Ok)
                return BadRequest(response);

            return Ok(response);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var request = new AccountingEntry.Delete.Request { Id = id };
            var response = await deleteUseCase.Execute(request);
            if (!response.Ok)
                return BadRequest(response);

            return Ok(response);
        }

        [HttpGet("get-by-id/{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var request = new AccountingEntry.GetById.Request { Id = id };
            var response = await getByIdUseCase.Execute(request);
            if (!response.Ok)
                return NotFound(response);

            return Ok(response);
        }

        [HttpGet("list-all")]
        public async Task<IActionResult> ListEntries(int pageNumber, int pageSize)
        {
            var summary = new Application.lib.PageSummary { PageNumber = pageNumber, PageSize = pageSize };
            var request = new AccountingEntry.List.Request { Summary = summary };
            var response = await listUseCase.Execute(request);
            if (!response.Ok)
                return BadRequest(response);

            return Ok(response);
        }
    }
}
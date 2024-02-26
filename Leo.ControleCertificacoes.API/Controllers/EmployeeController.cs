using Leo.ControleCertificacoes.API.Controllers.Base;
using Leo.ControleCertificacoes.Core.Application.Dtos.Employee;
using Leo.ControleCertificacoes.Core.Services.Interfaces;

using Microsoft.AspNetCore.Mvc;

namespace Leo.ControleCertificacoes.API.Controllers
{
    public class EmployeeController : BaseAppController
    {
        private readonly IEmployeeService _service;

        public EmployeeController(IEmployeeService service)
        {
            _service = service;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<EmployeeDto>> GetById(Guid id)
        {
            var dto = await _service.GetByIdAsync(id);

            if (dto is null)
            {
                return NotFound("Anything was found with the given id.");
            }

            return Ok(dto);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<EmployeeDto>> GetByCode(int code)
        {
            var dto = await _service.GetByCodeAsync(code);

            if (dto is null)
            {
                return NotFound("Anything was found with the given code.");
            }

            return Ok(dto);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<EmployeeDto>> Create(EmployeeCreateDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(dto);
            }

            var result = await _service.InsertAsync(dto);

            if (result  is null)
            {
                return BadRequest("Nothing was created because we have a problem in our servers.");
            }

            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<EmployeeDto>> Update(EmployeeDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(dto);
            }

            var result = await _service.UpdateAsync(dto);

            if (result is null)
            {
                return BadRequest("Nothing was updated because we have a problem in our servers.");
            }

            return Ok(result);
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<EmployeeDto>> Delete(EmployeeDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(dto);
            }

            var result = await _service.DeleteAsync(dto);

            if (result == 0)
            {
                return BadRequest("Nothing was deleted because we have a problem in our servers.");
            }

            return Ok("Deleted.");
        }
    }
}

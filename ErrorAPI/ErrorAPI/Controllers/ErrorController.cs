using ErrorAPI.Data;
using ErrorAPI.DTO;
using ErrorAPI.Models;
using ErrorAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ErrorManagerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ErrorsController : ControllerBase
    {
        private readonly IErrorRepository _repository;

        public ErrorsController(IErrorRepository repository)
        {
            _repository = repository;
        }
        [HttpGet("filter")]
        public async Task<IActionResult> GetFilteredErrors([FromQuery] string errorCode = null, [FromQuery] string description = null, [FromQuery] string category = null)
        {
            try
            {
                var errors = await _repository.GetAllErrorsAsync();

                // Filtreleme işlemleri
                if (!string.IsNullOrEmpty(errorCode))
                {
                    errors = errors.Where(e => e.ErrorCode.Contains(errorCode, StringComparison.OrdinalIgnoreCase)).ToList();
                }

                if (!string.IsNullOrEmpty(description))
                {
                    errors = errors.Where(e => e.Description.Contains(description, StringComparison.OrdinalIgnoreCase)).ToList();
                }

                if (!string.IsNullOrEmpty(category))
                {
                    errors = errors.Where(e => e.Category.Contains(category, StringComparison.OrdinalIgnoreCase)).ToList();
                }

                return Ok(errors);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // GET: api/errors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ErrorDto>> GetError(int id)
        {
            var error = await _repository.GetErrorByIdAsync(id);
            if (error == null)
            {
                return NotFound();
            }

            return Ok(new ErrorDto
            {
                Id = error.Id,
                ErrorCode = error.ErrorCode,
                Category = error.Category,
                Description = error.Description
            });
        }

        [HttpGet("byCode")]
        public async Task<IActionResult> GetErrorsByCode([FromQuery] string errorCode)
        {
            var errors = await _repository.GetErrorsByCodeAsync(errorCode);
            return Ok(errors);
        }

        [HttpGet("byDescription")]
        public async Task<IActionResult> GetErrorsByDescription([FromQuery] string description)
        {
            var errors = await _repository.GetErrorsByDescriptionAsync(description);
            return Ok(errors);
        }


        // POST: api/errors/post
        [HttpPost]
        public async Task<ActionResult<ErrorDto>> PostError(ErrorDto errorDTO)
        {
            var error = new Error
            {
                ErrorCode = errorDTO.ErrorCode,
                Category = errorDTO.Category,
                Description = errorDTO.Description
            };

            await _repository.AddErrorAsync(error);

            return CreatedAtAction(nameof(GetError), new { id = error.Id }, errorDTO);
        }

        // PUT: api/errors/put
        [HttpPut("{id}")]
        public async Task<IActionResult> PutError(int id, ErrorDto errorDTO)
        {
            if (id != errorDTO.Id)
            {
                return BadRequest();
            }

            var error = new Error
            {
                Id = errorDTO.Id,
                ErrorCode = errorDTO.ErrorCode,
                Category = errorDTO.Category,
                Description = errorDTO.Description
            };

            var result = await _repository.UpdateErrorAsync(error);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE: api/errors/delete
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteError(int id)
        {
            var result = await _repository.DeleteErrorAsync(id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }

        // GET: api/errors/all
        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<ErrorDto>>> GetAllErrors()
        {
            var errors = await _repository.GetAllErrorsAsync();
            return Ok(errors.Select(e => new ErrorDto
            {
                Id = e.Id,
                ErrorCode = e.ErrorCode,
                Category = e.Category,
                Description = e.Description
            }));
        }


    }
}

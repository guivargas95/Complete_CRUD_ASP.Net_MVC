using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Model.Interfaces.Services;
using Domain.Model.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Application.WebApi.Controller
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ProfessorApiController : ControllerBase
    {
        private readonly IProfessorService _professorService;

        public ProfessorApiController(
            IProfessorService professorService)
        {
            _professorService = professorService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProfessorModel>>> Get()//TODO: adicionar parâmetros de filtro
        {
            var professores = await _professorService.GetAllAsync(orderAscendant: true);

            return Ok(professores);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProfessorModel>> Get(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            var professorModel = await _professorService.GetByIdAsync(id);

            if (professorModel == null)
            {
                return NotFound();
            }

            return Ok(professorModel);
        }

        [HttpPost]
        public async Task<ActionResult<ProfessorModel>> Post([FromBody] ProfessorModel professorModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(professorModel);
            }

            var professorCreated = await _professorService.CreateAsync(professorModel);

            return Ok(professorCreated);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ProfessorModel>> Put(int id, [FromBody] ProfessorModel professorModel)
        {
            if (id != professorModel.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(professorModel);
            }

            try
            {
                await _professorService.EditAsync(professorModel);
            }
            catch (DbUpdateConcurrencyException) //TODO: Tratamento de erro de banco deve ser feito no Repository
            {
                //Pode ser bem melhorado
                return StatusCode(409);
            }

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            await _professorService.DeleteAsync(id);

            return Ok();
        }
    }
}

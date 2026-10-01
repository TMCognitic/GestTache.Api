using Cqs.Abstractions.Results;
using GestTache.Api.Domain.Commands;
using GestTache.Api.Domain.Entities;
using GestTache.Api.Domain.Queries;
using GestTache.Api.Domain.Repositories;
using GestTache.Api.Dtos;
using GestTache.Api.Infrastructure;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GestTache.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TacheController : ControllerBase
    {
        
        private readonly ITacheRepository _tacheRepository;
        private readonly ILogger _logger;

        public TacheController(ITacheRepository tacheRepository, ILogger<TacheController> logger)
        {
            _tacheRepository = tacheRepository;
            _logger = logger;
        }

        // GET: api/<TacheController>
        [HttpGet]
        public IActionResult Get()
        {
            return this.FromResult(_tacheRepository.Execute(new GetTachesQuery()));
        }

        // GET api/<TacheController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return this.FromResult(await _tacheRepository.ExecuteAsync(new GetTacheByIdQuery(id)));
        }

        // POST api/<TacheController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateTacheDto dto)
        {
            return this.FromResult(await _tacheRepository.ExecuteAsync(new CreateTacheCommand(dto.Titre)));
        }

        // PUT api/<TacheController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateTacheDto dto)
        {
            return this.FromResult(_tacheRepository.Execute(new UpdateTacheCommand(id, dto.Titre, dto.Cloturee)));
        }

        // DELETE api/<TacheController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return this.FromResult(_tacheRepository.Execute(new DeleteTacheCommand(id)));
        }

        [HttpPatch("cloture/{id}")]
        public async Task<IActionResult> Cloture(int id)
        {
            return this.FromResult(await _tacheRepository.ExecuteAsync(new ClotureTacheCommand(id)));
        }
    }
}

﻿using Camioneros.Data.Repositorio;
using Camioneros.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Camioneros.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CamionController : ControllerBase
    {
        private readonly InterfaceCamion _RepositorioCamion;

        public CamionController(InterfaceCamion repositorioCamion)
        {
            _RepositorioCamion = repositorioCamion;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCamion()
        {
            return Ok(await _RepositorioCamion.GetAllCamion());
        }

        [HttpGet("{ID}")]
        public async Task<IActionResult> GetCamionDetails(int ID)
        {
            return Ok(await _RepositorioCamion.GetCamion(ID));
        }

        [HttpPost]
        public async Task<IActionResult> CreateCamion([FromBody] Camion camion)
        {
            if (camion == null)

                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _RepositorioCamion.InsertCamion(camion);

            return Created("created", created);

        }

        [HttpPut]
        public async Task<IActionResult> UpdateCamion([FromBody] Camion camion)
        {
            if (camion == null)

                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _RepositorioCamion.UpdateCamion(camion);

            return NoContent();

        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCamionero(int ID)
        {
            await _RepositorioCamion.DeleteCamion(new Camion { ID = ID });

            return NoContent();
        }
    }
}

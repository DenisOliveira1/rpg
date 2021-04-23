using Microsoft.AspNetCore.Mvc;
using Rpg.Dtos;
using Rpg.Models;
using Rpg.Models.Enums;
using Rpg.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rpg.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class CharacterController : ControllerBase
    {
        private readonly ICharacterService _characterService;

        // construtor
        public CharacterController(ICharacterService characterService)
        {
            this._characterService = characterService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> Get() {
            return Ok(await _characterService.GetAllCharacters());
        }

        [HttpGet("Get/{id}")]
        public async Task<IActionResult> GetSingle(int id)
        {
            return Ok(await _characterService.GetCharacterByID(id));
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddCharacter(CharacterDto newCharacter)
        {
            return Ok(await _characterService.AddCharacter(newCharacter));
        }


        [HttpPut("Update")]
        public async Task<IActionResult> UpdateCharacter(CharacterDto newCharacter)
        {
            ServiceResponse<CharacterDto> response = await _characterService.UpdateCharacter(newCharacter);
            
            if (response.Data != null) return Ok(response);
            return NotFound(response);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteCharacter(int id)
        {

            ServiceResponse<CharacterDto> response = await _characterService.DeleteCharacter(id);
            
            if (response.Data != null) return Ok(response);
            return NotFound(response);

        }
    }
}

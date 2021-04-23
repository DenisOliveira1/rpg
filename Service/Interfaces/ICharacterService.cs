using Rpg.Dtos;
using Rpg.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rpg.Service.Interfaces
{
    public interface ICharacterService
    {
        Task<ServiceResponse<List<CharacterDto>>> GetAllCharacters();

        Task<ServiceResponse<CharacterDto>> GetCharacterByID(int id);

        Task<ServiceResponse<CharacterDto>> AddCharacter(CharacterDto newCharacter);

        Task<ServiceResponse<CharacterDto>> UpdateCharacter(CharacterDto updatedCharacter);

        Task<ServiceResponse<CharacterDto>> DeleteCharacter(int id);
    }
}

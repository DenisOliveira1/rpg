using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Rpg.Dtos;
using Rpg.Models;
using Rpg.Models.Enums;
using Rpg.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rpg.Service
{
    public class CharacterService : ICharacterService
    {
        //Banco de dados
        private static List<Character> characters = new List<Character>
        {
            //new Character(),
            //new Character{Id = 1, Name = "Sam", Class = CharacterClass.Archer}
        };
        private readonly IMapper _mapper;

        public CharacterService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<ServiceResponse<CharacterDto>> AddCharacter(CharacterDto newCharacter)
        {
            ServiceResponse<CharacterDto> serviceResponse = new ServiceResponse<CharacterDto>();

            Character character = _mapper.Map<Character>(newCharacter);
            try {
                character.Id = characters.Max(c => c.Id) + 1;
            }
            catch (Exception e) {
                character.Id = 1;
            }

            characters.Add(character);
            serviceResponse.Data = _mapper.Map<CharacterDto>(character);
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<CharacterDto>>> GetAllCharacters()
        {
            ServiceResponse<List<CharacterDto>> serviceResponse = new ServiceResponse<List<CharacterDto>>();
            serviceResponse.Data = characters.Select(c => _mapper.Map<CharacterDto>(c)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<CharacterDto>> GetCharacterByID(int id)
        {
            ServiceResponse<CharacterDto> serviceResponse = new ServiceResponse<CharacterDto>();
            serviceResponse.Data = _mapper.Map<CharacterDto>(characters.FirstOrDefault(c => c.Id == id));
            return serviceResponse;
        }

        public async Task<ServiceResponse<CharacterDto>> UpdateCharacter(CharacterDto updatedCharacter)
        {
            ServiceResponse<CharacterDto> serviceResponse = new ServiceResponse<CharacterDto>();

            try
            {
                Character character = characters.Find(c => c.Id == updatedCharacter.Id);
                character.Name = updatedCharacter.Name;
                character.Class = updatedCharacter.Class;
                character.HitPoints = updatedCharacter.HitPoints;
                character.Strength = updatedCharacter.Strength;
                character.Defense = updatedCharacter.Defense;
                character.Intelligence = updatedCharacter.Intelligence;

                serviceResponse.Data = updatedCharacter;
            }
            catch (Exception e)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = e.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<CharacterDto>> DeleteCharacter(int id)
        {
            ServiceResponse<CharacterDto> serviceResponse = new ServiceResponse<CharacterDto>();

            try{
                Character character = characters.First(c => c.Id == id);
                characters.Remove(character);

                serviceResponse.Data = _mapper.Map<CharacterDto>(character);
            }
            catch (Exception e) {
                serviceResponse.Success = false;
                serviceResponse.Message = e.Message;
            }

            return serviceResponse;
        }
  
    }
}

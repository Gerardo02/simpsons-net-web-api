using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using simpsons_net_web_api.Modules;
using simpsons_net_web_api.Dependencies;

namespace simpsons_net_web_api.Controllers
{
    [Route("simpsons/[controller]")]
    [ApiController]
    public class CharacterController : ICharacter
    {
        List<Character> listOfCharacters => new List<Character>
        {
            new Character
            {
                FirstName = "Homero",
                SecondName = "Jay",
                LastName = "Simpsons",
                Age = 34
            },
            new Character
            {
                FirstName = "Bartolomeo",
                SecondName = "",
                LastName = "Simpsons",
                Age = 10
            },
        };
        [HttpGet("{id}")]
        public Character GetCharacter(int id)
        {
            return listOfCharacters[id];
        }

        [HttpGet]
        public List<Character> GetCharacterList()
        {
            return listOfCharacters;
        }
    }
}
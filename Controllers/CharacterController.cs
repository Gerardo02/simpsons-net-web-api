using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using simpsons_net_web_api.Modules;
using simpsons_net_web_api.Dependencies;
using Microsoft.AspNetCore.Cors;
using System.Data.SqlClient;

namespace simpsons_net_web_api.Controllers
{
    [Route("simpsons/[controller]")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class CharacterController : ICharacter
    {
        List<Character> listOfCharacters => new List<Character>
        {
           
            new Character
            {
                FirstName = "Homero",
                SecondName = "Jay",
                LastName = "Simpson",
                Age = 34,
                Height = 180,
                Weight = 200,
                BirthDate = "12 de mayo de 1956",
                Photo = "",
                Job = "Planta nuclear",
                Description = "Esta gordo y es amarillo"
            },
            new Character
            {
                FirstName = "Bartolomeo",
                SecondName = "",
                LastName = "Simpson",
                Age = 10,
                Height = 20,
                Weight = 150,
                BirthDate = "",
                Photo = "",
                Job = "",
                Description = ""
            },
            new Character
            {
                FirstName = "Marjorie",
                SecondName = "Bouvier",
                LastName = "Simpson",
                Age = 63,
                Height = 2.62128,
                Weight = 150,
                BirthDate = "19 de abril de 1987",
                Photo = "",
                Job = "",
                Description = ""
            },
        };
        string connectionString = @"data source=LAPTOP-K3KG8SGC\SQLEXPRESS; catalog=db_simpsons; user id=simpsons; password=1234";
        [HttpGet("{id}")]
        public Character GetCharacter(int id)
        {
            return listOfCharacters[id];
        }

        [HttpGet]
        public List<Character> GetCharacterList()
        {
            List<Character> characters = new List<Character>();

            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("select * from tbl_characters", conn);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while(reader.Read())
            {
                Character character = new Character
                {
                    Id = reader.GetInt64(reader.GetOrdinal("id")),
                    FirstName = reader.GetString(reader.GetOrdinal("firstName"))
                };
                characters.Add(character);
            }
            conn.Close();
            return characters;
        }
    }
}
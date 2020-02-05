using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokeList.Models
{
    public class Pokemon
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Image { get; set; }
        public string NickName { get; set; }
        public string PokemonName { get; set; }

        public string PokeDexEntry { get; set; }

        

        public string Type { get; set; }

        public List<UserPokemon> UserPokemons { get; set; } = new List<UserPokemon>();




    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PokeList.Models
{
    public class UserPokemon
    {

        public int Id { get; set; }

        public string UserId { get; set; }

        public int PokemonId { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Date Created")]
        public DateTime TimeStamp { get; set; }


        public Pokemon Pokemon { get; set; }

        public ApplicationUser User { get; set; }
    }
}

﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokeList.Models
{
    public class ApplicationUser : IdentityUser
    {
 

        public string FullName {get; set;}

        public bool PokeDex { get; set; }


      

    } }

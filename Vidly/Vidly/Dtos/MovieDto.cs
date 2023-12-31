﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Vidly.Models;
using Vidly.Models.Validation;

namespace Vidly.Dtos
{
    public class MovieDto
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime ReleaseDate { get; set; }

        [Required]
        //[MovieDateAdded]
        public DateTime DateAdded { get; set; }

        [Required]
        //[Stock]
        public int NumberInStock { get; set; }
        public int GenreId { get; set; }
    }
}

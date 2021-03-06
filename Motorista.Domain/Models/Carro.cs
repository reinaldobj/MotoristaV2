﻿using System.ComponentModel.DataAnnotations;

namespace Motorista.Domain.Models
{
    public class Carro
    {
        public int Id { get; set; }
        [Required]
        public string Marca { get; set; }
        [Required]
        public string Modelo { get; set; }
        [Required]
        public string Placa { get; set; }
    }
}

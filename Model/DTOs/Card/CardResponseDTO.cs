﻿using System.ComponentModel.DataAnnotations;
using Model.Interfaces.Card;

namespace Model.DTOs.Card;

public class DeckResponseDTO : DeckDTO, IDeckResponseDTO
{
    [Key]
    [Required]
    public required string Id { get; set; }
}

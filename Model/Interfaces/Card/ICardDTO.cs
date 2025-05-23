﻿namespace Model.Interfaces.Card;

public interface IDeckDTO
{

    string CollectionId { get; set; }

    string Name { get; set; }

    string? Description { get; set; }

    int Number { get; set; }

    string ManaCost { get; set; }

    string Label { get; set; }

    string Code { get; set; }

    bool Foil { get; set; }
}

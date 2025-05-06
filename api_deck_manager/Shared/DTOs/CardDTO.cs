namespace api_deck_manager.Shared.DTOs
{
    public class CardDTO
    {
        public long ColectionId { get; set; }
        public long OwnerId { get; set; }
        public long CustomDeckId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Number { get; set; }
        public string ManaCost { get; set; }
        public string Label { get; set; }
        public string Code { get; set; }
        public bool Foil { get; set; }
    }
}

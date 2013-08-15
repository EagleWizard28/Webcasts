namespace DominionCardTracker.Models.Tables
{
    public class CardModifier
    {
        public int CardModifierID { get; set; }
        public int CardID { get; set; }
        public int ModifierTypeID { get; set; }
        public int? ModifierValue { get; set; }
        public string InstructionText { get; set; }
    }
}

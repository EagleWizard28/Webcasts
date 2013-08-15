namespace DominionCardTracker.Models.Views
{
    public class CardModifierView
    {
        public int CardModifierID { get; set; }
        public int CardID { get; set; }
        public int ModifierTypeID { get; set; }
        public int? ModifierValue { get; set; }
        public string InstructionText { get; set; }
        public string ModifierTypeName { get; set; }
    }
}

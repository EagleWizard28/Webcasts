namespace DominionCardTracker.Models.Tables
{
    public class Card
    {
        public int CardID { get; set; }
        public int CardSetID { get; set; }
        public int CardCost { get; set; }
        public string CardTitle { get; set; }
        public string ImagePath { get; set; }
    }
}

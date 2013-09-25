using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominionCardTracker.Models.Tables;

namespace DominionCardTracker.Models.Views
{
    public class CardView
    {
        public int CardID { get; set; }
        public int CardSetID { get; set; }
        public string CardTitle { get; set; }
        public string ImagePath { get; set; }
        public string CardSetName { get; set; }

        public List<CardModifierView> Modifiers { get; set; }
        public List<Category> Categories { get; set; }
    }
}

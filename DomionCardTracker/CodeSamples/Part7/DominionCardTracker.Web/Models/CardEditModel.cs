using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DominionCardTracker.Models.Tables;
using DominionCardTracker.Models.Views;

namespace DominionCardTracker.Web.Models
{
    public class CardEditModel
    {
        public CardView Card { get; set; }
        public List<SelectListItem> CardSetOptions { get; set; }
        public List<SelectListItem> CardModifierOptions { get; set; }

        public CardEditModel(CardView card, List<CardSet> cardSets, List<ModifierType> cardModifiers)
        {
            CardSetOptions = new List<SelectListItem>();
            CardModifierOptions = new List<SelectListItem>();

            Card = card;

            foreach (var set in cardSets)
            {
                CardSetOptions.Add(new SelectListItem { Text = set.CardSetName, Value = set.CardSetID.ToString() });
            }

            foreach (var mod in cardModifiers)
            {
                CardModifierOptions.Add(new SelectListItem { Text = mod.ModifierTypeName, Value = mod.ModifierTypeID.ToString() });
            }
        }
    }
}
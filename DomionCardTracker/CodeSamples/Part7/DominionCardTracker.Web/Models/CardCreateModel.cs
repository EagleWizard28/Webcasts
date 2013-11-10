using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DominionCardTracker.Models.Tables;

namespace DominionCardTracker.Web.Models
{
    public class CardCreateModel
    {
        public Card NewCard { get; set; }
        public List<SelectListItem> CardSetOptions { get; set; }

        public CardCreateModel(List<CardSet> cardSets)
        {
            CardSetOptions = new List<SelectListItem>();
            NewCard = new Card();

            foreach (var set in cardSets)
            {
                CardSetOptions.Add(new SelectListItem {Text=set.CardSetName, Value=set.CardSetID.ToString()});
            }
        }
    }
}
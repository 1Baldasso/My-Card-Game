using Assets._Scripts.Structures.AbstractClasses.CardProps;
using Assets._Scripts.Cards.Followers;
using Assets._Scripts.Utils;
using System.Collections.Generic;
using System.Linq;
using Assets._Scripts.Managers.GameManagerProps;
using Assets._Scripts.Cards.Followers.PiltoverZaun;

namespace Assets._Scripts.Structures.Classes
{
    public class Deck
    {
        /// <summary>
        /// Codigo do Deck
        /// </summary>
        public string DeckCode;
        /// <summary>
        /// Nome do Deck
        /// </summary>
        public string DeckName;
        /// <summary>
        /// Cartas presentes no deck
        /// </summary>
        private List<Card> Cards;
        /// <summary>
        /// Número atual de cartas no deck
        /// </summary>
        public int Count { get { return this.Cards.Count; } }

        public static Deck Default = new() { Cards = new List<Card> { new VeteranInvestigator(), new CithriaOfCloudField(), new TiannaCrownguard() } };
        /// <summary>
        /// Embaralha cartas no deck
        /// </summary>
        /// <param name="cards">Cartas a serem Embaralhadas no deck</param>
        public void ShuffleCardOnDeck(IEnumerable<Card> cards)
        {
            Cards.AddRange(cards);
            Cards.Shuffle();
        }
        /// <summary>
        /// Compra Cartas
        /// </summary>
        /// <param name="q">Quantidade de cartas compradas</param>
        /// <returns>As cartas compradas</returns>
        public Card DrawCard()
        {
            var card = Cards.Take(1).FirstOrDefault();
            GameManager.Instance.RaiseDrawCard(card);
            Cards.RemoveRange(0, 1);
            return card;
        }
    }
}

using Assets._Scripts.Structures.AbstractClasses;
using Assets._Scripts.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets._Scripts.Structures.Structures
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
        public IEnumerable<Card> DrawCard(int q)
        {
            IEnumerable<Card> cards = Cards.Take(q);
            Cards.RemoveRange(0, q);
            return cards;
        }
    }
}

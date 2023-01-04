using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace Assets._Scripts.Structures.Structures
{
    public static class DeckList
    {
        /// <summary>
        /// Lista com todos os decks cadastrados pelo jogador.
        /// </summary>
        private static IEnumerable<Deck> Decks { get; set; }
        /// <summary>
        /// Seleção de deck.
        /// </summary>
        /// <param name="deckCode">Código do deck a ser buscado.</param>
        /// <returns>Objeto Contendo o deck.</returns>
        public static Deck SelectDeck(string deckCode) => Decks.FirstOrDefault(x => x.DeckCode == deckCode);
        /// <summary>
        /// Adicionar um Deck a lista de Decks.
        /// </summary>
        /// <param name="deck">Deck a ser adicionado na lista de decks.</param>
        /// <exception cref="Exception">Caso o deck não tenha 40 cartas, dispara erro.</exception>
        public static void CreateDeck(Deck deck)
        {
            if (deck.Count != 40)
                throw new Exception("O deck deve ter 40 cartas.");
            Decks.Append(deck);
        }

    }
}

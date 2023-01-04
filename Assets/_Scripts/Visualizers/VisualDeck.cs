using Assets._Scripts.Structures.AbstractClasses;
using Assets._Scripts.Structures.Structures;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._Scripts.Visualizers
{
    public class VisualDeck : MonoBehaviour
    {
        public static void ShowCards(IEnumerable<Card> cards, CardDisplayMode displayMode)
        {
            switch (displayMode)
            {
                case CardDisplayMode.Mulligan:
                    HandleMulligan(cards);
                    break;
                case CardDisplayMode.Predict:
                    HandlePredict(cards);
                    break;
                case CardDisplayMode.Evoke:
                    HandleEvoke(cards);
                    break;
                case CardDisplayMode.Manifest:
                    HandleManifest(cards);
                    break;
                case CardDisplayMode.FromEnemy:
                    HandleFromEnemy(cards);
                    break;
            }
        }

        private static void HandleFromEnemy(IEnumerable<Card> cards)
        {
            throw new NotImplementedException();
        }

        private static void HandleManifest(IEnumerable<Card> cards)
        {
            throw new NotImplementedException();
        }

        private static void HandleEvoke(IEnumerable<Card> cards)
        {
            throw new NotImplementedException();
        }

        private static void HandlePredict(IEnumerable<Card> cards)
        {
            throw new NotImplementedException();
        }

        private static void HandleMulligan(IEnumerable<Card> cards)
        {
            foreach (var card in cards)
            {
                VisualCards.Create(card);
            }
        }
    }
    public enum CardDisplayMode
    {
        Mulligan,
        Predict,
        Evoke,
        Manifest,
        FromEnemy
    }
}
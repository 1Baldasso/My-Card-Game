using Assets._Scripts.Managers.GameManagerProps;
using Assets._Scripts.Structures.AbstractClasses.CardProps;
using Assets._Scripts.Cards.Followers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._Scripts.Loggers.EffectLogger
{
    public class EffectLogger : MonoBehaviour
    {
        private List<Card> _cardsToLog = new List<Card>();
        // Use this for initialization
        void Start()
        {
            GameManager.Instance.OnDrawCard += CardDrawHandler;
        }

        private void CardDrawHandler(Card c)
        {
            _cardsToLog.Add(c);
            c.OnEffectTriggered += Debug.Log;
        }

        private void OnDestroy()
        {
            GameManager.Instance.OnDrawCard -= CardDrawHandler;
        }
    }
}
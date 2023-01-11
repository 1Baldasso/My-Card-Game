using Assets._Scripts.Structures.AbstractClasses.CardProps;
using Assets._Scripts.Structures.Classes;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._Scripts.Managers.PlayerManagerProps
{
    public partial class PlayerManager : MonoBehaviour
    {
        //Private Properties
        private int _nexusHealth;
        private int _maxMana;
        private int _mana;
        private int _spellMana;
        private Deck _activeDeck;
        private List<Card> _hand = new();
        public List<Card> Hand {  get { return _hand; } }
        private List<Card> _board = new();
        public List<Card> Board { get { return _board; } }

        //Public properties
        public static PlayerManager Instance;
        public int NexusHealth { get { return _nexusHealth; } }
        public int MaxMana { get { return _maxMana; } }
        public int Mana { get { return _mana; } }
        public int SpellMana { get { return _spellMana; } }
        public bool loaded;
    }
}
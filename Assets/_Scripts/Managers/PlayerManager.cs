using Assets._Scripts.Structures.AbstractClasses;
using Assets._Scripts.Structures.Enumerators;
using Assets._Scripts.Structures.Interfaces;
using Assets._Scripts.Structures.Structures;
using System.Collections;
using UnityEngine;

namespace Assets._Scripts.Managers
{
    public class PlayerManager : MonoBehaviour
    {
        public static PlayerManager Instance;
        private int NexusHealth;
        private int Mana;
        private int SpellMana;
        private Deck ActiveDeck;
        // Use this for initialization
        private void Awake()
        {
            Mana = 9;
            SpellMana = 0;
            NexusHealth = 20;
            Instance = this;
        }

        public void HealNexus(int q)
        {
            var finalHealth = NexusHealth + q;
            if(finalHealth > 20)
                NexusHealth = 20;
            else
                NexusHealth = finalHealth;
        }

        public bool TryPlayCard(Card card)
        {
            bool canPlayCard = false;

            if (card.Types.Contains(CardTypeEnum.Spell) || card.Types.Contains(CardTypeEnum.Equipment))
            {
                if (card.ManaCost <= Mana + SpellMana)
                {
                    SpellMana -= card.ManaCost;
                    if (SpellMana < 0)
                    {
                        Mana += SpellMana;
                        SpellMana = 0;
                    }
                    canPlayCard = true;
                }
            }
            else
            {
                if (card.ManaCost <= Mana)
                    canPlayCard = true;
            }

            if (canPlayCard)
                Mana -= card.ManaCost;

            return canPlayCard;
        }

        public void DamageNexus(int q)
        {
            NexusHealth -= q;
            if (NexusHealth < 0)
                GameManager.Instance.RaiseMatchEnd();
        }

        public void RaisePlayerEvent(PlayerEventEnum Enum)
        {
            GameManager.Instance.RaisePlayerEvent(Enum);
            if (Enum == PlayerEventEnum.Play)
                GameManager.Instance.RaiseSystemEvent(SystemEventEnum.Summon);
        }
    }
}
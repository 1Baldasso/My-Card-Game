using Assets._Scripts.GameScripts;
using Assets._Scripts.Managers.GameManagerProps;
using Assets._Scripts.Managers.GameObjectManagerProps;
using Assets._Scripts.Managers.RoundManagerProps;
using Assets._Scripts.Structures.Classes;
using System;
using System.Linq;
using UnityEngine;

namespace Assets._Scripts.Managers.PlayerManagerProps
{
    public partial class PlayerManager : MonoBehaviour
    {
        private void Awake()
        {
            _maxMana = 0;
            _mana = 0;
            _spellMana = 0;
            _nexusHealth = 20;
            Instance = this;
        }

        private void Start()
        {
            GameManager.Instance.OnRoundEnd += HandleRoundEnd;
            GameManager.Instance.OnRoundStart += HandleRoundStart;
            RoundManager.Instance.OnCardDrawn += HandleDrawCard;
            _activeDeck = Deck.Default;
            loaded = true;
        }

        private void OnDestroy()
        {
            GameManager.Instance.OnRoundEnd -= HandleRoundEnd;
            GameManager.Instance.OnRoundStart -= HandleRoundStart;
        }

        private void HandleRoundStart()
        {
            MaxManaIncrease();
            _mana = _maxMana;
            OnManaChanged?.Invoke(Mana);
            OnRoundStartHandled?.Invoke();
        }

        private void HandleRoundEnd()
        {
            _spellMana = _mana > 3 ? 3 : _mana;
            OnSpellManaChanged?.Invoke(SpellMana);
            OnRoundEndHandled?.Invoke();
        }

        private void HandleDrawCard()
        {
            var card = _activeDeck.DrawCard();
            _hand.Add(card);
        }

        private void ConfirmAttack()
        {
            var boardTransform = GameObject.FindGameObjectWithTag("Board").transform;
            var attackingCards = GameObject.FindGameObjectWithTag("CombatField")
                .GetComponentsInChildren<CardUnitScript>().Select(x => 
                new { 
                    x.card, 
                    x.gameObject 
                });
            var damage = attackingCards.Sum(x => x.card.Attack);
            DamageNexus(damage);
            foreach (var card in attackingCards)
            {
                card.gameObject.transform.SetParent(boardTransform);
                card.card.CardState = Structures.Enumerators.CardStateEnum.OnBoard;
            }
            GameObjectManager.Instance.ChangeButtonOnStackAttack();
            RoundManager.Instance.HandleUnitsAttack();
        }

        private void ConfirmSpell() => throw new NotImplementedException();

        private void ConfirmSkill() => throw new NotImplementedException();


    }
}

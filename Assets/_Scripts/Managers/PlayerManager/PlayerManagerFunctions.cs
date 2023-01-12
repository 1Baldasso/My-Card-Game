using Assets._Scripts.Structures.AbstractClasses.CardProps;
using Assets._Scripts.Managers.GameManagerProps;
using Assets._Scripts.Structures.Enumerators;

namespace Assets._Scripts.Managers.PlayerManagerProps
{
    public partial class PlayerManager
    {
        public void MaxManaIncrease()
        {
            if (_maxMana < 10) _maxMana++;
        }
        public void HealNexus(int q)
        {
            var finalHealth = _nexusHealth + q;
            if (finalHealth > 20)
                _nexusHealth = 20;
            else
                _nexusHealth = finalHealth;
        }

        public bool TryPlayCard(Card card)
        {
            bool canPlayCard = false;

            if (card.Types.Contains(CardTypeEnum.Spell) || card.Types.Contains(CardTypeEnum.Equipment))
            {
                if (card.ManaCost <= _mana + _spellMana)
                {
                    _spellMana -= card.ManaCost;
                    if (_spellMana < 0)
                    {
                        _mana += _spellMana;
                        _spellMana = 0;
                    }
                    OnSpellManaChanged?.Invoke(SpellMana);
                    canPlayCard = true;
                }
            }
            else
            {
                if (card.ManaCost <= _mana)
                    canPlayCard = true;
            }

            if (canPlayCard)
            {
                _mana -= card.ManaCost;
                OnManaChanged?.Invoke(Mana);
            }

            return canPlayCard;
        }

        public void DamageNexus(int q)
        {
            _nexusHealth -= q;
            if (_nexusHealth <= 0)
                GameManager.Instance.RaiseMatchEnd();
        }

    }
}

using Assets._Scripts.Managers.GameManagerProps;
using Assets._Scripts.Managers.RoundManagerProps;
using Assets._Scripts.Structures.Classes;

namespace Assets._Scripts.Managers.PlayerManagerProps
{
    public partial class PlayerManager
    {
        private void Awake()
        {
            _maxMana = 8;
            _mana = 8;
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
    }
}

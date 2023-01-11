using System;
using Assets._Scripts.Structures.AbstractClasses.CardProps;
using Assets._Scripts.Structures.AbstractClasses.Unit;
using Assets._Scripts.Structures.AbstractClasses.SpellProps;
using Assets._Scripts.Structures.Enumerators;

namespace Assets._Scripts.Managers.GameManagerProps
{
    public partial class GameManager
    {
        //Events

        /// <summary>
        /// Called when a card is played
        /// </summary>
        public event Action<Card> OnCardPlayed;
        public void RaiseCardPlayed(Card c) => OnCardPlayed?.Invoke(c);
        /// <summary>
        /// Called when an unit is summoned
        /// </summary>
        public event Action<Unit> OnUnitSummoned;
        public void RaiseUnitSummoned(Unit u) => OnUnitSummoned?.Invoke(u);
        /// <summary>
        /// Called when an unit dies
        /// </summary>
        public event Action<Unit> OnUnitDied;
        public void RaiseUnitDied(Unit u) => OnUnitDied?.Invoke(u);
        /// <summary>
        /// Called on the end of the combat
        /// </summary>
        public event Action<Unit, Unit> OnCombatResolve;
        public void RaiseCombatResolve(Unit u, Unit u2) => OnCombatResolve?.Invoke(u, u2);
        /// <summary>
        /// Called when a Card is drawn
        /// </summary>
        public event Action<Card> OnDrawCard;
        public void RaiseDrawCard(Card c) => OnDrawCard?.Invoke(c);
        /// <summary>
        /// Called when nexus get hit
        /// </summary>
        public event Action<int> OnNexusHit;
        public void RaiseNexusHit(int q) => OnNexusHit?.Invoke(q);
        /// <summary>
        /// Called when a spell resolve
        /// </summary>
        public event Action<Spell> OnSpellResolve;
        public void RaiseSpellResolve(Spell s) => OnSpellResolve?.Invoke(s);
        /// <summary>
        /// Called when round starts
        /// </summary>
        public event Action OnRoundStart;
        public void RaiseRoundStart() => OnRoundStart?.Invoke();
        /// <summary>
        /// Called when round ends
        /// </summary>
        public event Action OnRoundEnd;
        public void RaiseRoundEnd() => OnRoundEnd?.Invoke();
        /// <summary>
        /// Called when match ends
        /// </summary>
        public event Action MatchEnd;
        public void RaiseMatchEnd() => MatchEnd?.Invoke();

        //Enum Events
        public static event Action<PlayerEventEnum> OnPlayerAction;
        public static event Action<SystemEventEnum> OnSystemAction;
        public static event Action<CombatEventEnum> OnResolveCombat;
        public static event Action<GameStateEnum> OnGameStateChanged;

        //Event Raisers
        
        
        public void RaisePlayerEvent(PlayerEventEnum playerEvent) => OnPlayerAction?.Invoke(playerEvent);
        public void RaiseSystemEvent(SystemEventEnum systemEvent) => OnSystemAction?.Invoke(systemEvent);
        public void RaiseCombatEvent(CombatEventEnum combatEvent) => OnResolveCombat?.Invoke(combatEvent);
    }
}

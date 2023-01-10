using Assets._Scripts.Structures.AbstractClasses;
using Assets._Scripts.Structures.Enumerators;
using Assets._Scripts.Structures.Structures;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour 
{
    public static GameManager Instance;

    //Events
    public event Action<Card> OnCardPlayed;
    public event Action<Unit> OnUnitSummoned;
    public event Action<Unit, Unit> OnCombatResolve;
    public event Action<Unit> OnUnitDied;
    public event Action<Card> OnDrawCard;
    public event Action<int> OnNexusHit;
    public event Action<Spell> OnSpellResolve;

    //Enum Events
    public static event Action<PlayerEventEnum> OnPlayerAction;
    public static event Action<SystemEventEnum> OnSystemAction;
    public static event Action<CombatEventEnum> OnResolveCombat;
    public static event Action MatchEnd;

    public static event Action<GameStateEnum> OnGameStateChanged;

    //Properties
    private GameStateEnum _gameState;

    
    private void Awake()
    {
        Instance = this;
    }

    
    public void UpdateGameState(GameStateEnum state)
    {
        _gameState = state;
        OnGameStateChanged?.Invoke(state);
        DeckList.CreateDeck(new Deck());
    }

    //Event Raisers
    public void RaisePlayerEvent(PlayerEventEnum playerEvent) => OnPlayerAction?.Invoke(playerEvent);
    public void RaiseSystemEvent(SystemEventEnum systemEvent) => OnSystemAction?.Invoke(systemEvent);
    public void RaiseCombatEvent(CombatEventEnum combatEvent) => OnResolveCombat?.Invoke(combatEvent);
    public void RaiseMatchEnd() => MatchEnd?.Invoke();

    //Trying to Sign actions dynamically
    public static void AssignActionOfType<T>(Action<T> ac) where T : struct
    {
        if (typeof(T) == typeof(PlayerEventEnum))
            OnPlayerAction += ac as Action<PlayerEventEnum>;
        if (typeof(T) == typeof(SystemEventEnum))
            OnSystemAction += ac as Action<SystemEventEnum>;
        if (typeof(T) == typeof(CombatEventEnum))
            OnResolveCombat += ac as Action<CombatEventEnum>;

    }   
}
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
    public static event Action<PlayerEventEnum> OnPlayerAction;
    public static event Action<SystemEventEnum> OnSystemAction;
    public static event Action<CombatEventEnum> OnResolveCombat;
    private GameStateEnum _gameState;
    public event Action<GameStateEnum> OnGameStateChanged;
    
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
    public void RaisePlayerEvent(PlayerEventEnum? playerEvent) => OnPlayerAction?.Invoke((PlayerEventEnum)playerEvent);
    public void RaiseSystemEvent(SystemEventEnum? systemEvent) => OnSystemAction?.Invoke((SystemEventEnum)systemEvent);
    public void RaiseCombatEvent(CombatEventEnum? combatEvent) => OnResolveCombat?.Invoke((CombatEventEnum)combatEvent);

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
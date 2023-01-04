using Assets._Scripts.Structures.Structures;
using System;
using System.Collections;
using UnityEngine;

public partial class RoundManager : MonoBehaviour
{
    public static RoundManager Instance;
    public UInt16 RoundNumber;
    private bool _attackToken;
    private AttackRounds AttackRound;
    private RoundState _roundState;
    private Action<RoundState> RoundStateChange;
    private void Awake()
    {
        RoundNumber = 0;
        Instance = this;
    }

    private void UpdateRoundState(RoundState newRoundState)
    {
        _roundState = newRoundState;
        RoundStateChange?.Invoke(newRoundState);
    }

    //public void Mulligan()
    //{
    //    Deck.DrawCard(5);
    //    VisualDeck.SelectCards();
    //}

    public void RoundStart()
    {
        RoundNumber++;
        _attackToken = AttackRound == AttackRounds.Even ? RoundNumber % 2 == 0 : RoundNumber % 2 == 1;
        UpdateRoundState(RoundState.RoundStart);
    }

    public void RoundEnd() 
    {
        UpdateRoundState(RoundState.RoundStart);
    }

    public void Rally()
    {
        Debug.Log("RALLY!");
        _attackToken = true;
    }
   
}

public enum AttackRounds
{
    Even,
    Odds
}

public enum RoundState
{
    RoundStart,
    DrawCard,
    AfterAttack,
    RoundEnd,
}
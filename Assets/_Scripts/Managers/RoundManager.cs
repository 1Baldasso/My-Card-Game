using Assets._Scripts.Structures.Enumerators;
using Assets._Scripts.Structures.Structures;
using System;
using System.Collections;
using UnityEngine;

public partial class RoundManager : MonoBehaviour
{

    private bool EnemyHasPassed = false;
    public static RoundManager Instance;

    private UInt16 _RoundNumber;

    public bool AttackToken { get; private set; }
    private readonly AttackRounds AttackRound;

    private void Awake()
    {

        _RoundNumber = 0;
        Instance = this;
    }

    Action<GameStateEnum> OnGameStartHandler = (GS) =>
    {
        if (GS == GameStateEnum.InGame)
            Instance.RoundStart();
    };

    public void RoundStart()
    {
        _RoundNumber++;
        AttackToken = AttackRound == AttackRounds.Even ? _RoundNumber % 2 == 0 : _RoundNumber % 2 == 1;
        if (AttackToken)
            Rally();
    }

    public void RoundEnd() 
    {
        AttackToken = false;

    }
   
}

public enum AttackRounds
{
    Even,
    Odds
}
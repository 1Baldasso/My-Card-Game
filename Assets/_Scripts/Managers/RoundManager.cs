using Assets._Scripts.Structures.Enumerators;
using Assets._Scripts.Structures.Structures;
using System;
using System.Collections;
using UnityEngine;

public partial class RoundManager : MonoBehaviour
{

    private bool EnemyHasPassed = false;
    public static RoundManager Instance;

    public UInt16 RoundNumber;

    private bool _attackToken;
    private AttackRounds AttackRound;

    private void Awake()
    {

        RoundNumber = 0;
        Instance = this;
        GameManager.Instance.OnGameStateChanged+=OnGameStartHandler;
    }

    Action<GameStateEnum> OnGameStartHandler = (GS) =>
    {
        if (GS == GameStateEnum.InGame)
            Instance.RoundStart();
    };

    public void RoundStart()
    {
        RoundNumber++;
        _attackToken = AttackRound == AttackRounds.Even ? RoundNumber % 2 == 0 : RoundNumber % 2 == 1;
        if (_attackToken)
            Rally();
    }

    public void RoundEnd() 
    {
        _attackToken = false;

    }
   
}

public enum AttackRounds
{
    Even,
    Odds
}
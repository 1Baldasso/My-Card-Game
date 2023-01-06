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

    private bool _attackToken;
    private AttackRounds AttackRound;

    private void Awake()
    {

        _RoundNumber = 0;
        Instance = this;
    }
    private void Start()
    {
        GameManager.Instance.OnGameStateChanged += OnGameStartHandler;
    }

    Action<GameStateEnum> OnGameStartHandler = (GS) =>
    {
        if (GS == GameStateEnum.InGame)
            Instance.RoundStart();
    };

    public void RoundStart()
    {
        _RoundNumber++;
        _attackToken = AttackRound == AttackRounds.Even ? _RoundNumber % 2 == 0 : _RoundNumber % 2 == 1;
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
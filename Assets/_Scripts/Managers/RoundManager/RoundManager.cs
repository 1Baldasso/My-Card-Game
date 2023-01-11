using Assets._Scripts.Structures.Enumerators;
using Assets._Scripts.Managers.GameManagerProps;
using Assets._Scripts.Managers;
using System;
using System.Collections;
using UnityEngine;

namespace Assets._Scripts.Managers.RoundManagerProps
{
    public partial class RoundManager : MonoBehaviour
    {

        private bool _enemyHasPassed = false;
        private UInt16 _RoundNumber;
        private AttackRoundEnum AttackRound;

        public static RoundManager Instance;


        public bool AttackToken { get; private set; }
        public bool loaded;

        private void Awake()
        {
            AttackRound = AttackRoundEnum.Odds;
            _RoundNumber = 0;
            Instance = this;
        }
        public void Start()
        {
            LoadManager.Instance.LoadCompleted += RoundStart;
            loaded = true;
        }
        public void OnDestroy()
        {
            LoadManager.Instance.LoadCompleted -= RoundStart;
            
        }

        public void RoundStart()
        {
            _RoundNumber++;
            GameManager.Instance.RaiseRoundStart();
            DrawCard();
            AttackToken = AttackRound == AttackRoundEnum.Even ? _RoundNumber % 2 == 0 : _RoundNumber % 2 == 1;
            if (AttackToken)
                Rally();
        }

        public void RoundEnd()
        {
            AttackToken = false;
            GameManager.Instance.RaiseRoundEnd();
            RoundStart();
        }

    }
}

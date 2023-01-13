using Assets._Scripts.Structures.Enumerators;
using Assets._Scripts.Managers.GameManagerProps;
using Assets._Scripts.Managers;
using System;
using System.Collections;
using UnityEngine;
using Assets._Scripts.Structures.Classes;
using Unity.VisualScripting;

namespace Assets._Scripts.Managers.RoundManagerProps
{
    public partial class RoundManager : MonoBehaviour
    {

        private bool _enemyHasPassed = false;
        private UInt16 _RoundNumber;
        public UInt16 UnitsDiedOnRound { get; private set; }
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
            Deck.Default.Shuffle();
            loaded = true;
        }
        public void OnDestroy()
        {
            LoadManager.Instance.LoadCompleted -= RoundStart;
            
        }

        public void RoundStart()
        {
            UnitsDiedOnRound = 0;
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
            OnAttackTokenChanged?.Invoke(AttackToken);
            this.OnRoundEnd?.Invoke();
            RoundStart();
        }

        public void HandleUnitsAttack()
        {
            AttackToken = AttackToken ? !AttackToken : false;
            AttackToken = false;
            this.OnAttackTokenChanged?.Invoke(AttackToken);
        }
    }
}

using System;
using UnityEngine;

namespace Assets._Scripts.Managers.RoundManagerProps
{
    public partial class RoundManager : MonoBehaviour
    {
        public event Action<bool> OnAttackTokenChanged;
        public event Action OnCardDrawn;
        public event Action OnPass;

        public void Rally()
        {
            AttackToken = true;
            OnAttackTokenChanged?.Invoke(AttackToken);
        }
        public void DrawCard(int amout = 1)
        {
            for (int i = 0; i < amout;i++)
            {
                OnCardDrawn?.Invoke();
            }
        }
        public void Pass()
        {
            OnPass?.Invoke();
            Debug.Log("U HAVE PASSED");
            if (_enemyHasPassed)
                RoundEnd();
            _enemyHasPassed = !_enemyHasPassed;
        }

        public void CardDied()
        {
            UnitsDiedOnRound++;
        }
    }
}

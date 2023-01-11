using System;
using UnityEngine;

namespace Assets._Scripts.Managers.RoundManagerProps
{
    public partial class RoundManager : MonoBehaviour
    {
        public event Action OnRally;
        public event Action OnCardDrawn;
        public event Action OnPass;

        public void Rally()
        {
            AttackToken = true;
            OnRally?.Invoke();
        }
        public void DrawCard(int q = 1)
        {
            for (int i = 0; i < q;i++)
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
    }
}

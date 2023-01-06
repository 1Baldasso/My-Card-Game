using Assets._Scripts.Structures.Enumerators;
using UnityEngine;

namespace Assets._Scripts.Managers
{
    public class CardStateManager : MonoBehaviour
    {
        public CardStateManager Instance;
        private void Awake()
        {
            Instance = this;
        }
        public void ChangeCardState(CardStateEnum newCardState)
        {
            switch (newCardState)
            {
                
            }
        }
    }
}


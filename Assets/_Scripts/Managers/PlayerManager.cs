using Assets._Scripts.Structures.Enumerators;
using Assets._Scripts.Structures.Interfaces;
using System.Collections;
using UnityEngine;

namespace Assets._Scripts.Managers
{
    public class PlayerManager : MonoBehaviour, IEventRaiser
    {
        public static PlayerManager Instance;
        public int Mana;
        // Use this for initialization
        private void Awake()
        {
            Instance = this;
        }
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void RaiseEvent<T>(T Enum) where T : struct
        {
            if(typeof(T) == typeof(PlayerEventEnum))
                GameManager.Instance.RaisePlayerEvent(Enum as PlayerEventEnum?);
        }
    }
}
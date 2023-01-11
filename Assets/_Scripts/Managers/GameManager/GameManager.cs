using Assets._Scripts.Structures.Enumerators;
using UnityEngine;

namespace Assets._Scripts.Managers.GameManagerProps
{
    public partial class GameManager : MonoBehaviour
    {
        //Private properties
        private GameStateEnum _gameState;

        //Public properties
        public static GameManager Instance;
        public bool loaded;

        private void Awake()
        {
            Instance = this;
        }
        private void Start()
        {
            loaded = true;
        }
    }
}

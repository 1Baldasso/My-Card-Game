using Assets._Scripts.Managers.RoundManagerProps;
using UnityEngine;

using UnityEngine.UI;

namespace Assets._Scripts.GameScripts
{
    public class AttackTokenScript : MonoBehaviour
    {
        [SerializeField] private Image image;
        public void Start()
        {
            RoundManager.Instance.OnRally += ChangeSpriteOnRally;
        }

        public void ChangeSpriteOnAttack()
        {

            image.color = Color.red;
        }
        public void ChangeSpriteOnRally()
        {
            image.color = Color.yellow;
        }

    }
}

using Assets._Scripts.Managers;
using UnityEngine;
using UnityEngine.UIElements;

namespace Assets._Scripts.GameScripts
{
    public class AttackTokenScript : MonoBehaviour
    {
        [SerializeField]
        private Image image;
        [SerializeField]
        private Sprite _attackOnSprite;
        [SerializeField]
        private Sprite _attackOffSprite;

        private RoundManager rm;

        public void Awake()
        {
            rm = gameObject.GetComponent<RoundManager>();
            rm.OnRally += ChangeSpriteOnRally;
        }

        public void ChangeSpriteOnAttack()
        {
            image.sprite = _attackOffSprite;
        }
        public void ChangeSpriteOnRally()
        {
            image.sprite = _attackOnSprite;
        }

    }
}

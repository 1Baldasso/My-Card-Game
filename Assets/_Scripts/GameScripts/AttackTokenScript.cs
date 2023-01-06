using Assets._Scripts.Managers;
using UnityEngine;

using UnityEngine.UIElements;

namespace Assets._Scripts.GameScripts
{
    public class AttackTokenScript : MonoBehaviour
    {

        public void Start()
        {

            RoundManager.Instance.OnRally += ChangeSpriteOnRally;
        }

        public void ChangeSpriteOnAttack()
        {

            gameObject.GetComponentInChildren<Image>().tintColor = Color.HSVToRGB(44, 100, 90);
        }
        public void ChangeSpriteOnRally()
        {
            gameObject.GetComponentInChildren<Image>().tintColor = Color.HSVToRGB(3, 100, 32);
        }

    }
}

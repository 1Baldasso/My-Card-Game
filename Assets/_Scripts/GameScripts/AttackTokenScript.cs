using Assets._Scripts.Managers.RoundManagerProps;
using UnityEngine;

using UnityEngine.UI;

namespace Assets._Scripts.GameScripts
{
    public class AttackTokenScript : MonoBehaviour
    {
        [SerializeField] private Image image;

        private void Start() => RoundManager.Instance.OnAttackTokenChanged += ChangeAttackTokenSprite;   
        private void OnDestroy() => RoundManager.Instance.OnAttackTokenChanged += ChangeAttackTokenSprite;

        private void ChangeAttackTokenSprite(bool token) => image.color = token ? Color.yellow : Color.red;

    }
}

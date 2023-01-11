using Assets._Scripts.Managers;
using System.Collections;
using TMPro;
using Assets._Scripts.Managers.PlayerManagerProps;
using UnityEngine;

namespace Assets._Scripts.GameScripts
{
    public class ManaIndicatorScript : MonoBehaviour
    {
        private TextMeshProUGUI TMP;
        private void Start()
        {
            TMP = gameObject.GetComponentInChildren<TextMeshProUGUI>();
            PlayerManager.Instance.OnManaChanged += HandleManaChanged;
        }
        private void HandleManaChanged() => TMP.text = PlayerManager.Instance.Mana.ToString();

    }
}
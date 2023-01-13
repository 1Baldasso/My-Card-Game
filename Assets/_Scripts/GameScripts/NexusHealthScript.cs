using Assets._Scripts.Managers.PlayerManagerProps;
using System.Collections;
using TMPro;
using UnityEngine;

namespace Assets._Scripts.GameScripts
{
    public class NexusHealthScript : MonoBehaviour
    {
        private TextMeshProUGUI TMP;
        private int _health;
        // Use this for initialization
        void Start()
        {
            TMP = GetComponentInChildren<TextMeshProUGUI>();
            PlayerManager.Instance.OnNexusDamaged += ChangeNexusLife;
            _health = 20;
            TMP.text = _health.ToString();
        }

        private void OnDestroy()
        {
            PlayerManager.Instance.OnNexusDamaged -= ChangeNexusLife;
        }

        private void ChangeNexusLife(int damage)
        {
            _health -= damage;
            TMP.text = _health.ToString();
        }
    }
}
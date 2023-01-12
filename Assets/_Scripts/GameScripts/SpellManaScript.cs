using Assets._Scripts.Managers.PlayerManagerProps;
using System.Collections;
using UnityEngine;

namespace Assets._Scripts.GameScripts
{
    public class SpellManaScript : MonoBehaviour
    {
        [SerializeField] private GameObject SpellManaGemPrefab;
        void Start()
        {
            PlayerManager.Instance.OnSpellManaChanged += UpdateSpellManaGem;
        }
        private void OnDestroy()
        {
            PlayerManager.Instance.OnSpellManaChanged -= UpdateSpellManaGem;
        }

        private void UpdateSpellManaGem(int gems)
        {
            gameObject.transform.DetachChildren();
            for (int i = 0; i < gems; i++)
            {
                Instantiate(SpellManaGemPrefab, gameObject.transform);
            }
        }
    }
}
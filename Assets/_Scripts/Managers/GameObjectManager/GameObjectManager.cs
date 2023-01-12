using Assets._Scripts.GameScripts;
using Assets._Scripts.Structures.Enumerators;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

namespace Assets._Scripts.Managers.GameObjectManagerProps
{
    public class GameObjectManager : MonoBehaviour
    {
        public bool loaded;
        public static GameObjectManager Instance;
        [SerializeField] private GameObject PassButton;
        [SerializeField] private GameObject ConfirmButton;
        private void Awake()
        {
            Instance = this;
            loaded = true;
        }

        public bool CompareObjectAbove(GameObject gameObject1, GameObject gameObject2)
        {
            return false;
        }
        public void ChangeCardObjectLayer(GameObject card, Transform nextLayer)
        {
            card.transform.SetPositionAndRotation(Vector2.zero, Quaternion.identity);
            card.transform.SetParent(nextLayer.transform);
            ChangeButtonOnStackAttack();
            
        }
        public void ChangeButtonOnStackAttack()
        {
            ConfirmButton.SetActive(GameObject.FindGameObjectWithTag("CombatField").transform.childCount > 0);
            PassButton.SetActive(!ConfirmButton.activeSelf);
        }
    }
}
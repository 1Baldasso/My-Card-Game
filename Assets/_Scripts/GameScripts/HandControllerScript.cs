using Assets._Scripts.Managers.GameManagerProps;
using Assets._Scripts.Managers.PlayerManagerProps;
using Assets._Scripts.Structures.AbstractClasses.CardProps;
using Assets._Scripts.Structures.AbstractClasses.Unit;
using UnityEngine;

namespace Assets._Scripts.GameScripts
{
    public class HandControllerScript : MonoBehaviour
    {

        [SerializeField] private GameObject CardPrefab;

        private void Start()
        {
            GameManager.Instance.OnDrawCard += SetNewCardAttributes;
        }
        private void SetNewCardAttributes(Card c)
        {
            GameObject go = GameObject.Instantiate(CardPrefab,gameObject.transform,false);
            var cus = go.GetComponent<CardUnitScript>();
            cus.card = c as Unit;
            cus.SetAttributes();
        }
    }
}
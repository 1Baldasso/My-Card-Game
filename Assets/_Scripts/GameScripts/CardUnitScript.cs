using Assets._Scripts.Structures.Interfaces;
using Assets._Scripts.Structures.DTO;
using Assets._Scripts.Structures.Enumerators;
using UnityEngine;
using Assets._Scripts.Managers;
using Assets._Scripts.Structures.AbstractClasses;

namespace Assets._Scripts.GameScripts
{
    public class CardUnitScript : MonoBehaviour, IDraggable
    {
        private Vector3 offset;
        private GameObject selectedObject;
        private Card card;
        private int YforNextLayer;
        private GameObject NextLayer;
        private InitialTransformDTO initialTransform;
        void Start()
        {
            card.CardState = CardStateEnum.OnDeck;
        }

        void Update()
        {
            DragObject();
        }

        public virtual void DragObject()
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (Input.GetMouseButtonDown(0))
            {
                Collider2D targetObject = Physics2D.OverlapPoint(mousePosition);
                if (targetObject != null)
                {
                    initialTransform = new InitialTransformDTO
                    {
                        Position = targetObject.transform.position,
                        Parent = targetObject.transform.parent
                    };
                    selectedObject = targetObject.transform.gameObject;
                    offset = selectedObject.transform.position - mousePosition;
                    selectedObject.transform.SetParent(null,false);
                }
            }
            if (selectedObject != null)
                selectedObject.transform.position = mousePosition + offset;
            if (Input.GetMouseButtonUp(0) && selectedObject != null)
            {
                if (selectedObject.transform.position.y > YforNextLayer)
                {
                    if(card.CardState == CardStateEnum.OnHand && PlayerManager.Instance.TryPlayCard(card))
                    {
                        NextLayer = GameObject.FindGameObjectWithTag("Board");
                        card.CardState = CardStateEnum.OnBoard;
                    }
                    if(card.CardState == CardStateEnum.OnBoard && RoundManager.Instance)
                    {
                        NextLayer = GameObject.FindGameObjectWithTag("CombatField");
                        PlayerManager.Instance.RaisePlayerEvent(PlayerEventEnum.Attack);
                        card.CardState = CardStateEnum.OnAttack;
                    }
                    selectedObject.transform.SetParent(NextLayer.transform,false);
                }
                else
                {
                    selectedObject.transform.position = initialTransform.Position;
                    selectedObject.transform.SetParent(initialTransform.Parent,false);
                }
                selectedObject = null;
            }
        }
    }
}
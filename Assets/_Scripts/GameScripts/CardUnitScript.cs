using Assets._Scripts.Structures.Interfaces;
using Assets._Scripts.Structures.DTO;
using Assets._Scripts.Structures.Enumerators;
using UnityEngine;
using Assets._Scripts.Managers;

namespace Assets._Scripts.GameScripts
{
    public class CardUnitScript : MonoBehaviour, IDraggable
    {
        private Vector3 offset;
        private GameObject selectedObject;
        private CardStateEnum cardState;
        private int YforNextLayer;
        private GameObject NextLayer;
        private InitialTransformDTO initialTransform;
        private int ManaCost;
        void Start()
        {
            cardState = CardStateEnum.OnDeck;
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
                if (selectedObject.transform.position.y > YforNextLayer && PlayerManager.Instance.Mana > ManaCost)
                {
                    if(cardState == CardStateEnum.OnHand)
                    {
                        NextLayer = GameObject.FindGameObjectWithTag("Board");
                        PlayerManager.Instance.RaiseEvent(PlayerEventEnum.Play);
                        cardState = CardStateEnum.OnBoard;
                    }
                    if(cardState == CardStateEnum.OnBoard)
                    {
                        NextLayer = GameObject.FindGameObjectWithTag("CombatField");
                        PlayerManager.Instance.RaiseEvent(PlayerEventEnum.Attack);
                        cardState = CardStateEnum.OnAttack;
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
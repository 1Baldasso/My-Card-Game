using Assets._Scripts.Structures.AbstractClasses;
using Assets._Scripts.Structures.Interfaces;
using Assets._Scripts.Structures.DTO;
using Assets._Scripts.Structures.Enumerators;
using Assets._Scripts.Managers;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Assets._Scripts.Structures.Cards.Followers;
using System.Collections;

namespace Assets._Scripts.GameScripts
{
    public class CardUnitScript : MonoBehaviour, IDraggable
    {
        private Vector3 offset;
        private GameObject selectedObject;
        private Unit card;
        private int YforNextLayer;
        private GameObject NextLayer;
        private InitialTransformDTO initialTransform;
        [SerializeField] private Sprite _defaultSprite;
        [SerializeField] private Image _imageContainer;
        private void Awake()
        {
            card = new TiannaCrownguard();            
        }
        private void Start()
        {
            card.CardState = CardStateEnum.OnHand;
            GameObject.FindGameObjectWithTag("Cost").GetComponentInChildren<TextMeshProUGUI>().text = card.ManaCost.ToString();
            GameObject.FindGameObjectWithTag("Attack").GetComponentInChildren<TextMeshProUGUI>().text = card.Attack.ToString();
            GameObject.FindGameObjectWithTag("Health").GetComponentInChildren<TextMeshProUGUI>().text = card.Health.ToString();
            StartCoroutine(nameof(ProvideImage));
        }

        void Update()
        {
            DragObject();
            if(card.EffectLog != "")
                Debug.Log(card.EffectLog);
        }

        public void DragObject()
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
                    switch (card.CardState)
                    {
                        case CardStateEnum.OnHand:
                            if (PlayerManager.Instance.TryPlayCard(card))
                            {
                                NextLayer = GameObject.FindGameObjectWithTag("Board");
                                selectedObject.transform.SetParent(NextLayer.transform, false);
                                card.CardState = CardStateEnum.OnBoard;                            
                            }
                            else
                            {
                                selectedObject.transform.position = initialTransform.Position;
                                selectedObject.transform.SetParent(initialTransform.Parent, false);
                                Debug.Log("U have no mana for this action");
                            }
                            break;
                        case CardStateEnum.OnBoard:
                            if (RoundManager.Instance.AttackToken)
                            {
                                NextLayer = GameObject.FindGameObjectWithTag("CombatField");
                                PlayerManager.Instance.RaisePlayerEvent(PlayerEventEnum.Attack);
                                card.CardState = CardStateEnum.OnAttack;
                                selectedObject.transform.SetParent(NextLayer.transform, false);
                            }
                            else
                            {
                                selectedObject.transform.position = initialTransform.Position;
                                selectedObject.transform.SetParent(initialTransform.Parent, false);
                                Debug.Log("U have no attack token for this action");
                            }
                            break;
                    }
                }
                else
                {
                    selectedObject.transform.position = initialTransform.Position;
                    selectedObject.transform.SetParent(initialTransform.Parent,false);
                }
                selectedObject = null;
            }
        }
        public IEnumerator ProvideImage()
        {
            yield return new WaitUntil(()=>card.Image != null);
            _imageContainer.sprite = card.Image;
        }
    }
}
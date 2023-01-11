using Assets._Scripts.Structures.AbstractClasses.Unit;
using Assets._Scripts.Structures.Interfaces;
using Assets._Scripts.Structures.DTO;
using Assets._Scripts.Structures.Enumerators;
using Assets._Scripts.Managers.PlayerManagerProps;
using Assets._Scripts.Managers.RoundManagerProps;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Assets._Scripts.Cards.Followers;
using System.Collections;

namespace Assets._Scripts.GameScripts
{
    public class CardUnitScript : MonoBehaviour, IDraggable
    {
        private Vector3 offset;
        private GameObject selectedObject;
        public Unit card;
        private int YforNextLayer;
        private GameObject NextLayer;
        private InitialTransformDTO initialTransform;
        [SerializeField] private Sprite _defaultSprite;
        [SerializeField] private Image _imageContainer;
        [SerializeField] private TextMeshProUGUI _costText;
        [SerializeField] private TextMeshProUGUI _attackText;
        [SerializeField] private TextMeshProUGUI _healthText;

        public void SetAttributes()
        {
            gameObject.name = card.Name;
            card.CardState = CardStateEnum.OnHand;
            _costText.text = card.ManaCost.ToString();
            _attackText.text = card.Attack.ToString();
            _healthText.text = card.Health.ToString();
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
                if (targetObject != null )
                {
                    if(targetObject == gameObject.GetComponent<Collider2D>())
                    {
                        selectedObject = targetObject.transform.gameObject;
                        offset = selectedObject.transform.position - mousePosition;
                        selectedObject.transform.SetParent(null,false);
                    }
                }
            }
            if (selectedObject != null)
            {
                selectedObject.transform.position = mousePosition + offset;
                selectedObject.transform.position += Vector3.back*3;
            }
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
                                card.RaiseSummon();
                            }
                            else
                            {
                                selectedObject.transform
                                    .SetParent(GameObject.FindGameObjectWithTag("Hand").transform,false);
                                Debug.Log("U have no mana for this action");
                            }
                            break;
                        case CardStateEnum.OnBoard:
                            if (RoundManager.Instance.AttackToken)
                            {
                                NextLayer = GameObject.FindGameObjectWithTag("CombatField");
                                //PlayerManager.Instance.RaisePlayerEvent(PlayerEventEnum.Attack);
                                card.CardState = CardStateEnum.OnAttack;
                                selectedObject.transform.SetParent(NextLayer.transform, false);
                            }
                            else
                            {
                                selectedObject.transform
                                    .SetParent(GameObject.FindGameObjectWithTag("Board").transform, false);
                                Debug.Log("U have no attack token for this action");
                            }
                            break;
                    }
                }
                else
                
                    selectedObject.transform
                        .SetParent(GameObject.FindGameObjectWithTag(
                            card.CardState.ToString().Remove(0,2)).transform,false);
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
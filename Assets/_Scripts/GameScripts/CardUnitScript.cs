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
using System.Linq;
using Assets._Scripts.Managers.GameObjectManagerProps;

namespace Assets._Scripts.GameScripts
{
    public class CardUnitScript : MonoBehaviour, IDraggable
    {
        private Vector3 offset;
        private GameObject selectedObject;
        public Unit card;
        public Transform actualParent;
        [SerializeField] private Image _imageContainer;
        [SerializeField] private TextMeshProUGUI _costText;
        [SerializeField] private TextMeshProUGUI _attackText;
        [SerializeField] private TextMeshProUGUI _healthText;

        public void UpdateAttributes()
        {
            _costText.text = card.ManaCost.ToString();
            _attackText.text = card.Attack.ToString();
            _healthText.text = card.Health.ToString();
        }
        public void SetAttributes()
        {
            gameObject.name = card.Name;
            card.CardState = CardStateEnum.OnHand;
            StartCoroutine(nameof(ProvideImage));
            UpdateAttributes();
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
                        actualParent = selectedObject.transform.parent.transform;
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
                var overlapping = Physics2D.OverlapPointAll(mousePosition);
                Transform nextLayer = null;
                switch (card.CardState)
                {
                    case CardStateEnum.OnHand:
                        nextLayer = overlapping.FirstOrDefault(x => x.gameObject.CompareTag("Board"))?.transform;
                        break;
                    case CardStateEnum.OnBoard:
                        nextLayer = overlapping.FirstOrDefault(x => x.gameObject.CompareTag("CombatField"))?.transform;
                        break;
                    case CardStateEnum.OnCombatField:
                        nextLayer = overlapping.FirstOrDefault(x => x.gameObject.CompareTag("Board"))?.transform;
                        break;
                }
                if (nextLayer == null)
                    nextLayer = actualParent;
                else
                {
                    bool canChange = false;
                    switch (card.CardState)
                    {
                        case CardStateEnum.OnHand:
                            if (canChange = PlayerManager.Instance.TryPlayCard(card))
                            {
                                card.CardState = CardStateEnum.OnBoard;
                                card.RaiseSummon();
                            }
                            break;
                        case CardStateEnum.OnBoard:
                            if (canChange = RoundManager.Instance.AttackToken)
                            {
                                card.CardState = CardStateEnum.OnCombatField;
                                PlayerManager.Instance.PrepareAction(PrepareActionEnum.Attack);
                            }
                            break;
                        case CardStateEnum.OnCombatField:
                            canChange = true;
                            card.CardState = CardStateEnum.OnBoard;
                            PlayerManager.Instance.PrepareAction(null);
                            break;
                    }
                    if (!canChange)
                        nextLayer = actualParent;
                }
                GameObjectManager.Instance.ChangeCardObjectLayer(selectedObject, nextLayer);
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
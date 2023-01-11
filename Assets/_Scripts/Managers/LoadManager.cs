using System;
using System.Collections;
using Assets._Scripts.Managers.RoundManagerProps;
using Assets._Scripts.Managers.PlayerManagerProps;
using Assets._Scripts.Managers.GameManagerProps;
using UnityEngine;

namespace Assets._Scripts.Managers
{
    public class LoadManager : MonoBehaviour
    {
        public event Action LoadCompleted;
        public static LoadManager Instance;
        private void Awake() => Instance = this;
        private void Start() => StartCoroutine(nameof(WaitTillLoad));
        private IEnumerator WaitTillLoad()
        {
            yield return new WaitUntil(() =>
            RoundManager.Instance.loaded
            && GameManager.Instance.loaded
            && PlayerManager.Instance.loaded);
            LoadCompleted?.Invoke();
        }
    }
}
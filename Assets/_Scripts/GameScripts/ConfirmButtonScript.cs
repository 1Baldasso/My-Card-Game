using Assets._Scripts.Managers.RoundManagerProps;
using System.Collections;
using UnityEngine;

namespace Assets._Scripts.GameScripts
{
    public class ConfirmButtonScript : MonoBehaviour
    {
        private void OnMouseDown()
        {
            RoundManager.Instance.ConfirmAction();
        }
    }
}
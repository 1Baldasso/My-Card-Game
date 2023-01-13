using Assets._Scripts.Managers.PlayerManagerProps;
using UnityEngine;

namespace Assets._Scripts.GameScripts
{
    public class ConfirmButtonScript : MonoBehaviour
    {
        private void OnMouseDown()
        {
            PlayerManager.Instance.ConfirmAction();
        }
    }
}
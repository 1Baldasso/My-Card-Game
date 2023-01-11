using Assets._Scripts.Managers.RoundManagerProps;
using UnityEngine;

namespace Assets._Scripts.GameScripts
{
    public class PassButtonScript : MonoBehaviour
    {
        private void OnMouseDown()
        {
            RoundManager.Instance.Pass();
        }
    }
}
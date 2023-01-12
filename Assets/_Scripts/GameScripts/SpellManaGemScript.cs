using System.Collections;
using UnityEngine;

namespace Assets._Scripts.GameScripts
{
    public class SpellManaGemScript : MonoBehaviour
    {
        void Update()
        {
            if(gameObject.transform.parent == null)
                Destroy(gameObject);
        }
    }
}
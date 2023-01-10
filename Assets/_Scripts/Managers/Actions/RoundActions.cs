using Assets._Scripts.Structures.Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public partial class RoundManager : MonoBehaviour
{
    public event Action OnRally;
    public event Action OnCardDrawn;
    public event Action OnPass;

    public void Rally()
    {
        AttackToken = true;
        OnRally?.Invoke();
    }
    public void DrawCard(int q = 1)
    {
        for(int i = 0; i < q;)
            OnCardDrawn?.Invoke();
        throw new NotImplementedException();
    }
    public void Pass()
    {
        OnPass?.Invoke();
        Debug.Log("U HAVE PASSED");
        if (EnemyHasPassed)
            RoundEnd();
    }
}
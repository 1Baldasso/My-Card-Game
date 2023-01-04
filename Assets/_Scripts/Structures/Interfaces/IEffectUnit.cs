using Assets._Scripts.Structures.Enumerators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

namespace Assets._Scripts.Structures.Interfaces
{
    public interface IEffectUnit : IEffectCard
    {
        protected virtual void DecideEvent(UnitCardActionEnum UnitAction) { }
    }
}

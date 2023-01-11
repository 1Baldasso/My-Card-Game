using System;

namespace Assets._Scripts.Structures.AbstractClasses.CardProps
{
    public partial class Card
    {
        public event Action OnPlay;
        public event Action OnDraw;
        public event Action OnDiscard;
        public event Action OnToss;
        public event Action<string> OnEffectTriggered;
        public void RaiseEffectTriggered() => OnEffectTriggered?.Invoke(this.EffectLog);
    }
}

using System;
using System.Collections.Generic;
using Assets._Scripts.Structures.Enumerators;
using Assets._Scripts.Structures.Interfaces;
using Assets._Scripts.Structures.AbstractClasses.CardProps;

namespace Assets._Scripts.Structures.AbstractClasses.Unit
{
    public abstract partial class Unit : Card, IEffectUnit
    {
        public Unit()
        {
            this.Types.Add(CardTypeEnum.Unit);
        }
        public Int16 Attack;
        public Int16 Health;
        public List<string> Keywords;
        public List<string> Speaks;
        public PlayerEventEnum? PlayerEvent;
        public SystemEventEnum? SystemEvent;
        public CombatEventEnum? CombatEvent;
        protected abstract void Effect();
        protected abstract void DecideEvent();

    }
}

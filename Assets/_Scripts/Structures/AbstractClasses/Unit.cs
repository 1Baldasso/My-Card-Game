using System;
using System.Collections.Generic;
using Assets._Scripts.Structures.Enumerators;
using Assets._Scripts.Structures.Interfaces;

namespace Assets._Scripts.Structures.AbstractClasses
{
    public abstract class Unit : Card, IEffectUnit
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
        protected virtual void Effect() { }
        protected void DecideEvent(UnitCardActionEnum UnitAction)
        {
            switch (UnitAction)
            {
                case UnitCardActionEnum.Summon:
                    SystemEvent = SystemEventEnum.Summon;
                    GameManager.AssignActionOfType<SystemEventEnum>(ThrowEffect);
                    break;
                case UnitCardActionEnum.Attack:
                    PlayerEvent = PlayerEventEnum.Attack;
                    GameManager.AssignActionOfType<PlayerEventEnum>(ThrowEffect);
                    break;
                case UnitCardActionEnum.Strike:
                    CombatEvent = CombatEventEnum.Strike;
                    GameManager.AssignActionOfType<CombatEventEnum>(ThrowEffect);
                    break;
                case UnitCardActionEnum.NexusHit:
                    CombatEvent = CombatEventEnum.NexusStrike;
                    GameManager.AssignActionOfType<CombatEventEnum>(ThrowEffect);
                    break;
                case UnitCardActionEnum.Death:
                    SystemEvent = SystemEventEnum.Death;
                    GameManager.AssignActionOfType<SystemEventEnum>(ThrowEffect);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        protected void ThrowEffect<T>(T value) where T : System.Enum
        {
            int EnumValue = -1;
            if (typeof(T) == typeof(PlayerEventEnum))
                EnumValue = (int)PlayerEvent;
            if(typeof(T) == typeof(SystemEventEnum))
                EnumValue = (int)SystemEvent;
            if (typeof(T) == typeof(CombatEventEnum))
                EnumValue = (int)CombatEvent;

            if (value as int? == EnumValue)
                Effect();

        }
    }
}

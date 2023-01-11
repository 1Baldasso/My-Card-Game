using Assets._Scripts.Structures.Enumerators;
using Assets._Scripts.Structures.AbstractClasses.CardProps;

namespace Assets._Scripts.Structures.AbstractClasses.SpellProps
{
    public class Spell : Card
    {
        public SpellSpeedEnum SpellSpeed;
        public Spell()
        {
            this.Types.Add(CardTypeEnum.Spell);
        }
    }
}


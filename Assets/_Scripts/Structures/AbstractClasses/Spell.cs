using Assets._Scripts.Structures.Enumerators;
namespace Assets._Scripts.Structures.AbstractClasses
{
    public class Spell : Card
    {
        public Spell()
        {
            this.Types.Add(CardTypeEnum.Spell);
        }
    }
}

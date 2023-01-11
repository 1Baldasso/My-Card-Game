using Assets._Scripts.Structures.Enumerators;
using Assets._Scripts.Structures.AbstractClasses.Unit;
namespace Assets._Scripts.Structures.AbstractClasses.Follower
{
    public abstract partial class Follower : Unit.Unit
    {
        public Follower()
            : base()
        { 
            this.Types.Add(CardTypeEnum.Follower); 
        }
    }
}
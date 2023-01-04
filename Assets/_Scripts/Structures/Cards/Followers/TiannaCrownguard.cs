using Assets._Scripts.Structures.AbstractClasses;
using Assets._Scripts.Structures.Enumerators;
using System.Collections.Generic;

namespace Assets._Scripts.Structures.Cards.Followers
{
    public class TiannaCrownguard : Follower
    {
        public TiannaCrownguard()
            : base()
        {
            this.Name = "Tianna Crownguard";
            this.ManaCost = 8;
            this.Attack = 8;
            this.Health = 8;
            this.Keywords = new List<string> { "Tough" };
            this.Description = "When I'm summoned, Rally";
            this.Region = CardRegionEnum.Demacia;
            this.Rarity = RarityEnum.Epic;
            base.DecideEvent(UnitCardActionEnum.Summon);
        }
        protected override void Effect()
        {
            RoundManager.Instance.Rally();
        }
    }
}

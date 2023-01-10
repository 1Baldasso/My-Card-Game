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
            this.ImageURL = "http://dd.b.pvp.net/4_0_0/set1/en_us/img/cards/01DE002.png";
            base.DecideEvent(UnitCardActionEnum.Summon);
            base.LoadImage();
        }
        protected override void Effect()
        {
            EffectLog = "Tianna Rallies";
            RoundManager.Instance.Rally();
            EffectLog = "";
        }
    }
}

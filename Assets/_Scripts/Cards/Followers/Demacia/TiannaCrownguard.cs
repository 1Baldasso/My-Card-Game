using Assets._Scripts.Structures.AbstractClasses.Follower;
using Assets._Scripts.Structures.Enumerators;
using Assets._Scripts.Managers.RoundManagerProps;
using System.Collections.Generic;
using Assets._Scripts.Managers.GameManagerProps;

namespace Assets._Scripts.Cards.Followers
{
    public class TiannaCrownguard : Follower
    {
        public TiannaCrownguard()
            : base()
        {
            this.Name = "Tianna Crownguard";
            this.CardCode = "01DE002";
            this.ManaCost = 8;
            this._set = 1;
            this.Attack = 8;
            this.Health = 8;
            this.Keywords = new List<string> { "Tough" };
            this.Description = "When I'm summoned, Rally";
            this.Region = CardRegionEnum.Demacia;
            this.Rarity = RarityEnum.Epic;
            this.ImageURL = "http://dd.b.pvp.net/4_0_0/set1/en_us/img/cards/01DE002.png";
            base.LoadImage();
            this.DecideEvent();
        }
        protected override void DecideEvent() => this.OnPlay += Effect;

        protected override void Effect()
        {
            RoundManager.Instance.Rally();
            this.RaiseEffectTriggered();
        }
    }
}

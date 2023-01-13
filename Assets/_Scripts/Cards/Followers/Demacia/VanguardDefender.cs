using Assets._Scripts.Structures.AbstractClasses.Follower;
using Assets._Scripts.Structures.Enumerators;
using Assets._Scripts.Managers.RoundManagerProps;
using System.Collections.Generic;
using Assets._Scripts.Managers.GameManagerProps;

namespace Assets._Scripts.Cards.Followers
{
    public class VanguardDefender : Follower
    {
        public VanguardDefender()
            : base()
        {
            this.Name = "Vanguard Defender";
            this.CardCode = "01DE020";
            this.ManaCost = 2;
            this._set = 1;
            this.Attack = 2;
            this.Health = 2;
            this.Keywords = new List<string> { "Tough" };
            this.Description = "";
            this.Region = CardRegionEnum.Demacia;
            this.Rarity = RarityEnum.Common;
            this.ImageURL = "http://dd.b.pvp.net/4_0_0/set1/en_us/img/cards/01DE020.png";
            base.LoadImage();
            this.DecideEvent();
        }
        protected override void DecideEvent() { }

        protected override void Effect() { }

    }
}

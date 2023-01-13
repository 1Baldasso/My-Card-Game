using Assets._Scripts.Managers.RoundManagerProps;
using Assets._Scripts.Structures.AbstractClasses.Follower;
using Assets._Scripts.Structures.Enumerators;
using System;
using System.Collections.Generic;

namespace Assets._Scripts.Cards.Followers.PiltoverZaun
{
    public class VeteranInvestigator : Follower
    {
        public VeteranInvestigator()
            : base()
        {
            this.Name = "Veteran Investigator";
            this.CardCode = "02PZ010";
            this.ManaCost = 2;
            this.Attack = 3;
            this.Health = 2;
            this._set = 2;
            this.Keywords = new List<string> { };
            this.Description = "When I'm summoned, ALL players draw 1.";
            this.Region = CardRegionEnum.PiltoverAndZaun;
            this.Rarity = RarityEnum.Common;
            this.ImageURL = "https://dd.b.pvp.net/4_0_0/set2/en_us/img/cards/02PZ010.png";
            base.LoadImage();
            this.DecideEvent();
            //base.LoadLocalImage();
        }

        protected override void DecideEvent() => this.OnSummon += Effect;
        protected override void Effect() => RoundManager.Instance.DrawCard();
    }
}
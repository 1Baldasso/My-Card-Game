using Assets._Scripts.Structures.AbstractClasses.Follower;
using Assets._Scripts.Structures.Enumerators;
using Assets._Scripts.Managers.RoundManagerProps;
using System.Collections.Generic;
using Assets._Scripts.Managers.GameManagerProps;
using UnityEngine;
using System.IO;

namespace Assets._Scripts.Cards.Followers
{
    public class CithriaOfCloudField : Follower
    {
        public CithriaOfCloudField()
            : base()
        {
            this.Name = "Cithria Of CloudField";
            this.CardCode = "01DE039";
            this.ManaCost = 1;
            this._set = 1;
            this.Attack = 2;
            this.Health = 2;
            this.Keywords = new List<string> { };
            this.Description = "";
            this.Region = CardRegionEnum.Demacia;
            this.Rarity = RarityEnum.Common;
            this.ImageURL = "http://dd.b.pvp.net/4_0_0/set1/en_us/img/cards/01DE039.png";
            base.LoadImage();
            this.DecideEvent();
            //base.LoadLocalImage();
        }
        protected override void DecideEvent() { }
        protected override void Effect() { }
    }
}

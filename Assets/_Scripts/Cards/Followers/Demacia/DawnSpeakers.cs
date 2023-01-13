using Assets._Scripts.Structures.AbstractClasses.Follower;
using Assets._Scripts.Structures.Enumerators;
using Assets._Scripts.Managers.RoundManagerProps;
using System.Collections.Generic;
using Assets._Scripts.Managers.GameManagerProps;
using UnityEngine;
using Assets._Scripts.GameScripts;
using Assets._Scripts.Utils;

namespace Assets._Scripts.Cards.Followers
{
    public class Dawnspeakers : Follower
    {
        public Dawnspeakers()
            : base()
        {
            this.Name = "Dawnspeakers";
            this.CardCode = "01DE031";
            this.ManaCost = 3;
            this._set = 1;
            this.Attack = 1;
            this.Health = 4;
            this.Keywords = new List<string> { };
            this.Description = "Round End: Grant other allies +1|+1 if an ally died this round.";
            this.Region = CardRegionEnum.Demacia;
            this.Rarity = RarityEnum.Epic;
            this.ImageURL = "http://dd.b.pvp.net/4_0_0/set1/en_us/img/cards/01DE031.png";
            base.LoadImage();
            this.DecideEvent();
        }
        protected override void DecideEvent() => RoundManager.Instance.OnRoundEnd += Effect;

        protected override void Effect()
        {
            if(this.CardState == CardStateEnum.OnBoard && RoundManager.Instance.UnitsDiedOnRound > 0)
                GameManager.Instance.PerformAction(action);
        }
        private void action()
        {
            var Board = GameObject.FindGameObjectWithTag("Board");
            var Cards = Board.GetComponentsInChildren<CardUnitScript>();
            foreach (var item in Cards)
            {
                if (item.card is Dawnspeakers)
                    continue;
                item.card.Attack++;
                item.card.Health++;
                item.UpdateAttributes();
            }
        }
    }
}

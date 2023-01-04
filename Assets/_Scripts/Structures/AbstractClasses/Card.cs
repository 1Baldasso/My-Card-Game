﻿using Assets._Scripts.Structures.Enumerators;
using System;
using System.Collections.Generic;
namespace Assets._Scripts.Structures.AbstractClasses
{
    public abstract class Card
    {
        public UInt32 Id;
        public String Name;
        public String CardCode;
        public String Description;
        public String FlavorText;
        public UInt16 ManaCost;
        public List<CardTypeEnum> Types;
        public CardRegionEnum Region;
        public RarityEnum Rarity;
        public CardStateEnum CardState = CardStateEnum.OnDeck;
    }
}
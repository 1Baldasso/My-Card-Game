using Assets._Scripts.Structures.Enumerators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets._Scripts.Structures.AbstractClasses
{
    public abstract class Follower : Unit
    {
        public Follower()
            : base()
        { 
            this.Types.Add(CardTypeEnum.Follower); 
        }
    }
}
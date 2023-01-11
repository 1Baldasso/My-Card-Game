using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets._Scripts.Structures.AbstractClasses.Unit
{
    public partial class Unit
    {
        public event Action OnAttack;
        public void RaiseAttack() => OnAttack?.Invoke();
        public event Action OnHit;
        public void RaiseHit() => OnHit?.Invoke();
        public event Action OnSummon;
        public void RaiseSummon() => OnSummon?.Invoke();
        public event Action OnDeath;
        public void RaiseDeath() => OnDeath?.Invoke();
        public event Action OnBlock;
        public void RaiseBlock() => OnBlock?.Invoke();
        public event Action OnEquip;
        public void RaiseEquip() => OnEquip?.Invoke();
    }
}

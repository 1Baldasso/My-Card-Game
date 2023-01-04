using Assets._Scripts.Structures.Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class RoundManager
{
    public void Rally()
    {
        _attackToken = true;
    }
    public void DrawCard(int q = 1)
    {
        Deck.DrawCard(q);
    }

}
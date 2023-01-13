using System;

namespace Assets._Scripts.Managers.GameManagerProps
{
    public partial class GameManager
    {
        public void PerformAction(Action action)
        {
            action();
        }
    }
}

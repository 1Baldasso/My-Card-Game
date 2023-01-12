using System;

namespace Assets._Scripts.Managers.PlayerManagerProps
{
    public partial class PlayerManager
    {
        public event Action OnRoundStartHandled;
        public event Action OnRoundEndHandled;
        public event Action CardDrawnHandled;
        public event Action<int> OnManaChanged;
        public event Action<int> OnSpellManaChanged;
    }
}

using UnityEngine;

namespace Gameplay.Configs
{
    [CreateAssetMenu(fileName = "New AutoCollectorConfig", menuName = "Clicks/Create new AutoCollectorConfig", order = 52)]
    public class AutoCollectorConfig : ScriptableObject
    {
        [SerializeField] private float _delay = 0.1f;
        [SerializeField] private int _reward = 1;

        public float Delay => _delay;
        public int Reward => _reward;

        private void OnValidate()
        {
            if (_delay <= 0)
                _delay = 0.1f;

            if (_reward <= 0)
                _reward = 1;
        }
    }
}
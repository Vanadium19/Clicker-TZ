using Gameplay.Configs;
using Gameplay.Interfaces;
using Zenject;

namespace Gameplay
{
    internal class ClickValue : IClickValue
    {
        private readonly float _multiplyFactor = 0.1f;

        private ClickConfig _clickConfig;
        private AutoCollectorConfig _collectorConfig;

        public int Value => _clickConfig.GetReward() + (int)(_multiplyFactor * _collectorConfig.Reward);

        [Inject]
        private void Construct(ClickConfig clickConfig, AutoCollectorConfig collectorConfig)
        {
            _clickConfig = clickConfig;
            _collectorConfig = collectorConfig;
        }
    }
}
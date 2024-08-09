using UnityEngine;
using Zenject;

public class ClickValue : IClickValue
{
    private readonly float _multiplyFactor = 0.1f;

    private ClickConfig _clickConfig;
    private AutoCollectorConfig _autoCollectorConfig;

    public int Value => _clickConfig.Reward + (int)(_multiplyFactor * _autoCollectorConfig.Reward);

    [Inject]
    private void Construct(ClickConfig clickConfig, AutoCollectorConfig autoCollectorConfig)
    {
        _clickConfig = clickConfig;
        _autoCollectorConfig = autoCollectorConfig;
    }
}
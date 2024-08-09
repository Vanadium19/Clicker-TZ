using System;
using UniRx;
using UnityEngine;
using Zenject;

public class AutoCollector : MonoBehaviour
{
    private AutoCollectorConfig _autoCollectorConfig;
    private ICurrencyAdder _currencyAdder;

    private void Start()
    {
        Observable.Interval(TimeSpan.FromSeconds(_autoCollectorConfig.Delay))
            .Subscribe(time => AddReward())
            .AddTo(this);
    }

    [Inject]
    private void Construct(AutoCollectorConfig autoCollectorConfig, ICurrencyAdder currencyAdder)
    {
        _autoCollectorConfig = autoCollectorConfig;
        _currencyAdder = currencyAdder;
    }

    private void AddReward()
    {
        _currencyAdder.AddCurrency(_autoCollectorConfig.Reward);
    }
}
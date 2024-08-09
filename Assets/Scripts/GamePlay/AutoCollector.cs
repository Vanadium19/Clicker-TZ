using System;
using Gameplay.Configs;
using Gameplay.Interfaces;
using UniRx;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    internal class AutoCollector : MonoBehaviour
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
}
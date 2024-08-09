using Gameplay.Interfaces;
using Settings;
using UniRx;
using UnityEngine;

namespace Gameplay
{
    internal class CurrencyAdder : MonoBehaviour, ICurrencyAdder
    {
        private ReactiveProperty<int> _clicksCount;

        public IReadOnlyReactiveProperty<int> ClicksCount => _clicksCount;

        private void Awake()
        {
            _clicksCount = new ReactiveProperty<int>();

            _clicksCount.Value = GameSaver.ClicksCount;
        }

        public void AddCurrency(int value)
        {
            _clicksCount.Value += value;
            GameSaver.SaveClicks(_clicksCount.Value);
        }
    }
}
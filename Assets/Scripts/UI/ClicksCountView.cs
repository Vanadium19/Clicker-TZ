using Gameplay.Interfaces;
using TMPro;
using UniRx;
using UnityEngine;
using Zenject;

namespace UI
{
    internal class ClicksCountView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _countView;

        [Inject]
        private ICurrencyAdder _clickHandler;

        private void Start()
        {
            _clickHandler.ClicksCount
                .ObserveEveryValueChanged(clicksCount => clicksCount.Value)
                .Subscribe(clicksCount => Render(clicksCount))
                .AddTo(this);
        }

        private void Render(int value)
        {
            _countView.text = value.ToString();
        }
    }
}
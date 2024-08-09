using System;
using UniRx;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

[RequireComponent(typeof(ClickEffectsPool))]
public class ClickHandler : MonoBehaviour, IPointerClickHandler
{
    private IClickValue _clickValue;
    private ICurrencyAdder _currencyAdder;
    private CritConfig _critConfig;
    private ClickEffectsPool _pool;

    private bool _isCritTime;
    private int _critReward;

    private void Awake()
    {
        _pool = GetComponent<ClickEffectsPool>();
    }

    private void Start()
    {
        Observable.Interval(TimeSpan.FromSeconds(_critConfig.Delay))
            .Subscribe(time => { _isCritTime = true; })
            .AddTo(this);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        int clickValue = GetClickValue();

        _currencyAdder.AddCurrency(clickValue);
        _pool.Pull().Play(clickValue);
    }

    [Inject]
    private void Construct(IClickValue clickValue, ICurrencyAdder currencyAdder, CritConfig critConfig)
    {
        _clickValue = clickValue;
        _currencyAdder = currencyAdder;
        _critConfig = critConfig;
    }

    private int GetClickValue()
    {
        int clickValue;

        if (_isCritTime && _critReward > 0)
        {
            clickValue = _critReward / _critConfig.Divider;
            _isCritTime = false;
            _critReward = 0;
        }
        else
        {
            clickValue = _clickValue.Value;
            _critReward += clickValue;

        }

        return clickValue;
    }
}
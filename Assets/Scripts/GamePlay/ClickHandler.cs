using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

[RequireComponent(typeof(ClickEffectsPool))]
public class ClickHandler : MonoBehaviour, IPointerClickHandler
{
    private IClickValue _clickValue;
    private ICurrencyAdder _currencyAdder;
    private ClickEffectsPool _pool;

    private void Awake()
    {
        _pool = GetComponent<ClickEffectsPool>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        _currencyAdder.AddCurrency(_clickValue.Value);
        _pool.Pull().Play(_clickValue.Value);
    }

    [Inject]
    private void Construct(IClickValue clickValue, ICurrencyAdder currencyAdder)
    {
        _clickValue = clickValue;
        _currencyAdder = currencyAdder;
    }
}
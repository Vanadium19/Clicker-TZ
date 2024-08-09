using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

public class ClickHandler : MonoBehaviour, IPointerClickHandler
{
    private IClickValue _clickValue;
    private ICurrencyAdder _currencyAdder;

    public void OnPointerClick(PointerEventData eventData)
    {
        _currencyAdder.AddCurrency(_clickValue.Value);
    }

    [Inject]
    private void Construct(IClickValue clickValue, ICurrencyAdder currencyAdder)
    {
        _clickValue = clickValue;
        _currencyAdder = currencyAdder;
    }
}
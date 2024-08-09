using UniRx;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickHandler : MonoBehaviour, IPointerClickHandler, IClickHandler
{
    private ReactiveProperty<int> _clicksCount;

    public IReadOnlyReactiveProperty<int> ClicksCount => _clicksCount;

    private void Awake()
    {
        _clicksCount = new ReactiveProperty<int>();

        _clicksCount.Value = GameSaver.ClicksCount;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        _clicksCount.Value++;
        GameSaver.SaveClicks(_clicksCount.Value);
    }
}
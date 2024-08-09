using UniRx;

public interface IClickHandler
{
    public IReadOnlyReactiveProperty<int> ClicksCount { get; }
}
using UniRx;

public interface ICurrencyAdder
{
    public IReadOnlyReactiveProperty<int> ClicksCount { get; }

    public void AddCurrency(int value);
}
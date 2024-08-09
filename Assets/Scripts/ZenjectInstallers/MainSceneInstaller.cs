using UnityEngine;
using Zenject;

public class MainSceneInstaller : MonoInstaller
{
    [SerializeField] private ClickConfig _clickConfig;
    [SerializeField] private AutoCollectorConfig _autoCollectorConfig;
    [SerializeField] private CurrencyAdder _currencyAdder;

    public override void InstallBindings()
    {
        Container.Bind<ClickConfig>().FromInstance(_clickConfig);
        Container.Bind<AutoCollectorConfig>().FromInstance(_autoCollectorConfig);
        Container.Bind<ICurrencyAdder>().FromInstance(_currencyAdder);
        Container.Bind<IClickValue>().To<ClickValue>().AsSingle();
    }
}
using UnityEngine;
using Zenject;

public class MainSceneInstaller : MonoInstaller
{
    [SerializeField] private ClickHandler _clickHandler;

    public override void InstallBindings()
    {
        Container.Bind<IClickHandler>().FromInstance(_clickHandler);
    }
}
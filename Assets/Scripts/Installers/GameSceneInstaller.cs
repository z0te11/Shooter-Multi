using UnityEngine;
using Zenject;

public class GameSceneInstaller : MonoInstaller
{
    public Settings settings;
    public bool useDefault;


     public override void InstallBindings()
     {
        if (!useDefault)
        {
            Container.Bind<ISettings>().To<Settings>().FromInstance(settings).AsCached();
        }
        else
        {
            Container.Bind<ISettings>().To<DefaultSettings>().AsSingle()
                    .WithArguments(settings.Player, settings.Enemy)
                    .NonLazy();
        }
        Container.Bind<LoadDataManager>().AsSingle().NonLazy();
     }
}

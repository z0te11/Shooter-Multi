using UnityEngine;
using Zenject;

public class GameSceneInstaller : MonoInstaller
{
    public bool useDefault;
    public Settings setts;


     public override void InstallBindings()
     {
        if (!useDefault)
        {
            Container.Bind<ISettings>().To<Settings>().FromInstance(setts).AsCached();
        }
        else
        {
            Container.Bind<ISettings>().To<DefaultSettings>().AsSingle()
                    .WithArguments(setts.Player, setts.Enemys)
                    .NonLazy();
        }
        Container.Bind<LoadDataManager>().AsSingle().NonLazy();
     }
}

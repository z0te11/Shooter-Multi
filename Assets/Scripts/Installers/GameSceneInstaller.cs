using UnityEngine;
using Zenject;

public class GameSceneInstaller : MonoInstaller
{
    [SerializeField] private SettingsSelector settingsSelector;
    public bool useDefault;


     public override void InstallBindings()
     {
        var settings = settingsSelector.activeSettings;
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

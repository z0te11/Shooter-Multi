using UnityEngine;
using Zenject;

public class GameSceneInstaller : MonoInstaller
{
    [SerializeField] private Settings _settings;

     public override void InstallBindings()
     {
         Container.Bind<Settings>().FromInstance(_settings).AsCached();
         Container.Bind<GameSettings>().AsSingle().NonLazy();
     }
}

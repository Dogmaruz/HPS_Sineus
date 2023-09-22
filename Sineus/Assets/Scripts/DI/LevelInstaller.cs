using Zenject;

public class LevelInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<IEntityFactory>().To<EntityFactory>().AsSingle();
    }
}
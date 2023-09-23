using Zenject;
using UnityEngine;

public class LevelInstaller : MonoInstaller
{
    [SerializeField] private LevelController m_levelController;
    [SerializeField] private PlayerHP m_playerHP;
    [SerializeField] private MarkToFinishPoint m_markToFinishPoint;

    public override void InstallBindings()
    {
        Container.Bind<IEntityFactory>().To<EntityFactory>().AsSingle();
        Container.Bind<LevelController>().FromInstance(m_levelController).AsSingle();
        Container.Bind<PlayerHP>().FromInstance(m_playerHP).AsSingle();
        Container.Bind<MarkToFinishPoint>().FromInstance(m_markToFinishPoint).AsSingle();
    }
}
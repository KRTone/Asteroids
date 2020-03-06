using Assets.Scenarios.Controllers;
using Assets.Scenarios.Interfaces;
using Zenject;

namespace Assets.Scenarios
{
    class CompositionRoot : MonoInstaller 
    {
        public override void InstallBindings()
        {
            Container.Bind<IMoveController>()
                .To<MainMoveController>()
                .AsSingle();

            Container.Bind<IBoomController>()
                .To<MainBoomController>()
                .AsSingle();
        }
    }
}

using Infrastructure.AssetProviders;
using Zenject;

namespace Infrastructure.ZenjectFactories.SceneContext
{
  public class GameLoopZenjectFactory : ZenjectFactory
  {
    public GameLoopZenjectFactory(AssetProvider assetProvider, IInstantiator instantiator) : base(assetProvider, instantiator)
    {
    }
  }
}
using Infrastructure.AssetProviders;
using Zenject;

namespace Infrastructure.ZenjectFactories.GameobjectContext
{
  public class EnemyZenjectFactory : ZenjectFactory, IGameObjectZenjectFactory
  {
    public EnemyZenjectFactory(AssetProvider assetProvider, IInstantiator instantiator) : base(assetProvider, instantiator)
    {
    }
  }
}
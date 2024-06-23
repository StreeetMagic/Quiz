using Infrastructure.AssetProviders;
using Zenject;

namespace Infrastructure.ZenjectFactories.ProjectContext
{
  public class ProjectZenjectFactory : ZenjectFactory
  {
    public ProjectZenjectFactory(AssetProvider assetProvider, IInstantiator instantiator) : base(assetProvider, instantiator)
    {
    }
  }
}
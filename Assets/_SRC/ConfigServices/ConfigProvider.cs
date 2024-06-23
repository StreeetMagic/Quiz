using AssetProviders;
using PersistentProgresses;

namespace ConfigServices
{
  public class ConfigProvider
  {
    private readonly AssetProvider _assetProvider;

    public ConfigProvider(AssetProvider assetProvider)
    {
      _assetProvider = assetProvider;
    }

    public DefaultProjectProgressConfig DefaultProjectProgressConfig { get; private set; }

    public void LoadConfigs()
    {
      DefaultProjectProgressConfig = _assetProvider.GetScriptable<DefaultProjectProgressConfig>("DefaultProjectProgressConfig");
    }
  }
}
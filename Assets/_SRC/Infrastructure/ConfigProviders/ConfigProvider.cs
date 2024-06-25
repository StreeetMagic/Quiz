using Gameplay.Questions;
using Infrastructure.AssetProviders;
using Infrastructure.PersistentProgresses;
using Infrastructure.Projects;

namespace Infrastructure.ConfigProviders
{
  public class ConfigProvider
  {
    private readonly AssetProvider _assetProvider;

    public ConfigProvider(AssetProvider assetProvider)
    {
      _assetProvider = assetProvider;
    }

    public DefaultProjectProgressConfig DefaultProjectProgressConfig { get; private set; }
    public ProjectConfig ProjectConfig { get; private set; }
    public QuestionsConfig QuestionsConfig { get; private set; }

    public void LoadConfigs()
    {
      DefaultProjectProgressConfig = _assetProvider.GetScriptable<DefaultProjectProgressConfig>();
      ProjectConfig = _assetProvider.GetScriptable<ProjectConfig>();
      QuestionsConfig = _assetProvider.GetScriptable<QuestionsConfig>();
    }
  }
}
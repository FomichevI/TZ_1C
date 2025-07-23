using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "GameSettingsInstaller", menuName = "Installers/GameSettingsInstaller")]
public class GameSettingsInstaller : ScriptableObjectInstaller<GameSettingsInstaller>
{
    [SerializeField] private GameSettings _gameSettings;

    public override void InstallBindings()
    {
        Container.Bind<SpawnerConfig>().FromInstance(_gameSettings.SpawnerConfig);
        Container.Bind<SlidingFigureConfig>().FromInstance(_gameSettings.SlidingFigureConfig);
        Container.Bind<GameplayConfig>().FromInstance(_gameSettings.GameplayConfig);
    }
}
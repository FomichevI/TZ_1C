using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

public class SlidingObjectsSpawner : MonoBehaviour
{
    [SerializeField] private Line[] _lines;

    private int _currentLineIndex;
    private SlidingObjectsFactory _factory;
    private SpawnerConfig _config;
    private GameplayConfig _gameplayConfig;

    private CancellationTokenSource _cts;

    [Inject]
    private void Construct(SlidingObjectsFactory slidingObjectsFactory, SpawnerConfig spawnerConfig, GameplayConfig gameplayConfig)
    {
        _factory = slidingObjectsFactory;
        _config = spawnerConfig;
        _gameplayConfig = gameplayConfig;
    }

    private void Start()
    {
        RandomizeNextLine();

        _cts = new CancellationTokenSource();
        CancellationToken token = _cts.Token;
        SpawningAsync(token);
    }


    private async void SpawningAsync(CancellationToken token)
    {
        while (_gameplayConfig.IsPlaying)
        {
            await Task.Delay((int)(_config.GetRandomSpawnDelay()*1000));
            if (_gameplayConfig.IsPlaying && !token.IsCancellationRequested)
            {
                Spawn();
                RandomizeNextLine();
            }
        }
    }

    private void Spawn()
    {
        var slidingGo = _factory.Create();
        slidingGo.Transform.SetParent(_lines[_currentLineIndex].transform);
        slidingGo.Transform.position = _lines[_currentLineIndex].GetStartPosition();
        slidingGo.SetEndPosition(_lines[_currentLineIndex].GetEndPosition());
        slidingGo.StartSlide();
    }

    private void RandomizeNextLine()
    {
        _currentLineIndex = Random.Range(0, _lines.Length);
    }

    private void OnDestroy()
    {
        _cts.Cancel();
    }
}

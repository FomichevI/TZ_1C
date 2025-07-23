using UnityEngine;
using Zenject;

public class FigureHoleSorter : MonoBehaviour, IFigureSorter
{
    // Поля интерфейса
    public IFigureHolder[] Holders => _holders;

    [SerializeField] private FigureHoleHolder[] _holders;

    // Ссылки на глобальные настройки
    private SlidingFigureConfig _figureConfig;
    private GameplayConfig _gameplayConfig;

    [Inject]
    private void Construct(SlidingFigureConfig slidingFigureConfig, GameplayConfig gameplayConfig)
    {
        _figureConfig = slidingFigureConfig;
        _gameplayConfig = gameplayConfig;
    }

    private void Start()
    {
        UpdateHolders();
    }

    public void UpdateHolders()
    {
        if (_holders.Length > _figureConfig.FiguresInfo.Length)
            Debug.LogError("There are not enough FigureInfo in SlidingFigureConfig");
        else if (_holders.Length < _figureConfig.FiguresInfo.Length)
            Debug.LogError("There are not enough Holders in FigureHoleSorter");

        for (int i = 0; i < _holders.Length; i++)
        {
            _holders[i].SetParameters(_figureConfig.FiguresInfo[i], _gameplayConfig.CatchDistance);
        }
    }
}

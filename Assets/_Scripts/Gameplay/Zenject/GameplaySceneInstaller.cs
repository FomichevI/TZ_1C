using Unity.VisualScripting;
using UnityEngine;
using Zenject;

public class GameplaySceneInstaller : MonoInstaller
{
    [SerializeField] private SlidingMovableFigure _slidingFigurePrefab;
    [SerializeField] private FigureHoleSorter _figureHoleSorter;

    public override void InstallBindings()
    {
        Container.BindFactory<ISlidingObject, SlidingObjectsFactory>().FromComponentInNewPrefab(_slidingFigurePrefab);
        Container.Bind<IFigureSorter>().To<FigureHoleSorter>().FromInstance(_figureHoleSorter);
    }
}

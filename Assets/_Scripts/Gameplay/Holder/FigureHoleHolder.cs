using UnityEngine;

public class FigureHoleHolder : MonoBehaviour, IFigureHolder
{
    // Поля интерфейса
    public string FigureIndex => _figureIndex;
    public SpriteRenderer MainSr => _mainSr;
    public float CatchDistance => _catchDistance;
    public Vector2 Position => transform.position;

    [SerializeField] private SpriteRenderer _mainSr;
    private string _figureIndex;
    private float _catchDistance;

    public void SetParameters(FigureInfo figureInfo, float catchDistance)
    {
        _figureIndex = figureInfo.FigureIndex;
        _mainSr.sprite = figureInfo.HoleForFigureSprite;
        _catchDistance = catchDistance;
    }
}

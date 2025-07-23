using UnityEngine;

public class FigureHoleHolder : MonoBehaviour, IFigureHolder
{
    // ���� ����������
    public string FigureIndex => _figureIndex;
    public SpriteRenderer MainSr => _mainSr;
    public float CatchDistance => _catchDistance;

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

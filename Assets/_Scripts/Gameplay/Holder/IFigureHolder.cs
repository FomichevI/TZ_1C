using UnityEngine;

public interface IFigureHolder
{
    string FigureIndex { get; }
    SpriteRenderer MainSr { get; }
    float CatchDistance { get; }

    void SetParameters(FigureInfo figureInfo, float catchDistance);
}

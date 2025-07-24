using UnityEngine;

public interface IFigureHolder
{
    string FigureIndex { get; }
    SpriteRenderer MainSr { get; }
    float CatchDistance { get; }
    Vector2 Position { get; }

    void SetParameters(FigureInfo figureInfo, float catchDistance);
}

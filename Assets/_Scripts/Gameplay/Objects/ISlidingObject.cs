using UnityEngine;

public interface ISlidingObject
{
    Transform Transform { get; }
    float Speed { get; }
    bool IsSliding { get; }

    void StartSlide();
    void SetEndPosition(Vector2 endPosition);
}

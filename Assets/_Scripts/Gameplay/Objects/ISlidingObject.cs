using UnityEngine;

public interface ISlidingObject
{
    Transform Transform { get; }
    float Speed { get; }
    bool IsMoving { get; }

    void StartSlide();
    void SetEndPosition(Vector2 endPosition);
}

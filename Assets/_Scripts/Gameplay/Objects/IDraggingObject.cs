using UnityEngine;

public interface IDraggingObject
{
    Transform Transform { get; }
    bool IsActive { get; }

    void StartDragging();
    void StopDragging();
}

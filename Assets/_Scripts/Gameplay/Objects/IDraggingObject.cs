using UnityEngine;

public interface IDraggingObject
{
    bool IsActive { get; }

    void StartDragging();
    void StopDragging();
}

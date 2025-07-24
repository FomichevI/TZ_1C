using UnityEngine;

public interface IObjectMover
{
    IDraggingObject DraggingObject { get; }

    void CatchDraggingObject(IDraggingObject draggingObject);
    void MoveDraggingObject();
    void ReleaseDraggingObject();
    void TryCatchDraggingObject();
}

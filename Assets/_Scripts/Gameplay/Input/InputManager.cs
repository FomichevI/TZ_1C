using UnityEngine;
using Zenject;

public class InputManager : MonoBehaviour
{
    private IObjectMover _objectMover;

    [Inject]
    private void Construct(IObjectMover objectMover)
    {
        _objectMover = objectMover;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _objectMover.TryCatchDraggingObject();
        }
        else if (Input.GetMouseButton(0))
        {
            _objectMover.MoveDraggingObject();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            _objectMover.ReleaseDraggingObject();
        }
    }
}

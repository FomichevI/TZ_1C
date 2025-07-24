using UnityEngine;
using Zenject;

public class InputManager : MonoBehaviour
{
    private IObjectMover _objectMover;
    private SessionConfig _sessionConfig;

    [Inject]
    private void Construct(IObjectMover objectMover, SessionConfig sessionConfig)
    {
        _objectMover = objectMover;
        _sessionConfig = sessionConfig;
    }

    private void Update()
    {
        if (!_sessionConfig.IsPlaying)
            return;

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

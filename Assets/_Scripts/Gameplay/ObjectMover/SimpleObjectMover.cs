using UnityEngine;

public class SimpleObjectMover : IObjectMover
{
    public IDraggingObject DraggingObject => _draggingObject;

    private IDraggingObject _draggingObject = null;

    private RaycastHit2D _hit;

    public void CatchDraggingObject(IDraggingObject draggingObject)
    {
        _draggingObject = draggingObject;
        _draggingObject.StartDragging();
    }

    public void MoveDraggingObject()
    {
        if (_draggingObject != null)
        {
            Vector2 newPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //newPos.z = 0;
            _draggingObject.Transform.position = newPos;
        }
    }

    public void ReleaseDraggingObject()
    {
        if (_draggingObject != null)
        {
            _draggingObject.StopDragging();
            _draggingObject = null;
        }
    }

    public void TryCatchDraggingObject()
    {
        _hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

        if (_hit.collider != null && _hit.transform.tag == "Dragging")
        {
            IDraggingObject target = _hit.transform.GetComponent<IDraggingObject>();
            if (target.IsActive)
            {
                CatchDraggingObject(target);
            }
        }
    }
}

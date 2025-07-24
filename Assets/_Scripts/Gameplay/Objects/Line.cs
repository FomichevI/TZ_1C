using UnityEngine;

public class Line : MonoBehaviour
{
    [SerializeField] private Transform _startTrans;
    [SerializeField] private Transform _endTrans;

    public Vector2 GetStartPosition()
    {
        return _startTrans.position;
    }

    public Vector2 GetEndPosition()
    {
        return _endTrans.position; 
    }
}

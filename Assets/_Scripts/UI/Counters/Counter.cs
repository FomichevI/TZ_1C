using TMPro;
using UnityEngine;
using Zenject;

public abstract class Counter : MonoBehaviour
{
    [SerializeField] protected TextMeshProUGUI _countTmp;

    protected SessionConfig _sessionConfig;

    [Inject]
    private void Construct(SessionConfig sessionConfig)
    {
        _sessionConfig = sessionConfig;
    }

    public virtual void SetNewCount(int value)
    {
        _countTmp.text = value.ToString();
    }
}

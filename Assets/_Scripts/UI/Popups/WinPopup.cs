using TMPro;
using UnityEngine;
using Zenject;

public class WinPopup : Popup
{
    [SerializeField] private TextMeshProUGUI _scoreTmp;

    private SessionConfig _sessionConfig;

    [Inject]
    private void Construct(SessionConfig sessionConfig)
    {
        _sessionConfig = sessionConfig;
    }
    public override void Show()
    {
        _scoreTmp.text = _sessionConfig.CurrentFiguresCollected.ToString();
        base.Show();
    }
 
    public void OnRestartButtonClick()
    {
        GlobalSignals.OnRestartLevel?.Invoke();
        Hide();
    }
}

public class LosePopup : Popup
{
    public void OnRestartButtonClick()
    {
        GlobalSignals.OnRestartLevel?.Invoke();
        Hide();
    }
}
using System.Threading.Tasks;

public class HitPointsCounter : Counter
{
    private void OnEnable()
    {
        GlobalSignals.OnFigureDetonate.AddListener(UpdateHitPointsAsync);
        GlobalSignals.OnLevelStarted.AddListener(UpdateHitPointsAsync);
    }

    private async void UpdateHitPointsAsync()
    {
        await Task.Yield();
        SetNewCount(_sessionConfig.HitPoints);
    }

    private void OnDisable()
    {
        GlobalSignals.OnFigureDetonate.RemoveListener(UpdateHitPointsAsync);
        GlobalSignals.OnLevelStarted.RemoveListener(UpdateHitPointsAsync);
    }
}

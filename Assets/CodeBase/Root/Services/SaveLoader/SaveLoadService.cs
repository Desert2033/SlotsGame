using UnityEngine;

public class SaveLoadService : ISaveLoadService
{
    private const string ProgressKey = "Progress";
    private IPersistentProgressService _progressService;

    public SaveLoadService(IPersistentProgressService progressService)
    {
        _progressService = progressService;
    }

    public PlayerProgress LoadProgress() =>
        PlayerPrefs.GetString(ProgressKey)?.ToDeserialized<PlayerProgress>();

    public void SavedProgress()
    {
        /*foreach (ISavedProgress progressWriter in _gameFactory.ProgressWriters)
        {
            progressWriter.UpdateProgress(_progressService.Progress);
        }*/

        PlayerPrefs.SetString(ProgressKey, _progressService.Progress.ToJson());
    }
}

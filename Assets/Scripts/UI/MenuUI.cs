using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUI : UI
{
    [SerializeField] private VolumeSettings _volumeSettings;

    private void Start()
    {
        _volumeSettings.Init();
    }

    public void Play(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void Settings()
    {
        Hide();
        _volumeSettings.Show();
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseUI : UI
{
    [SerializeField] private VolumeSettings _volumeSettings;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Continue();
        }
    }

    public void Continue()
    {
        gameObject.SetActive(false);
    }

    public void Settings()
    {
        Hide();
        _volumeSettings.Show();
    }

    public void Menu(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}

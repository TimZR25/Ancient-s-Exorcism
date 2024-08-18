using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUI : MonoBehaviour
{
    [SerializeField] private VolumeSettings _volumeSettings;

    public void Play(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void Settings()
    {
        gameObject.SetActive(false);
        _volumeSettings.gameObject.SetActive(true);
    }
}

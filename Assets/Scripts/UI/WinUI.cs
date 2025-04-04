using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinUI : UI
{
    [SerializeField] private Text _timeText;

    [SerializeField] private Text _recordText;

    [SerializeField] private const string _recordName = "Record";

    public void Init(int time)
    {
        _timeText.text = "you lived " + time.ToString() + " s";

        int record = PlayerPrefs.GetInt(_recordName, 0);

        if (time > record)
        {
            PlayerPrefs.SetInt(_recordName, time);

            _recordText.text = "you record is " + time.ToString() + " s";
        }
        else
        {
            _recordText.text = "you record is " + record.ToString() + " s";
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Menu(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}

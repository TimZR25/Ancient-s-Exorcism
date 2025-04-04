using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverUI : UI
{
    [SerializeField] private Text _timeRecord;

    public void Init(int record)
    {
        _timeRecord.text = "you lived " + record.ToString() + " s";
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

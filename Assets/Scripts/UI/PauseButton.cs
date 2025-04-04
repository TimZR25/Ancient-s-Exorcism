using UnityEngine;
using UnityEngine.UI;

public class PauseButton : MonoBehaviour
{
    [SerializeField] private PauseUI _pauseUI;

    private Button _pauseButton;

    private void Awake()
    {
        _pauseButton = GetComponent<Button>();
    }

    public void Pause()
    {
        if (_pauseUI.gameObject.activeSelf == true)
        {
            _pauseUI.Hide();
        }
        else
        {
            _pauseUI.Show();
        }
    }

    private void OnEnable()
    {
        _pauseButton.onClick.AddListener(Pause);
    }

    private void OnDisable()
    {
        _pauseButton.onClick.RemoveListener(Pause);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }
}

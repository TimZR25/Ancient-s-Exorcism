using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private Text _timeText;

    public int CurrentTime => (int)_time;

    private float _time;

    private void Awake()
    {
        _timeText = GetComponent<Text>();
    }

    private void Update()
    {
        _time += Time.deltaTime;

        _timeText.text = (CurrentTime).ToString();
    }
}

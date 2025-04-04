using UnityEngine;

public abstract class UI : MonoBehaviour
{
    public static bool IsActive;

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void Show()
    {
        if (IsActive == true) return;

        gameObject.SetActive(true);
    }

    private void OnEnable()
    {
        IsActive = true;
        Time.timeScale = 0.0f;
    }

    private void OnDisable()
    {
        IsActive = false;
        Time.timeScale = 1.0f;
    }
}

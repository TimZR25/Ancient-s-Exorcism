using UnityEngine;
using UnityEngine.UI;

public class DamageCanvas : MonoBehaviour
{
    [SerializeField] private Text _text;

    public void ShowDamage(float damage)
    {
        _text.text = damage.ToString();
    }
}

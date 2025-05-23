using System.Collections.Generic;
using Unity.Cinemachine;
using UnityEngine;

public class SpellBook : MonoBehaviour
{
    [SerializeField] private List<Spell> _spells;

    [SerializeField] private SpriteRenderer _spriteRenderer;

    private Camera _mainCamera;

    private CinemachineCamera _camera;

    private AudioManager _audioManager;

    private void Awake()
    {
        _mainCamera = Camera.main;
    }

    private void Update()
    {
        if (Time.deltaTime <= 0) return;

        RotateTo(_mainCamera.ScreenToWorldPoint(Input.mousePosition));

        if (Input.GetMouseButton(0))
        {
            Spell();
        }
    }

    public void Inject(AudioManager audioManager)
    {
        _audioManager = audioManager;
    }

    private void RotateTo(Vector3 to)
    {
        Vector3 mousePosition = to - transform.position;
        mousePosition.Normalize();


        float rotateZ = Mathf.Atan2(mousePosition.y, mousePosition.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotateZ);

        if (rotateZ > -90 && rotateZ < 90)
        {
            _spriteRenderer.flipY = false;

        }
        else
        {
            _spriteRenderer.flipY = true;
        }
    }

    private void Spell()
    {
        if (_spells[0].TryCast())
        {
            _audioManager.PlaySFX(_audioManager.LightBolt);
        }
    }
}

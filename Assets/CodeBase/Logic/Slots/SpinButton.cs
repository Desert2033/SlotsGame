using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

[RequireComponent(typeof(Button))]
public class SpinButton : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _audioClip;

    private Button _button;
    private ISpinService _spinService;

    [Inject]
    public void Construct(ISpinService spinService)
    {
        _spinService = spinService;
    }

    private void Start()
    {
        _button = GetComponent<Button>();

        _button.onClick.AddListener(Spin);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(Spin);
    }

    private void Spin()
    {
        _audioSource.PlayOneShot(_audioClip);

        _spinService.Spin();
    }
}

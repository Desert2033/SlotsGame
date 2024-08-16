using UnityEngine;

public class MusicAllGame : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _audioClip;

    private void Start()
    {
        _audioSource.PlayOneShot(_audioClip);
    }
}

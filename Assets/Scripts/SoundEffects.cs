using UnityEngine;

public class SoundEffects : MonoBehaviour
{
    [SerializeField] private AudioClip[] _listClips;

    private static AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        Debug.Log(_audioSource.clip);
    }

    public  void PlaySound(int index) 
    {
        _audioSource.clip = _listClips[index]; 
        _audioSource.Play();
    }
}

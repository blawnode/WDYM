using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public static SFXManager Main;
    private AudioSource _audioSource;

    public AudioClip _bounce;
    public AudioClip _death;
    public AudioClip _food;
    public AudioClip _punch;
    public AudioClip _step;

    void Start()
    {
        Main = this;
        _audioSource = GetComponent<AudioSource>();
    }

    public void PlaySFX(string name)
    {
        AudioClip clip = null;
        switch(name)
        {
            case "Bounce":
                clip = _bounce;
                break;
            case "Death":
                clip = _death;
                break;
            case "Food":
                clip = _food;
                break;
            case "PUNCH":
                clip = _punch;
                break;
            case "Step":
                clip = _step;
                break;
            default:
                Debug.LogError("Wtf....");
                break;
        }
        _audioSource.PlayOneShot(clip);
    }
}

using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager Main;

    private AudioSource _audioSource;

    public AudioClip _poketown;
    public AudioClip _kickDoorsAndChewHeads;
    public AudioClip _battleRedShield;
    public AudioClip _victory;

    public enum Music
    {
        Poketown,
        KickDoorsAndChewHeads,
        BattleRedShield,
        Victory,
    }

    void Start()
    {
        Main = this;
        _audioSource = GetComponent<AudioSource>();
    }

    public void PlayMusic(string name)
    {
        if(name == "B") PlayMusic(Music.BattleRedShield);
        if(name == "K") PlayMusic(Music.KickDoorsAndChewHeads);
        if(name == "P") PlayMusic(Music.Poketown);
        if(name == "V") PlayMusic(Music.Victory);
    }

    public void PlayMusic(Music music)
    {
        switch(music)
        {
            case Music.BattleRedShield:
                _audioSource.clip = _battleRedShield;
                break;
            case Music.KickDoorsAndChewHeads:
                _audioSource.clip = _kickDoorsAndChewHeads;
                break;
            case Music.Poketown:
                _audioSource.clip = _poketown;
                break;
            case Music.Victory:
                _audioSource.clip = _victory;
                break;
            default:
                throw new System.Exception("Wtf");
        }
        _audioSource.Play();
    }

    public void StopMusic()
    {
        _audioSource.Stop();
    }
}

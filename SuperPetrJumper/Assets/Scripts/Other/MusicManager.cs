using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [SerializeField] private List<Sound> sfxList, musicList;
    [SerializeField] private AudioSource sfxSource, musicSource;
    public AudioSource MusicSource { get { return musicSource; } }
    private static MusicManager music;
    public static MusicManager Music { get { return music; } }

    private void Awake()
    {
        if(music == null)
        {
            music = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        PlayMusic("InitialTheme");
    }

    public void PlayMusic(string nameOfSound)
    {
        Sound sound = musicList.Find(x => x.Name == nameOfSound);
        if(sound == null)
        {
            Debug.Log("Music Not Found");
        }
        else
        {
            musicSource.clip = sound.Clip;
            musicSource.Play();
        }
    }

    public void PlaySFX(string nameOfSound)
    {
        Sound sound = sfxList.Find(x => x.Name == nameOfSound);
        if (sound == null)
        {
            Debug.Log("SFX Not Found");
        }
        else
        {
            sfxSource.clip = sound.Clip;
            sfxSource.Play();
        }
    }
}

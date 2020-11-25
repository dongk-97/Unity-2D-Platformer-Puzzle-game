using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Sound
{
    public string soundName;
    public AudioClip clip;
}

public class AudioManager : MonoBehaviour
{

    public static AudioManager instance;

    [Header("Sound added")]
    [SerializeField] Sound[] bgmSounds;
    [SerializeField] Sound[] sfxSounds;

    [Header("bgm player")]
    [SerializeField]
    public AudioSource bgmPlayer;

    
    [Header("sfx player")]
    [SerializeField]
    public AudioSource[] sfxPlayer;


    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        PlayRandomBGM();
    }

    void Update()
    {
        if (!bgmPlayer.isPlaying)
        {
            PlayRandomBGM();
        }
    }

    public void PlayRandomBGM()
    {
        int random = Random.Range(0, 4);
        bgmPlayer.clip = bgmSounds[random].clip;
        bgmPlayer.Play();

    }

    public void PlaySE(string _soundName)
    {
        for(int i = 0; i<sfxSounds.Length; i++)
        {
            if(_soundName == sfxSounds[i].soundName)
            {
                for(int j = 0; j<sfxPlayer.Length; j++)
                {
                    if (!sfxPlayer[j].isPlaying)
                    {
                        sfxPlayer[j].clip = sfxSounds[i].clip;
                        sfxPlayer[j].Play();
                        return;
                    }
                }
                Debug.Log("All sfx is playing");
                return;
            }
        }
        Debug.Log("sfxNotFound");
    }
}

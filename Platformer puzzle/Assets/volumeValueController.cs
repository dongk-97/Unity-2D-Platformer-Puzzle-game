using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class volumeValueController : MonoBehaviour
{

    private AudioSource audioSrc_bgm;
    private AudioSource[] audioSrc_sfx;
    public float musicVolume_bgm = 0.4f;
    public float musicVolume_sfx = 1f;
    // Start is called before the first frame update
    void Start()
    {
        audioSrc_bgm = GetComponent<AudioManager>().bgmPlayer;
        audioSrc_sfx = GetComponent<AudioManager>().sfxPlayer;
    }

    // Update is called once per frame
    void Update()
    {
        audioSrc_bgm.volume = musicVolume_bgm;
        for(int i = 0; i<audioSrc_sfx.Length; i++)
        {
            audioSrc_sfx[i].volume = musicVolume_sfx;
        }

    }

    public void SetVolume_bgm(float vol)
    {
        musicVolume_bgm = vol;
    }

    public void SetVolume_sfx(float vol)
    {
        musicVolume_sfx = vol;
    }
}

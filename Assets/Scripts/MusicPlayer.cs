using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
        audio = GetComponent<AudioSource>();
        audio.volume = PlayerPrefsController.GetMasterVolume();
    }

    public void SetVolume(float volume)
    {
        audio.volume = volume;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

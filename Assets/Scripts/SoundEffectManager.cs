using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectManager : MonoBehaviour
{
    // Start is called before the first frame update
    AudioSource audioSource;
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Play(AudioClip clip)
    {
        audioSource.clip = clip;
        audioSource.Play();
    }
}

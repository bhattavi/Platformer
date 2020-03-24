using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    // Start is called before the first frame update
    AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(audioSource.volume < 1.0f)
        {
            audioSource.volume = Mathf.Clamp01(audioSource.volume + (0.2f * Time.deltaTime));
        }
    }
}

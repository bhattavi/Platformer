using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public string levelName;
    // Start is called before the first frame update
    public AudioClip myClip;
    public SoundEffectManager soundEffectManager;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        soundEffectManager.Play(myClip);
        SceneManager.LoadScene(levelName);
    }
}

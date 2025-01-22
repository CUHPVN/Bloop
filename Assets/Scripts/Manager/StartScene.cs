using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Play()
    {
        SceneManager.LoadScene("Game");
    }
    public void PlayButtonSound()
    {
        SoundManager.Instance.PlayButtonSound();

    }
    public void PlayAnvilSound()
    {
        SoundManager.Instance.PlayAnvilSound();

    }
    public void PlayChillSound()
    {
        SoundManager.Instance.PlayMusicByIndex(0);

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance { get { return instance; } }
    [SerializeField] private WoodSpawner wood;
    [SerializeField] private IronSpawner iron;
    [SerializeField] private SunLSpawner sunl;
    private bool isPause = false, isChill = true;
    public int level = 1;
    [SerializeField] private float time = 60f;
    
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isChill)
        {
            time -= Time.deltaTime;

        }
        if (time <= 0)
        {
            isChill = false;
        }
        if (isPause)
        {
            Time.timeScale = 0;
        }else Time.timeScale = 1;
    }
    public bool GetPause()
    {
        return isPause;
    }
    public void SetPause(bool value)
    {
        isPause = value;
    }
    public float GetTime()
    {
        return (int)time;
    }
    public float GetFloatTime()
    {
        return time;
    }
    public void EndWave()
    {
        isChill = true;
        time = 60f;
        level++;
        wood.DespawnWood();
        wood.SpawnWood();
        iron.DespawnIron();
        iron.SpawnIron();
        sunl.DespawnSunL();
        sunl.SpawnSunL();
        if(level == 6)
        {
            Win();
        }
    }
    public bool GetChill()
    {
        return isChill;
    }
    public void SetChill(bool value)
    {
        isChill = value;
    }
    public void GotoMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void PlayAgain()
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
    private void Win()
    {
        PlayChillSound();
        SceneManager.LoadScene("Win");
    }

}

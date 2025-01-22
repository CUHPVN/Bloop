using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private Slider musicSlider, sfxSlider;
    public static SoundManager Instance { get; private set; }

    [Header("Audio Sources")]
    public AudioSource musicSource;      // For background music
    public AudioSource effectsSource;    // For sound effects

    [Header("Volume Settings")]
    [Range(0f, 1f)] public float musicVolume = 1f;
    [Range(0f, 1f)] public float effectsVolume = 1f;
    [SerializeField] private List<AudioClip> musicClipList;
    [SerializeField] private List<AudioClip> effectClipList;
    void Start()
    {

        PlayMusic(musicSource.clip);
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.Find("Music Slider")!=null&& GameObject.Find("Music Slider").TryGetComponent<Slider>(out Slider slider1))
        {
            musicSlider = slider1;
        }
        if (GameObject.Find("Sfx Slider") != null && GameObject.Find("Sfx Slider").TryGetComponent<Slider>(out Slider slider2))
        {
            sfxSlider = slider2;
        }
        if (musicSlider!= null)
        musicVolume = musicSlider.value;
        if(sfxSlider!=null)
        effectsVolume = sfxSlider.value;
        musicSource.volume = musicVolume;
        effectsSource.volume = effectsVolume;

    }
    public void PlayButtonSound()
    {
        PlaySoundEffectByIndex(0);
    }
    public void PlayDeathSound()
    {
        PlaySoundEffectByIndex(1);
    }
    public void PlayHitSound()
    {
        PlaySoundEffectByIndex(2);
    }
    public void PlayAnvilSound()
    {
        PlaySoundEffectByIndex(3);
    }


    private void Awake()
    {
        // Ensure only one instance exists
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Make persistent
        }
        else
        {
            Destroy(gameObject); // Destroy duplicate
        }
    }
    public void PlayMusicByIndex(int value)
    {
        if (value >= musicClipList.Count) return;
        PlayMusic(musicClipList[value]);
    }
    public void PlayMusic(AudioClip clip)
    {
        musicSource.clip = clip;
        musicSource.volume = musicVolume;
        musicSource.loop = true; // Background music should loop
        musicSource.Play();
    }
    public void PlaySoundEffectByIndex(int value)
    {
        if (value >= effectClipList.Count) return;
        PlaySoundEffect(effectClipList[value]);
    }
    public void PlaySoundEffect(AudioClip clip)
    {
        effectsSource.PlayOneShot(clip, effectsVolume);
    }

   
}

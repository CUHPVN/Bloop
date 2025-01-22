using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private static UIManager instance;
    public static UIManager Instance { get { return instance; } }
    [SerializeField] protected float shakeDuration = 0.2f, shakeMagnitude = 0.1f;
    [SerializeField] private Transform source;
    [SerializeField] private Transform hpBar;
    [SerializeField] private TMP_Text timeText;
    [SerializeField] private Transform deathPanel,blur;

    [SerializeField] private List<Transform> heart = new List<Transform>();

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        LoadHp();
    }

    void Update()
    {
        if (PlayerData.Instance.GetDeath()&& !GameManager.Instance.GetPause())
        {

            Invoke(nameof(Death),0.5f);
            //SoundManager.Instance.PlaySoundEffectByIndex(1);
        }
        SourceUpdate();
        HpUpdate();
        TimeUpdatde();
    }
    void Death()
    {
        deathPanel.gameObject.SetActive(true);
        blur.gameObject.SetActive(true);
        GameManager.Instance.SetPause(true);
    }
    void SourceUpdate()
    {
        if(source.GetChild(0).GetChild(0).GetComponent<TMP_Text>().text != PlayerData.Instance.GetSunL().ToString())
        {
            StartCoroutine(source.GetChild(0).GetComponent<ShakeObject>().Shake(shakeDuration,shakeMagnitude));

            source.GetChild(0).GetChild(0).GetComponent<TMP_Text>().text = PlayerData.Instance.GetSunL().ToString();
        }
        if (source.GetChild(1).GetChild(0).GetComponent<TMP_Text>().text != PlayerData.Instance.GetIron().ToString())
        {
            StartCoroutine(source.GetChild(1).GetComponent<ShakeObject>().Shake(shakeDuration, shakeMagnitude));

            source.GetChild(1).GetChild(0).GetComponent<TMP_Text>().text = PlayerData.Instance.GetIron().ToString();
        }
        if (source.GetChild(2).GetChild(0).GetComponent<TMP_Text>().text != PlayerData.Instance.GetWood().ToString())
        {
            StartCoroutine(source.GetChild(2).GetComponent<ShakeObject>().Shake(shakeDuration, shakeMagnitude));

            source.GetChild(2).GetChild(0).GetComponent<TMP_Text>().text = PlayerData.Instance.GetWood().ToString();
        }
      
    }
    void HpUpdate()
    {
        if (PlayerData.Instance.GetHp() < 0) return;
        while (PlayerData.Instance.GetHp() < HPCount())
        {
            HPOff();
        }
        while (PlayerData.Instance.GetHp() > HPCount())
        {
            HPOn();
        }
    }
    private void TimeUpdatde()
    {
        if (GameManager.Instance.GetFloatTime() > 0)
            timeText.text = GameManager.Instance.GetTime().ToString();
        else timeText.text = "";
    }
    int HPCount()
    {
        int i = 0;
        foreach(Transform t in heart)
        {
            if (t.gameObject.activeSelf) i++;
        }
        return i;
    }
    void HPOff()
    {
        foreach (Transform t in heart)
        {
            if (t.gameObject.activeSelf)
            {
                t.gameObject.SetActive(false);
                break;
            }
        }
    }
    void HPOn()
    {
        foreach (Transform t in heart)
        {
            if (!t.gameObject.activeSelf)
            {
                t.gameObject.SetActive(true);
                break;
            }
        }
    }
    void LoadHp()
    {
        foreach(Transform t in hpBar)
        {
            heart.Add(t);
        }
    }
    public bool GetCompareWood(TMP_Text item1)
    {
        if (PlayerData.Instance.GetWood() >= Convert.ToInt32(item1.text)) return true;
        return false;
    }
    public bool GetCompareIron(TMP_Text item1)
    {
        if (PlayerData.Instance.GetIron() >= Convert.ToInt32(item1.text)) return true;
        return false;
    }
    public bool GetCompareSunL(TMP_Text item1)
    {
        if (PlayerData.Instance.GetSunL() >= Convert.ToInt32(item1.text)) return true;
        return false;
    }
}

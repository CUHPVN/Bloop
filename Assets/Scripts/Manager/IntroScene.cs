using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IntroScene : MonoBehaviour
{
    [SerializeField] private List<Transform> images = new List<Transform>();
    [SerializeField] private Transform image;
    [SerializeField] private Animator animator;
    [SerializeField] private int any = 0;
    void Start()
    {
        image.GetComponent<RawImage>().texture = images[any].GetComponent<RawImage>().texture;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            any++;
            LoadImage();
        }
        
    }
    void LoadImage()
    {
        animator.SetBool("Any", false);
        if (any > images.Count-1)
        {
            Invoke(nameof(Play),0.5f);
        }else
        {
            animator.SetBool("Any",true);
            Invoke("OffAny",1f);
        }
    }
    void OffAny()
    {
        image.GetComponent<RawImage>().texture = images[any].GetComponent<RawImage>().texture;
        animator.SetBool("Any", false);
    }
    void Play()
    {
        SceneManager.LoadScene("Game");
    }
}

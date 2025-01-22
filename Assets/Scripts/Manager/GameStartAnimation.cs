using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStartAnimation : MonoBehaviour
{
    [SerializeField] private Image spriteRenderer;
    [SerializeField] private List<Sprite> norm;
    [SerializeField] private List<Sprite> drop;
    [SerializeField] private bool onChange=false;
    
    private float frameRate = 8;
    float idleTime;

    Vector2 direction;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        SetSprite();

    }
    void SetSprite()
    {
        List<Sprite> directionSprites;
        if (onChange)
        {
            directionSprites = drop;
        }
        else
        directionSprites = norm;
        if (directionSprites != null)
        {
            float playTime = Time.time - idleTime;
            int frame = (int)((playTime * frameRate) % directionSprites.Count);
            spriteRenderer.sprite = directionSprites[frame];
        }
        else
        {
            idleTime = Time.time;
        }
    }
    public void ChangeScene()
    {
        onChange = true;   
    }
}

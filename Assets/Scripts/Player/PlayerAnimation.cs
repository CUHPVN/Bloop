using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private List<Sprite> up;
    [SerializeField] private List<Sprite> down;
    [SerializeField] private List<Sprite> horizontal;
    [SerializeField] private List<Sprite> uph;
    [SerializeField] private List<Sprite> downh;
    [SerializeField] private List<Sprite> idle;
    [SerializeField] private List<Sprite> death;

    private float frameRate =8;
    float idleTime;

    Vector2 direction;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        direction = new Vector2(InputManager.Instance.x,InputManager.Instance.y);

        HandleSpriteFlip();
        SetSprite();
    }
    void SetSprite()
    {
        List<Sprite> directionSprites = GetSprite();
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
    void HandleSpriteFlip()
    {
        if (!spriteRenderer.flipX && direction.x < 0)
        {
            spriteRenderer.flipX = true;
        }
        else
        if (spriteRenderer.flipX && direction.x > 0)
        {
            spriteRenderer.flipX = false;
        }
    }
    List<Sprite> GetSprite()
    {
        List<Sprite> selectedSprites = null;
        if (GetComponent<PlayerData>().GetDeath()) { return death; }
        if (direction.y > 0)
        {
            if (Mathf.Abs(direction.x) > 0)
            {
                selectedSprites = uph;
            }
            else
            {
                selectedSprites = up;
            }
        }
        else
        if (direction.y < 0)
        {
            if (Mathf.Abs(direction.x) > 0)
            {
                selectedSprites = downh;
            }
            else
            {
                selectedSprites = down;
            }
        }
        else
        if (direction.x == 0&& direction.y == 0)
        {
            selectedSprites = idle;
        }
        else
        {
            if (Mathf.Abs(direction.x) > 0)
            {
                selectedSprites = horizontal;
            }

        }

        return selectedSprites;
    }
}

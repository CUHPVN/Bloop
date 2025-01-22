using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private static InputManager instance;
    public float x, y;
    public bool lClick = false;
    public bool rClick = false;
    public bool lShift = false;
    public Vector2 mousePos;

    private Camera cam;
    public static InputManager Instance {  get { return instance; } }
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        cam = Camera.main;

    }
    void Update()
    {
        if (GameManager.Instance.GetPause())
        {
            x = 0; y = 0; lClick = false; rClick = false; lShift = false; mousePos = Vector2.zero;
        }
        else
        {
            mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
            TakeMove();
            TakeButton();
            TakeClick();
        }
    }
    private void TakeMove()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");
    }
    private void TakeButton()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            lShift = true;
        }
        else
        {
            lShift = false;
        }
    }
    private void TakeClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            lClick = true;
        }
        else
        {
            lClick = false;
        }
        if (Input.GetMouseButtonDown(1))
        {
            rClick = true;
        }
        else
        {
            rClick = false;
        }
    }

}

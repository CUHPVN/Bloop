using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    private static LevelManager instance;
    public static LevelManager Instance { get { return instance; } }

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    public string GetName(int level,int index)
    {
        string temp="Null";
        switch (level)
        {
            case 1:
                {
                    
                    if(index < 10)
                    {
                        temp = "Fork";
                    }

                    break;
                }
            case 2:
                {
                    if (index < 10)
                    {
                        temp = "Fork";
                    }else
                    if (index < 15)
                    {
                        temp = "Nail";
                    }
                    break;
                }
            case 3:
                {
                    if (index < 5)
                    {
                        temp = "Fork";
                    }
                    else
                    if (index < 10)
                    {
                        temp = "Nail";
                    }
                    else 
                    if (index <15)
                    {
                        temp = "Cactus";
                    }

                    break;
                }
            case 4:
                {
                    if (index < 10)
                    {
                        temp = "Fork";
                    }else
                    if (index < 15)
                    {
                        temp = "Nail";
                    }
                    else
                    if (index < 25)
                    {
                        temp = "Cactus";
                    }
                    break;
                }
            case 5:
                {
                    if (index < 15)
                    {
                        temp = "Fork";
                    }else
                    if (index < 30)
                    {
                        temp = "Nail";
                    }
                    else
                    if (index < 50)
                    {
                        temp = "Cactus";
                    }
                    
                    break;
                }
            default:
                {
                    if (index < 25)
                    {
                        temp = "Fork";
                    }else
                    if (index < 50)
                    {
                        temp = "Nail";
                    }
                    else
                    if (index < 75)
                    {
                        temp = "Cactus";
                    }
                    break;
                }
        }  
        return temp;
    }
    public int GetCount(int level)
    {
        int temp = 0;
        switch (level)
        {
            case 1:
                {
                    temp = 10;
                    break;
                }
            case 2:
                {
                    temp = 15;
                    break;
                }
            case 3:
                {
                    temp = 15;
                    break;
                }
            case 4:
                {
                    temp = 25;
                    break;
                }
            case 5:
                {
                    temp = 50;
                    break;
                }
            default:
                {
                    temp = 75;
                    break;
                }
        }
        return temp;
    }
}

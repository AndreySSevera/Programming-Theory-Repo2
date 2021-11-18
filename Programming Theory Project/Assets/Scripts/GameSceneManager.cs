using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneManager : MonoBehaviour
{
    public static GameSceneManager instance;

    private int countSlab = 0;
    public int CountSlab
    {
        get 
        { 
            return countSlab; 
        }
        set 
        { 
            if (value < 1 && value > 1)
            {
                Debug.LogError("ERROR VALUE");
            }
            else
            {
                countSlab += value;
            }
        }
    }
    private float countMass = 0;
    public float CountMass
    {
        get 
        {
            return countMass; 
        }
        set
        {
            if (value < 0)
            {
                Debug.LogError("ERROR MASS");
            }
            else
            {
                countMass += value;
            }
        }
    }
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        
        DontDestroyOnLoad(this);
    }
    public interface IInformer
    {
        string Info();
    }
    
}

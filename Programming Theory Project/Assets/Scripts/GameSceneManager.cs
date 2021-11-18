using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{
    public static GameSceneManager instance;

    public Text countSlabText;
    public Text countMassText;

    private int countSlab;
    private float countMass;

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
    public interface IInformer
    {
        string Info();
    }

    private void Awake()
    {
        instance = this;

        CountMass = MenuScript.instance.countMass;
        CountSlab = MenuScript.instance.countSlabs;

        countMassText.text = "Mass of slabs : " + CountMass;
        countSlabText.text = "Slabs : " + CountSlab;

    }

    public void TextCountSM(float mass,int slab)
    {
        CountMass += mass;
        CountSlab += slab;

        countMassText.text = "Mass of slabs : " + CountMass;
        countSlabText.text = "Slabs : " + CountSlab;
    }
    public void BackToMenu()
    {
        MenuScript.instance.countMass = CountMass;
        MenuScript.instance.countSlabs = CountSlab;

        SceneManager.LoadScene(0);
    }

}

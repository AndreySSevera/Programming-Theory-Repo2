using UnityEngine;
using System.Collections;

public class Machinery : MonoBehaviour,GameSceneManager.IInformer
{
    public Transform pointLoading;
    public GameObject slab;


    public string Info()
    {
        return transform.name;
    }
    
}

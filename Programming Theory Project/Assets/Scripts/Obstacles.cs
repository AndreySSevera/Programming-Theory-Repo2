using UnityEngine;

public class Obstacles : MonoBehaviour
{
    [SerializeField]
    private string particalName;
    [SerializeField]
    private float mass;
    public float Mass
    {
        get
        { 
            return mass; 
        }
        set
        {
            if(value > 0)
            {
                mass = value;
            }
            else
            {
                Debug.LogError("Negative Value");
                mass = 1;
            }
        }
    }
    public string ParticalName
    {
        get
        {
            return particalName;
        }
        set
        {
            if (value.Length > 0)
            {
                particalName = value;
            }
            else
            {
                particalName = "Uknow Name";
                Debug.LogError("Name null");
            }
        }
    }
    public virtual void GetInfo() { }
}

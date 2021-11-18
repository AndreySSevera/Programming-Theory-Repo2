using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckScript : MonoBehaviour
{
    public GameObject slab;
    public Transform pointLoading;
    public void LoadingSlabs()
    {
        for (float h = .1f; h <= .9f; h += .2f)
        {
            GameObject _slab = Instantiate(slab, pointLoading.position + Vector3.up * h + Vector3.right * Random.Range(-.1f, .1f) + Vector3.forward * Random.Range(-.1f, .1f), pointLoading.rotation);
            _slab.transform.SetParent(pointLoading);
        }
    }
    public void UnloadingSlabs()
    {
        foreach (Transform child in pointLoading)
        {
            Destroy(child.gameObject);
        }
    }
}

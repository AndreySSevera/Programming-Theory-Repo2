using UnityEngine;

public class TruckScript : MonoBehaviour
{
    public GameObject slab;
    public Transform pointLoading;
    public Vector3 outPoint;
    public Vector3 constractionPoint;

    public float speedMove;

    private int totalSlabs = 0;

    private bool empty = true;
    private bool move = false;
    private void Start()
    {
        if (empty)
        {
            LoadingSlabs();
            
        }
    }
    private void Update()
    {
        if (move)
        {
            MoveToConstraction();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            foreach(Transform child in pointLoading)
            {
                Destroy(child.gameObject);
                UnloadingSlabs();
            }
        }
    }
    public void LoadingSlabs()
    {
        for (float h = .1f; h <= .9f; h += .2f)
        {
            GameObject _slab = Instantiate(slab, pointLoading.position + Vector3.up * h + Vector3.right * Random.Range(-.1f, .1f) + Vector3.forward * Random.Range(-.1f, .1f), pointLoading.rotation);
            _slab.transform.SetParent(pointLoading);
        }
        totalSlabs = pointLoading.childCount;
        move = true;
        empty = false;
    }
    public void MoveToConstraction()
    {
        if (move && !empty)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speedMove);
            if (transform.position.x < 0)
            {
                transform.position = constractionPoint;
                move = false;
            }
        }
        else if(move && empty)
        {
            transform.Translate(Vector3.right * Time.deltaTime * speedMove);
            if (transform.position.x > 50)
            {
                transform.position = outPoint;
                move = false;
                LoadingSlabs();
            }
        }

    }

    public void UnloadingSlabs()
    {
        totalSlabs = pointLoading.childCount;
        Debug.Log(pointLoading.childCount);
        if (totalSlabs == 0)
        {
            empty = true;
            move = true;
        }
    }
}

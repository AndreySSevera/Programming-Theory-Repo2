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
    }
    private void LoadingSlabs()
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
    private void MoveToConstraction()
    {
        if (move && !empty)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speedMove,Space.World);
            if (transform.position.x < 0)
            {
                transform.position = constractionPoint;
                move = false;
            }
        }
        else if (move && empty)
        {
            transform.Translate(Vector3.right * Time.deltaTime * speedMove,Space.World);
            if (transform.position.x > 50f)
            {
                transform.position = outPoint;
                move = false;
                LoadingSlabs();
            }
        }

    }

    public void UnloadingSlabs()
    {
        totalSlabs -= 1;
        Debug.Log(totalSlabs);
        if (totalSlabs == 0)
        {
            empty = true;
            move = true;
        }
    }
}

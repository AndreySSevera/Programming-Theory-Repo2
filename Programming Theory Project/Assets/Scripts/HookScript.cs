using UnityEngine;

public class HookScript : MonoBehaviour
{
    public GameObject lookPoint;
    public GameObject hook;
    [SerializeField]
    private float speedMoove;

    private Vector3 targetPos;
    private Vector3 vectorToMove;
    private float lenghPath;

    private bool move = false;

    public float SpeedMoove
    {
        get
        {
            return speedMoove;
        }
        set
        {
            if (value >= 0)
            {
                speedMoove = value;
            }
            else
            {
                speedMoove = 0;
            }
        }
    }
    private void Start()
    {
        SpeedMoove = 4f;
    }
    void Update()
    {
        if (move)
        {
            Move();
        }
    }
    public void SetPointToGo(Vector3 pointToMove)
    {
        targetPos = new Vector3(pointToMove.x, 0, pointToMove.z);

        lookPoint.transform.LookAt(targetPos);
        lenghPath = Vector3.Magnitude(targetPos - lookPoint.transform.position);

        move = true;
    }
    private void Move()
    {
        float step = Time.deltaTime * speedMoove;
        lenghPath -= step;
        if (lenghPath <= 0)
        {
            lookPoint.transform.position = targetPos;
            move = false;
            lenghPath = 0;
        }
        else
        {
            lookPoint.transform.Translate(Vector3.forward * step, Space.Self);
        }

        hook.transform.position = new Vector3(lookPoint.transform.position.x, hook.transform.position.y, lookPoint.transform.position.z);
    }
}

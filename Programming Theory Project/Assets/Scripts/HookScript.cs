using UnityEngine;

public class HookScript : MonoBehaviour
{
    public GameObject lookPoint;
    public GameObject hook;
    public Vector3 hookPark;

    [SerializeField]
    private float speedMoove;

    private Vector3 targetPos;

    private GameObject targetObject;

    private float targetYpos;
    private float selfPosY;
    private float lenghPath;
    private float lenghPathCatch;

    private bool move = false;
    private bool target = false;
    private bool overTarget = false;
    private bool catchTarget = false;

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
        selfPosY = hook.transform.position.y;
    }
    void Update()
    {
        if (move)
        {
            Move();
        }
        else if (overTarget)
        {
            CatchTarget();
        }
    }
    public void SetPointToGo(Vector3 pointToMove)
    {
        targetPos = new Vector3(pointToMove.x, 0, pointToMove.z);

        lookPoint.transform.LookAt(targetPos);
        lenghPath = Vector3.Magnitude(targetPos - lookPoint.transform.position);

        move = true;
    }
    public void SetPointToGo(GameObject pointToMove, bool ifTarget)
    {
        targetObject = pointToMove;
        targetPos = new Vector3(pointToMove.transform.position.x, 0, pointToMove.transform.position.z);
        targetYpos = pointToMove.transform.position.y + .1f;
        target = ifTarget;
        lenghPathCatch = selfPosY - targetYpos;

        lookPoint.transform.LookAt(targetPos);
        lenghPath = Vector3.Magnitude(targetPos - lookPoint.transform.position);

        move = true;
    }
    public void CatchTarget()
    {

        float step = Time.deltaTime * speedMoove;

        if (!catchTarget)
        {
            if (lenghPathCatch > 0)
            {
                lenghPathCatch -= step;
                hook.transform.Translate(Vector3.down * step);
            }
            else
            {
                hook.transform.position = new Vector3(hook.transform.position.x, targetYpos + .1f, hook.transform.position.z);
                targetObject.GetComponentInParent<TruckScript>().UnloadingSlabs();
                targetObject.transform.SetParent(hook.transform);
                lenghPathCatch = selfPosY - targetYpos;
                catchTarget = true;
            }
        }
        else
        {
            if (lenghPathCatch > 0)
            {
                lenghPathCatch -= step;
                hook.transform.Translate(Vector3.up * step);
            }
            else
            {
                hook.transform.position = new Vector3(hook.transform.position.x, selfPosY, hook.transform.position.z);
                overTarget = false;
                target = false;
                SetPointToGo(hookPark);
            }
        }

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
            if (target)
            {
                overTarget = true;
            }
            else if (catchTarget)
            {
                GameSceneManager.instance.TextCountSM(targetObject.GetComponent<Slab>().Mass / 1000, 1);
                Destroy(targetObject);
                catchTarget = false;
                Debug.Log(move + " " + target + " " + overTarget + " " + catchTarget);
            }
        }
        else
        {
            lookPoint.transform.Translate(Vector3.forward * step, Space.Self);
        }

        hook.transform.position = new Vector3(lookPoint.transform.position.x, hook.transform.position.y, lookPoint.transform.position.z);
    }
}

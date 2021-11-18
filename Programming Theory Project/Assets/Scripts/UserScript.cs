using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserScript : MonoBehaviour
{
    public GameObject hook;

    public GameObject predmet;
    public Camera cam;
    public Text namePartical;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            PredmetChangePosition();
        }
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            
        }
    }
    private void PredmetChangePosition()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out RaycastHit hit, 100f))
        {
            namePartical.text = hit.transform.name;
            predmet.transform.position = hit.point;
            if (!hit.transform.name.Contains("Slab"))
            {
                hook.GetComponent<HookScript>().SetPointToGo(hit.point);
            }
            else
            {
                hook.GetComponent<HookScript>().SetPointToGo(hit.transform.gameObject, true);
            }
        }
    }
}

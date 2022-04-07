using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class raycast : MonoBehaviour
{
    RaycastHit hit;
    MeshRenderer MR;
    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(transform.position, Vector3.up, out hit, 100f))
        {
            //hit.transform.gameObject.SetActive(false);
            MR = hit.transform.gameObject.GetComponent<MeshRenderer>();
            MR.enabled = false;
        }
        else
        {
            MR.enabled = true;
        }
    }
}

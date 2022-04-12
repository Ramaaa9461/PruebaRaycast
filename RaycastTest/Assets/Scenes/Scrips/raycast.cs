using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class raycast : MonoBehaviour
{

    [SerializeField] Camera cam;
    [Range(0, 1)] [SerializeField] float transparencia = 0;

    bool MR_active = false;

    MeshRenderer[] TotalmeshRenderers;// = new MeshRenderer[];
    RaycastHit[] TotalRaycastHits;//= new RaycastHit[1];

    private void Awake()
    {

    }
    void Update()
    {
        // simpleRaycast();
        // gradientRaycast();

        multipleRaycasts();
    }

    void multipleRaycasts()
    {

        TotalRaycastHits = Physics.RaycastAll(transform.position, Vector3.up, 100f);
        if (TotalRaycastHits != null)
        {
            if (TotalRaycastHits.Length != 0)
            {
                for (int i = 0; i < TotalRaycastHits.Length; i++)
                {
                    if (TotalmeshRenderers != null)
                    {
                        TotalmeshRenderers[i] = TotalRaycastHits[i].transform.gameObject.GetComponent<MeshRenderer>();
                    }
                }

                if (transparencia > 0)
                {
                    transparencia -= Time.deltaTime;
                }

                if (TotalmeshRenderers != null)
                {
                    for (int i = 0; i < TotalmeshRenderers.Length; i++)
                    {
                        TotalmeshRenderers[i].material.color = new Color(TotalmeshRenderers[i].material.color.r, TotalmeshRenderers[i].material.color.g, TotalmeshRenderers[i].material.color.b, transparencia);
                    }
                }
            }
            else
            {
                if (transparencia < 1)
                {
                    transparencia += Time.deltaTime / 2;
                }

                //for (int i = 0; i < TotalmeshRenderers.Length; i++)
                //{
                //    TotalmeshRenderers[i].material.color = new Color(TotalmeshRenderers[i].material.color.r, TotalmeshRenderers[i].material.color.g, TotalmeshRenderers[i].material.color.b, transparencia);
                //}
            }
        }

    }

    RaycastHit hit;
    MeshRenderer MR;
    void simpleRaycast()
    {

        if (Physics.Raycast(transform.position, Vector3.up, out hit, 100f) || Physics.Linecast(transform.position, cam.transform.position, out hit))
        {

            MR = hit.transform.gameObject.GetComponent<MeshRenderer>();

            MR.enabled = false;
        }
        else
        {
            MR.enabled = true;

        }
    }
    void gradientRaycast()
    {
        if (Physics.Raycast(transform.position, Vector3.up, out hit, 100f) || Physics.Linecast(transform.position, cam.transform.position, out hit))
        {
            MR = hit.transform.gameObject.GetComponent<MeshRenderer>();

            if (transparencia > 0)
            {
                transparencia -= Time.deltaTime;
            }

            MR.material.color = new Color(MR.material.color.r, MR.material.color.g, MR.material.color.b, transparencia);
            MR_active = true;
        }
        else
        {
            if (transparencia < 1)
            {
                transparencia += Time.deltaTime / 2;
            }
            if (MR_active)
            {
                MR.material.color = new Color(MR.material.color.r, MR.material.color.g, MR.material.color.b, transparencia);
            }

        }
    }
}

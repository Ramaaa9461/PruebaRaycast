using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class raycast : MonoBehaviour
{


    [Range(0, 1)] [SerializeField] float transparencia = 0;
    [Range(0, 1)] [SerializeField] float transitionSpeed = 1;

    bool MR_active = false;

    MeshRenderer[] TotalmeshRenderers;
    RaycastHit[] TotalRaycastHits;

    private void Awake()
    {

    }
    void Update()
    {
        gradientRaycast();


    }

    void multipleRaycasts()
    {

        TotalRaycastHits = Physics.RaycastAll(transform.position, Vector3.up, 100f);

        if (TotalRaycastHits.Length != 0)
        {
            for (int i = 0; i < TotalRaycastHits.Length; i++)
            {
                // TotalmeshRenderers[i] = TotalRaycastHits[i].transform.gameObject.GetComponent<MeshRenderer>();
            }

            if (transparencia > 0)
            {

                transparencia -= Time.deltaTime;
            }
            for (int i = 0; i < TotalmeshRenderers.Length; i++)
            {
                TotalmeshRenderers[i].material.color = new Color(TotalmeshRenderers[i].material.color.r, TotalmeshRenderers[i].material.color.g, TotalmeshRenderers[i].material.color.b, transparencia);
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

    RaycastHit hit;
    MeshRenderer MR;
    void simpleRaycast()
    {

        if (Physics.Raycast(transform.position, Vector3.up, out hit, 100f))
        {

            MR = hit.transform.gameObject.GetComponent<MeshRenderer>();

            MR.gameObject.SetActive(true);
        }
        else
        {
            MR.gameObject.SetActive(false);

        }
    }
    void gradientRaycast()
    {
        if (Physics.Raycast(transform.position, Vector3.up, out hit, 100f))
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

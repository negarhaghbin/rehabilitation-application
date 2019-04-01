using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camScript : MonoBehaviour
{
    public GameObject plane;
    // Start is called before the first frame update
    void Start()
    {
        WebCamTexture wct=new WebCamTexture();
        plane.GetComponent<MeshRenderer>().material.mainTexture=wct;
        wct.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

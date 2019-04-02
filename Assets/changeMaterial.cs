using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class changeMaterial : MonoBehaviour
{
    public Material[] materials;
    //material[0] should be entered, material[1] is entered, material[2] is exited
    public Text lastText;
    Renderer rend;
    public GameObject button;
    public GameObject target;
    private GameObject current;
    public int blocks;

    void Start()
    {
        current=GameObject.Find("lp1");
        rend=current.GetComponent<Renderer>();
        rend.enabled=true;
        lastText.text="";
        button.SetActive(false);
        rend.sharedMaterial=materials[0];
            
    }

    void Update(){
        if (rend.sharedMaterial==materials[0] & ((target.transform.position.x-0.5)<current.transform.position.x) & ((target.transform.position.x+0.5)>current.transform.position.x) & ((target.transform.position.z-0.5)< current.transform.position.z) & ((target.transform.position.z+0.5)> current.transform.position.z)){
            rend.sharedMaterial=materials[1];
        }
        if(rend.sharedMaterial==materials[1]){
            rend.sharedMaterial=materials[2];
            string number=current.name.Substring(2);
            int x=Int32.Parse(number);
            if(x<blocks){
                x=x+1;
                string newlp = "lp"+x.ToString();
                current=GameObject.Find(newlp);
                rend=current.GetComponent<Renderer>();
                rend.sharedMaterial=materials[0];
            }
            else
            {
                lastText.text="You won!";
                button.SetActive(true);
            }   
        }
        print(current.name);
            
    }

}

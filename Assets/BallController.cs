using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{
    Gyroscope m_Gyro;
    public float speed;
    public Text countText;
    public Text lastText;
    public GameObject button;
    public GameObject northWall;
    private float initialY,initialZ;

    private int count;
    private Rigidbody rb;

    void Start ()
    {
        m_Gyro = Input.gyro;
        m_Gyro.enabled = false;
        Random random = new Random();
        rb = GetComponent<Rigidbody>();
        count=0;
        SetCountText();
        lastText.text="";
        initialY= this.transform.position.y;
        initialZ= this.transform.position.z;
        Vector3 movement = new Vector3 (30,0.0f,50);
        rb.AddForce (movement * speed);
        button.SetActive(false);

    }

    void Update(){
        checkLoser();
        float x=transform.position.x;
        transform.localPosition.Set(x,initialY,initialZ);
        //countText.text=Input.gyro.enabled.ToString();
    }

    void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.CompareTag ("brick"))
        {
            other.gameObject.SetActive (false);
            count=count+1;
            SetCountText();
        }
    }

    void SetCountText(){
        
        if (count>=17){
            lastText.text="You won!";
            rb.constraints = RigidbodyConstraints.FreezeAll;
        }
    }

    void checkLoser(){
        if(this.transform.localPosition.y < -(northWall.transform.localPosition.y+1)){
            lastText.text="You lose!";
            rb.constraints = RigidbodyConstraints.FreezeAll;
            button.SetActive(true);
        }
    }
}

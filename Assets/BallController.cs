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
    public GameObject restartB;
    public GameObject continueB;
    public GameObject northWall;
    public AudioClip blop;

    private float initialY,initialZ;
    private int count;
    private Rigidbody rb;
    private GameObject[] blocks;
    private AudioSource source;
    private float volLowRange = .5f;
    private float volHighRange = 1.0f;

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
        restartB.SetActive(false);
        continueB.SetActive(false);
        blocks = GameObject.FindGameObjectsWithTag("brick");

    }

    void Awake () {
        source = GetComponent<AudioSource>();
    }

    void Update(){
        checkLoser();
        float x=transform.position.x;
        transform.localPosition.Set(x,initialY,initialZ);
        countText.text=Input.acceleration.ToString();
    }

    void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.CompareTag ("brick"))
        {
            float vol = Random.Range (volLowRange, volHighRange);
            source.PlayOneShot(blop,vol);
            other.gameObject.SetActive (false);
            count=count+1;
            SetCountText();
        }
    }

    void SetCountText(){
        if(blocks!=null){
            if (count>=blocks.Length){
                lastText.text="You won!";
                rb.constraints = RigidbodyConstraints.FreezeAll;
                continueB.SetActive(true);
            }
        }
        
    }

    void checkLoser(){
        if(this.transform.localPosition.y < -(northWall.transform.localPosition.y+1)){
            lastText.text="You lose!";
            rb.constraints = RigidbodyConstraints.FreezeAll;
            restartB.SetActive(true);
        }
    }
}

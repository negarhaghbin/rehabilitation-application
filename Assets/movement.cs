using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public GameObject target;
    public GameObject eastWall;
    public GameObject westWall;
    public float speed;
    private Rigidbody rb;
    private float prevX;
    public float scale;

    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody>();
        // Vector3 movement = new Vector3 (initialX,0.0f,0.0f);
        // rb.AddForce (movement * speed);
    }

    // Update is called once per frame
    void Update()
    {
        prevX=this.transform.position.x;
        float moveHorizontal = target.transform.position.x-prevX;
        if(this.transform.position.x-(this.transform.localScale.x/2)+moveHorizontal>eastWall.transform.position.x+(eastWall.transform.localScale.x/2) & this.transform.position.x+(this.transform.localScale.x/2)+moveHorizontal<westWall.transform.position.x-(westWall.transform.localScale.x/2))
            gameObject.transform.Translate(scale*moveHorizontal, 0, 0);
        // Vector3 movement = new Vector3 (moveHorizontal, 0.0f,0.0f);
        // rb.AddForce (movement * speed);
    }

}

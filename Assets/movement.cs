using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    Gyroscope m_Gyro;
    public GameObject target;
    public GameObject eastWall;
    public GameObject westWall;
    public float speed;
    private float prevX;
    public float scale;

    void Start()
    {
        m_Gyro = Input.gyro;
        m_Gyro.enabled = false;
    }
    
    void Update()
    {
        prevX=this.transform.position.x;
        float moveHorizontal = target.transform.position.x-prevX;
        if(this.transform.localPosition.x-(this.transform.localScale.x/2)+moveHorizontal>eastWall.transform.localPosition.x+(eastWall.transform.localScale.x/2) & this.transform.localPosition.x+(this.transform.localScale.x/2)+moveHorizontal<westWall.transform.localPosition.x-(westWall.transform.localScale.x/2))
            gameObject.transform.Translate(scale*moveHorizontal, 0, 0);
    }

}

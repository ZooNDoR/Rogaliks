using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    Rigidbody2D rb;
    public Vector2 direction;
    public float speed = 5;
    float x,y;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D> ();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        direction = new Vector2(0,0);
        x = Input.GetAxis("Horizontal")*speed;
        y = Input.GetAxis("Vertical")*speed;
        direction += new Vector2(x,y);
        rb.AddForce(direction);
    }
}


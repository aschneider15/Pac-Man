using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScript : MonoBehaviour
{   private Rigidbody rb;
    public float speed = 16f;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("w"))
        {
            rb.velocity = Vector3.forward * speed;
        }
        else if (Input.GetKeyDown("s"))
        {
            rb.velocity = Vector3.back * speed;
        }
        else if (Input.GetKeyDown("a"))
        {
            rb.velocity = Vector3.left * speed;
        }
        else if (Input.GetKeyDown("d"))
        {
            rb.velocity = Vector3.right * speed;
        }
        else if (Input.GetKeyDown("space"))
        {
            rb.velocity = Vector3.up * speed;
        }
    }
}

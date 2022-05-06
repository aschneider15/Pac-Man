using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScript : MonoBehaviour
{   private Rigidbody rb;
    private Transform tf;
    public float speed = 16f;
    public GameObject rightTeleport;
    public GameObject rightExit;
    public GameObject leftTeleport;
    public GameObject leftExit;
    private int count = 0;
    public GameObject scoreText;
    private TextMesh text;
    public float invincibilityLength = 10f;
    private float invincibilityCounter = 0f;
    private bool isInvincible = false;
    // Start is called before the first frame update
    void Start()
    {
        tf = this.gameObject.GetComponent<Transform>();
        rb = this.gameObject.GetComponent<Rigidbody>();
        text = scoreText.gameObject.GetComponent<TextMesh>();

    }

    // Update is called once per frame
    void Update()
    {
        text.text = "SCORE: " + count;
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
        
        if(invincibilityCounter > 0)
        {
            isInvincible = true;
            invincibilityCounter -= Time.deltaTime;
        }
        else
        {
            isInvincible = false;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag.Equals("Tele1"))
        {
            print("woot");
            tf.position = leftExit.gameObject.GetComponent<Transform>().position;
        }
        else if(collision.gameObject.tag.Equals("Tele2"))
        {
            print("woot");
            tf.position = rightExit.gameObject.GetComponent<Transform>().position;
        }
        else if(collision.gameObject.tag.Equals("Pellet"))
        {
            print("pellet");
            Destroy(collision.gameObject);
            count++;
            invincibilityCounter = invincibilityLength;
        }
        else if(collision.gameObject.tag.Equals("Ghost"))
        {
            print("ghost hit");
            if(isInvincible)
            {
                Destroy(collision.gameObject);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }
    }
}

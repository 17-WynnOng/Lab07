using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private Animation thisAnimation;
    public float jumpspeed;
    private Rigidbody rb;

    public Text scoretext;
    public int score;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        thisAnimation = GetComponent<Animation>();
        thisAnimation["Flap_Legacy"].speed = 3;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            thisAnimation.Play();
            rb.velocity = Vector2.up * jumpspeed;
        }

        if (transform.position.y >= 3.54f)
        {
            transform.position = new Vector3(transform.position.x, 3.54f, transform.position.z);
        }

        if (transform.position.y <= -4.2f)
        {
            SceneManager.LoadScene("SampleScene 2");
        }

        
    }

    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            SceneManager.LoadScene("SampleScene 2");
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Score")
        {
            score++;
            scoretext.text = "Score: " + score;
        }
    }
}

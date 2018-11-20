﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public GameObject character;
    public GameObject[] door;
    public GameObject[] floor;
    SpriteRenderer m_SpriteRenderer;
    Color m_NewColor;
    bool canJump;

    private Rigidbody2D rb;

    void Start()
    {
        character = GameObject.FindGameObjectsWithTag("Player")[0];
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        canJump = true;
    }

    // Update is called once per frame
    void Update()
    {

        //character.transform.localScale = new Vector3(0.27F, 0.27F, 0.27F);
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //movement
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        if (canJump && Input.GetKey(KeyCode.UpArrow))
        {
            // the cube is going to move upwards in 5 units per second
            //rb.velocity = new Vector3(0, 10, 0);
            rb.AddForce(new Vector2(0, 400));
            canJump = false;
            //  Debug.Log("jump");
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            //rb.velocity = new Vector3(3, 0, 0);
            rb.AddForce(new Vector2(12, 0));
            //  Debug.Log("RIGHT");
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //rb.velocity = new Vector3(-3, 0, 0);
            rb.AddForce(new Vector2(-12, 0));

            //  Debug.Log("LEFT");
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow)||Input.GetKeyUp(KeyCode.RightArrow))
        {
         //   rb.Sleep ();  //Clears Force!
          //  rb.velocity=new Vector2(0, 0);
           // rb.AddForce(new Vector2(0, 0));

            //  Debug.Log("LEFT");
        }
        
        if (rb.velocity.y == 0)
        {
            rb.AddForce(new Vector2(0, -400));
            canJump = true;
        }

        if (rb.velocity.y < 0)
        {
            rb.AddForce(new Vector2(0, -10));
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //color change
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        if (Input.GetKeyDown(KeyCode.A)||Input.GetKeyDown(KeyCode.Alpha4))
        {
            //Set the Color to the values gained from the Sliders
            m_NewColor = new Color(0.784f, 0f, 0f, 1f);
            //m_NewColor = Color.red;
            //Set the SpriteRenderer to the Color defined by the Sliders
            m_SpriteRenderer.color = m_NewColor;
            //  Debug.Log("red");
        }
        if (Input.GetKeyDown(KeyCode.W)||Input.GetKeyDown(KeyCode.Alpha8))
        {
            m_NewColor = new Color(0f, 0f, 0.784f, 1f);
            m_SpriteRenderer.color = m_NewColor;
            //  Debug.Log("blue");
        }

        if (Input.GetKeyDown(KeyCode.D)||Input.GetKeyDown(KeyCode.Alpha6))
        {
            m_NewColor = new Color(0.784f, 0.784f, 0f, 1f);
            m_SpriteRenderer.color = m_NewColor;
            //  Debug.Log("yellow");

        }
        if (Input.GetKeyDown(KeyCode.S)||Input.GetKeyDown(KeyCode.Alpha2))
        {
            m_NewColor = new Color(0f, 0.784f, 0f, 1f);
            m_SpriteRenderer.color = m_NewColor;
            //  Debug.Log("green");
        }


    }

    // void OnCollisionEnter2D(Collision2D other)
    // {
    //     if (other.gameObject.tag == "MovingBar")
    //     {
    //         moveWithPlatform = true;
    //     }
    // }
    // // called when this GameObject collides with GameObject2.

    // void OnTriggerExit(Collider other)
    // {
    //     character.transform.parent = null;
    // }


    void OnTriggerEnter2D(Collider2D collision)
    {
        door = GameObject.FindGameObjectsWithTag("door");
        floor = GameObject.FindGameObjectsWithTag("floor");
        //bar = this.gameObject;

        // if (collision.gameObject.tag == "MovingBar")
        // {
        //     character.transform.parent = collision.gameObject.transform; 
        // }
        if (collision.gameObject == door[0])
        {
            Debug.Log("SceneManager.GetActiveScene().buildIndex " + SceneManager.GetActiveScene().buildIndex);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        for (int i = 0; i<floor.Length;i++)
        {
            if (collision.gameObject == floor[i])
            {
              //  Debug.Log("WASTED");
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }





}






﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float moveSpeed;
    public float jumpSpeed;
    public Rigidbody2D myRigidbody;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;

    public bool isGrounded;

    private Animator myAnim;

    
    public Vector3 respawnPosition;
    //session 4 code
    public LevelManager theLevelManager;

	// Use this for initialization
	void Start () {
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
       
        respawnPosition = transform.position;
        //session 4 code
        theLevelManager = FindObjectOfType<LevelManager>();
    }

    // Update is called once per frame
    void Update () {

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);

		if(Input.GetAxisRaw("Horizontal") > 0f)
        {
            myRigidbody.velocity = new Vector3(moveSpeed, myRigidbody.velocity.y, 0f);
            transform.localScale = new Vector3(1f, 1f, 1f);
        }else if (Input.GetAxisRaw ("Horizontal") < 0f)
        {
            myRigidbody.velocity = new Vector3(-moveSpeed, myRigidbody.velocity.y, 0f);
            transform.localScale = new Vector3(-1f, 1f, 1f);

        }
        else
        {
            myRigidbody.velocity = new Vector3(0, myRigidbody.velocity.y, 0f);
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            myRigidbody.velocity = new Vector3(myRigidbody.velocity.x, jumpSpeed, 0f);
        }

        myAnim.SetFloat("Speed", Mathf.Abs(myRigidbody.velocity.x));
        myAnim.SetBool("IsGrounded", isGrounded);

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Kill Plane")
        {
            //session 4 code
            theLevelManager.Respawn();
        }

        if (collision.tag == "CheckPoint")
        {
            respawnPosition = collision.transform.position;
        }
    }


}

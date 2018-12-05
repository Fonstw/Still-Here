using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float horizontalSpeed = 50.0f;
    public float verticalSpeed = 40.0f;
    public float horizontalBreak = 50.0f;
    public float verticalBreak = 40.0f;

    public Rigidbody2D myRigidbody;

	// Use this for initialization
	void Start()
    {
		
	}
	
	// Update is called once per frame
	void Update()
    {
        Vector2 movement = Vector2.zero;
        float xSpeed = myRigidbody.velocity.x;
        float ySpeed = myRigidbody.velocity.y;

		if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            if (xSpeed > .1f)
                movement.x -= horizontalSpeed + horizontalBreak;
            else
                movement.x -= horizontalSpeed;
        }
        if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            if (xSpeed < -.1f)
                movement.x += horizontalSpeed + horizontalBreak;
            else
                movement.x += horizontalSpeed;
        }
        if(Input.GetKey(KeyCode.Space))
        {
            if (ySpeed < -.1f)
                movement.y += verticalSpeed + verticalBreak;
            else
                movement.y += verticalSpeed;
        }

        myRigidbody.AddForce(movement * Time.deltaTime);
	}
}

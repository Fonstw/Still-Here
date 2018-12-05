using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float horizontalSpeed = 50.0f;
    public float verticalSpeed = 40.0f;
    public float horizontalBreak = 50.0f;
    public float verticalBreak = 40.0f;
    public float horizontalLimit = 50.0f;
    public float verticalLimit = 40.0f;
    public float dashMultiplier = 2.0f;
    public float fuelDrain = .1f;
    public float fuelRecoveryMultiplier = 2;

    private float fuel = 1.0f;

    public Rigidbody2D myRigidbody;
    public RectTransform fuelBar;

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

        //float currentlyDashing = Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.LeftShift) ? dashMultiplier : 1;

        // For debugging purposes
        if (xSpeed != 0)
            print("xSpeed: " + xSpeed);

        if (ySpeed != 0)
            print("ySpeed: " + ySpeed);
        
        // Take movement input
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            if (xSpeed > .1f)
                movement.x -= horizontalSpeed + horizontalBreak;
            else
                movement.x -= horizontalSpeed;
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            if (xSpeed < -.1f)
                movement.x += horizontalSpeed + horizontalBreak;
            else
                movement.x += horizontalSpeed;
        }
        if (fuel > 0 && (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)))
        {
            if (ySpeed < -.1f)
                movement.y = verticalSpeed + verticalBreak;
            else
                movement.y = verticalSpeed;
                
            fuel -= fuelDrain;
        }

        if (fuel < 1 && !(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)))
            fuel += fuelDrain * fuelRecoveryMultiplier;

        fuel = Mathf.Clamp(fuel, 0, 1);

        // Actually push it with that 'speed'
        myRigidbody.AddForce(movement * Time.deltaTime /** currentlyDashing*/);

        // Limit how fast you can go
        if (myRigidbody.velocity.magnitude > horizontalLimit /** currentlyDashing*/)
            myRigidbody.drag = 1;

        // Display fuel through bar
        fuelBar.sizeDelta = new Vector2(200 * fuel, 25);
    }
}


using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public Rigidbody rb;

    public float forwardForce = 2000f;
    public float sidewaysForce = 500f;

    public bool leftBtnPressed;
    public bool rightBtnPressed;

    private float screenWidth;

    //Update button state
    public void leftBtnPressedDown()
    {
        leftBtnPressed = true;
    }
    public void rightBtnPressedDown()
    {
        rightBtnPressed = true;
    }
    public void leftBtnPressedUp()
    {
        leftBtnPressed = false;
    }
    public void rightBtnPressedUp()
    {
        rightBtnPressed = false;
    }

    // Update is called once per frame
    void FixedUpdate () {

        //Add a forward force
        rb.AddForce(0, 0, forwardForce * Time.deltaTime);


        // Button controls for mobile
        if(rightBtnPressed == true)
        {
            rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        if (leftBtnPressed == true)
        {
            rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        // Keyboard controls using A/D keys
        if (Input.GetKey("d"))
        {
            rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        if (Input.GetKey("a"))
        {
            rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        // End game when player falls down the edge
        if (rb.position.y < -1f)
        {
            FindObjectOfType<GameManager>().EndGame();
        }
    }
    
    public void moveLeft()
    {
        rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
    }
    public void moveRight()
    {
        rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
    }
}
    

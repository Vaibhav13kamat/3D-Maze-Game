using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{

    private Rigidbody playerRb;
    public float jumpforce;
    public float speed = 100;
    public bool isOnGround = true;
    public float rightKeyPrecision = 1;
    public float leftKeyPrecision = 1;
    public float upKeyPrecision = 1;
    public float downKeyPrecision = 1;

    public float xRange = 10;
    public float zRange = 10;

    public int moveThreshold = 1;

    public static PlayerController Instance;

    /// <summary>

    /// </summary>


    public float sensitivity = 4.0f;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }


    // Start is called before the first frame update
    void Start()
    {

        playerRb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // playerConstrainst();
        playerMovements();
        playerMovementsAcc();
        
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            isOnGround = true;
            Debug.Log("is on the ground");
        }
     
        

    }

    public void playerConstrainst()
    {
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
        else if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        else if (transform.position.z > zRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zRange);
        }
        else if (transform.position.z < -zRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -zRange);
        }
    }
    public void playerMovements()
    {
        if (Input.GetKey(KeyCode.Space) && isOnGround)
        {
            playerRb.AddForce(Vector3.up * jumpforce, ForceMode.Impulse);
            isOnGround = false;
            Debug.Log(" In Air");
        }
        else if ((Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) && isOnGround)
        {

            playerRb.AddForce(Vector3.right * rightKeyPrecision * speed * Time.deltaTime);
            Debug.Log("Moving right");

        }
        else if ((Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) && isOnGround)
        {
            playerRb.AddForce(Vector3.left * leftKeyPrecision * speed * Time.deltaTime);
            Debug.Log("Moving left");

        }
        else if ((Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)) && isOnGround)
        {
            playerRb.AddForce(Vector3.forward * upKeyPrecision * speed * Time.deltaTime);
            Debug.Log("Moving foward");
        }
        else if ((Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)) && isOnGround)
        {
            playerRb.AddForce(Vector3.back * downKeyPrecision * speed * Time.deltaTime);
            Debug.Log("Moving down");
        }
    }

    public void playerMovementsAcc()
    {
        // Using accelerometer input for movement
        Vector3 acceleration = Input.acceleration;

        if (Mathf.Abs(acceleration.x) > moveThreshold)
        {
            playerRb.AddForce(Vector3.right * acceleration.x * speed * sensitivity* Time.deltaTime);
        }
        if (Mathf.Abs(acceleration.y) > moveThreshold)
        {
            playerRb.AddForce(Vector3.forward * acceleration.y * speed * sensitivity* Time.deltaTime);
        }
    }
    
}

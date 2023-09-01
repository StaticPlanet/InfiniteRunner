using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    private InputManager inputManager;
    public GameObject player;
    public bool isGrounded;
    public float jumpSpeed = 3;
    public float speed = 5;
    public Transform groundCheck;
    public LayerMask isGroundedLayer;
    public float groundCheckRadius;

    Rigidbody rb;
    public CanvasManager cm;

    int laneNumber = 1;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Awake()
    {
        inputManager = GetComponent<InputManager>();
    }

    private void Update()
    {
        isGrounded = Physics.OverlapSphere(groundCheck.position, groundCheckRadius, isGroundedLayer).Length > 0;
    }

    private void OnEnable()
    {
        inputManager.OnSwipeLeft += OnSwipeLeft;
        inputManager.OnSwipeRight += OnSwipeRight;
        inputManager.OnSwipeUp += OnSwipeUp;
        inputManager.OnSwipeDown += OnSwipeDown;
    }

    private void OnDisable()
    {
        inputManager.OnSwipeLeft -= OnSwipeLeft;
        inputManager.OnSwipeRight -= OnSwipeRight;
        inputManager.OnSwipeUp -= OnSwipeUp;
        inputManager.OnSwipeDown -= OnSwipeDown;
    }

    private void OnSwipeLeft()
    {   
        Debug.Log("left move");
        if (laneNumber == 0)
            return;

        rb.AddForce(transform.right * -speed);
        laneNumber--;
        Debug.Log(laneNumber);
    }

    private void OnSwipeRight() 
    {   
        Debug.Log("Right move");
        if (laneNumber == 2)
            return;

        rb.AddForce(transform.right * speed);
        laneNumber++;
        Debug.Log(laneNumber);
    }

    private void OnSwipeUp()
    { 
        Debug.Log("Up swipe detected");
        if(Physics.CheckSphere(groundCheck.position, 0.1f, isGroundedLayer))
        {
            rb.AddForce(transform.up * jumpSpeed * Time.deltaTime);
        }
    } 

    private void OnSwipeDown() => Debug.Log("Down swipe detected");

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Car"))
        {
            cm.StartLose();
        }
    }
}

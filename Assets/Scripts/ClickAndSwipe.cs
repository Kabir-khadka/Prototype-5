using UnityEngine;



//Adding hard checker
[RequireComponent(typeof(TrailRenderer), typeof(BoxCollider))]
public class ClickAndSwipe : MonoBehaviour
{

    //Declaring variables
    private GameManager gameManager;
    private Camera cam;
    private Vector3 mousePos;

    private TrailRenderer trail;
    private BoxCollider box;

    private bool swiping = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        cam = Camera.main;
        trail = GetComponent<TrailRenderer>();
        box = GetComponent<BoxCollider>();
        trail.enabled = false;
        box.enabled = false;

        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.isGameActive)
        {
            if (Input.GetMouseButtonDown(0))
            {
                swiping = true;
                UpdateComponents();
            }

            if (Input.GetMouseButtonUp(0))
            {
                swiping = false;
                UpdateComponents();
            }

            if (swiping)
            {
                UpdateMousePosition();
            }
        }
    }

    void UpdateMousePosition()
    {
        //Taking X, Y, Z  coordinates, and converting them into 3D world space,
        //so that the objects could be placed in a 3D world from inputs from 2d inout like mouse or touch. 
        mousePos = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f));
        transform.position = mousePos;
    }

    void UpdateComponents()
    {
        trail.enabled = swiping;
        box.enabled = swiping;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Target>())
        {
            collision.gameObject.GetComponent<Target>().DestroyTarget();
        }
    }
}

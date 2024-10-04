using UnityEngine;

public class Target : MonoBehaviour
{

    private Rigidbody targetRb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //getting the rigidbody component
        targetRb = GetComponent<Rigidbody>();

        //Adding certain force with random speed in upward direction

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

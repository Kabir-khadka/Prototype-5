using UnityEngine;

public class Target : MonoBehaviour
{

    private Rigidbody targetRb;
    private GameManager gameManager;
    public ParticleSystem explosionParticle;

    public int pointValue;
    private float minSpeed = 15;
    private float maxSpeed = 20;
    private float maxTorque = 1;
    private float xSpawnRange = 4;
    private float ySpawnRange = -6;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //getting the rigidbody component
        targetRb = GetComponent<Rigidbody>();

        //Adding certain force with random speed in upward direction
        targetRb.AddForce(RandomForce(), ForceMode.Impulse);

        //Rotating and moving objects
        targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);

        //Setting the position for the objects to spawn
        transform.position = RandomPos();

        //Calling gamemanager object as well as script
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if (gameManager.isGameActive)
        {
            Destroy(gameObject);
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
            gameManager.UpdateScore(pointValue);
        }
        

    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        if (!gameObject.CompareTag("Bad"))
        {
            gameManager.GameOver();
        }
    }


    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }

    float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }

    Vector3 RandomPos()
    {
        return new Vector3(Random.Range(-xSpawnRange, xSpawnRange), ySpawnRange);
    }
}

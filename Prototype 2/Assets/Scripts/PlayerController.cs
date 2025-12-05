using UnityEngine;
using TMPro; //GameOver and Score text

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float speed = 10.0f;
    public float xRange = 10.0f;
    public GameObject projectilePrefab;
    public bool GameOver { get; set; } //Propertie
    
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;

    private int score = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scoreText.text = "Score: 0";
        gameOverText.gameObject.SetActive(false);
        
    }

    public void AddScore(int amount)
    {
        if (GameOver) return;
        
        score += amount;
        scoreText.text = "Score: " + score;
    }

    void OnTriggerEnter(Collider other) //Game over by Collision with Animal
    {
        if (other.CompareTag("Animal"))
        {
            GameOver = true;
            gameOverText.gameObject.SetActive(true);
            Debug.Log("GAME OVER");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (GameOver) return;
        
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }

        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
        
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Launch an projectile from the player
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        }
    }
}

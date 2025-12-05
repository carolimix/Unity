using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float topBound = 30.0f;
    private float lowerBound = -10.0f;

    private static int animalsPasses = 0; //count for how many animals left the ground

    private int maxAllowed = 3; //max limit allowed of animals leaving ground before game over
    
    private PlayerController playerController;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z > topBound)
        {
            Destroy(gameObject);
        } else if (transform.position.z < lowerBound)
        {
            animalsPasses++; //updates animals count
            Debug.Log("Escaped Animals: " + animalsPasses);

            if (animalsPasses > maxAllowed && !playerController.GameOver)
            {
                playerController.GameOver = true;
                playerController.gameOverText.gameObject.SetActive(true); //activates game over text
                Debug.Log("Game Over: Too many animals have escaped");
            }
            Destroy(gameObject);
        }
        
    }
}

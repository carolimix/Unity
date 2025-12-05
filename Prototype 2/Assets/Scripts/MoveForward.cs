using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public float speed = 40.0f;
    private PlayerController playerController;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerController.GameOver) return; //stops movement when gameOber is true
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
        
    }
}

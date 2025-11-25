using UnityEngine;

public class SpinPropellerX : MonoBehaviour
{
    private float propellerSpeed = 1000;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward,propellerSpeed * Time.deltaTime);
    }
}

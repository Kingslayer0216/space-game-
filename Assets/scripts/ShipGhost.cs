using UnityEngine;

public class ShipGhost : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float ghostX;
        float screenWidth = Screen.width;
    if (transform.position.x > 0)
    {
        ghostX = transform.position.x - screenWidth;
    }
    else
    {
        ghostX = transform.position.x + screenWidth;
    }

    }    
}

using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int hober_pointers = 2;
    public float enemy_speed = 1.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //wraparound
        float leftEdge = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).x;
        float rightEdge = Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth, 0, 0)).x; 
        float downEdge = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).y;
        float upEdge = Camera.main.ScreenToWorldPoint(new Vector3(0, Camera.main.pixelHeight, 0)).y;
        if(transform.position.x > rightEdge)
        {
            transform.position = new Vector2(leftEdge, transform.position.y);
        }
        else if (transform.position.x < leftEdge)
        {
            transform.position = new Vector2(rightEdge, transform.position.y);
        }
        if(transform.position.y < downEdge)
        {
            transform.position = new Vector2(transform.position.x, upEdge);
        }
        else if (transform.position.y > upEdge)
        {
            transform.position = new Vector2(transform.position.x, downEdge);
        }
        //movement 
        transform.Translate(Vector2.down * enemy_speed * Time.deltaTime);
        
        //death 
        if (hober_pointers <= 0)
        {
            Destroy(gameObject);
        }
    }
}

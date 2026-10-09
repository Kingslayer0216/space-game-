using UnityEngine;

public class Lazer : MonoBehaviour
{
    public float laser_speed;
    float lazer_timer = 0.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       Debug.Log("lazer"); 
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * laser_speed * Time.deltaTime);

        lazer_timer = lazer_timer + 0.1f * Time.deltaTime;

        if (lazer_timer > 0.5f)
        {
            Destroy(gameObject);
            
        lazer_timer = 0.0f;
        }    
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.gameObject.name);

        Enemy enemy = other.gameObject.GetComponent<Enemy>();
        if(enemy != null)
        enemy.hober_pointers = enemy.hober_pointers -1;
    }
}
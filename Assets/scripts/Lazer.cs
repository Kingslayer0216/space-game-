using UnityEngine;

public class Lazer : MonoBehaviour
{
    [Header("Lazer Settings")]
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
#region lazer movement
        transform.Translate(Vector2.up * laser_speed * Time.deltaTime);

        lazer_timer = lazer_timer + 0.1f * Time.deltaTime;

        if (lazer_timer > 0.5f)
        {
            Destroy(gameObject);
            
        lazer_timer = 0.0f;
        }    
#endregion
    }

    void OnTriggerEnter2D(Collider2D other)
    {
#region lazer collision
        Debug.Log(other.gameObject.name);

        Enemy enemy = other.gameObject.GetComponent<Enemy>();
        if(enemy != null)
        enemy.hober_pointers = enemy.hober_pointers -1;
    }
#endregion
}
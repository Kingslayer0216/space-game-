using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Enemy Settings")]
    [SerializeField] float enemy_speed = 1.0f;

    [Header("Enemy ghost Settings")]
    [SerializeField] Transform EnemyGhost;
    [SerializeField] Transform EnemyGhostDiagonal;
    [SerializeField] Transform EnemyGhostVertical;  
    [SerializeField] Transform Player;

        public int hober_pointers = 2;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {     
        

#region wraparound
        float leftEdge = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).x;
        float rightEdge = Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth, 0, 0)).x; 
        float downEdge = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).y;
        float upEdge = Camera.main.ScreenToWorldPoint(new Vector3(0, Camera.main.pixelHeight, 0)).y;
        float screenWidth = rightEdge - leftEdge;
        float screenHeight = upEdge - downEdge;
#endregion
#region Ghost wraparound
        float ghostX;
        float ghostY;
         if (transform.position.x > 0)
        {
            ghostX = transform.position.x - screenWidth;
        }
        else
        {
            ghostX = transform.position.x + screenWidth;
        }
        if (transform.position.y > 0)
        {
            ghostY = transform.position.y - screenHeight;
        }
        else
        {
            ghostY = transform.position.y + screenHeight;
        }
#endregion
#region Ghost movement
        EnemyGhost.position = new Vector2(ghostX, transform.position.y);
        EnemyGhostDiagonal.position = new Vector2(ghostX, ghostY);
        EnemyGhostVertical.position = new Vector2(transform.position.x, ghostY);
#endregion
#region enemy wraparound
        if(transform.position.x > rightEdge)
        {
            transform.position = new Vector2(transform.position.x - screenWidth, transform.position.y);
        }
        else if (transform.position.x < leftEdge)
        {
            transform.position = new Vector2(transform.position.x + screenWidth, transform.position.y);
        }
        if(transform.position.y < downEdge)
        {
            transform.position = new Vector2(transform.position.x,transform.position.y + screenHeight);
        }
        else if (transform.position.y > upEdge)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - screenHeight);
        }
#endregion
#region Enemy movement 
        transform.Translate(Vector2.up * enemy_speed * Time.deltaTime);
#endregion
#region Enemy death 
        if (hober_pointers <= 0)
        {
            Destroy(gameObject);
        }
#endregion
#region Enemy aim
        Vector2 direction = Player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
        transform.rotation = Quaternion.Euler(0, 0, angle);
#endregion
    }
}

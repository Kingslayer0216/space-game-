using Unity.Mathematics;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float player_rotation_speed = 5.0f;
    public float player_speed = 5.0f;
    public GameObject Lazer;
     public Transform ghost;
    [SerializeField] float lazer_input_delay;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
     float lazer_input_timer = 5.0f;

    void Start()
    {
       this.transform.position = new Vector2(0,0);
    }

    // Update is called once per frame
    void Update()
    {
    //movment
        float rotation = 0.5f;
        Vector2 direction = Vector2.zero;

        if (Input.GetKey(KeyCode.W) == true
        ||  Input.GetKey(KeyCode.UpArrow) == true)
        {
            direction.y++;
        }

        if (Input.GetKey(KeyCode.A) == true
        || Input.GetKey(KeyCode.LeftArrow)  == true)
        {
            direction.x--;
        }
        if (Input.GetKey(KeyCode.S) == true
        || Input.GetKey(KeyCode.DownArrow) == true)
        {
            direction.y--;
        }
        if (Input.GetKey(KeyCode.D) == true
        || Input.GetKey(KeyCode.RightArrow) == true)
            direction.x++;
        if (Input.GetKey(KeyCode.LeftShift) == true)
        {
            direction = direction * 2;
        }
        if (Input.GetKey(KeyCode.RightShift) == true)
        {
            direction = direction * 2;
        }
        if (Input.GetKey(KeyCode.LeftControl) == true)
        {
            direction = direction * 0.5f;
        }
        if (Input.GetKey(KeyCode.RightControl) == true)
        {
            direction = direction * 0.5f;
        }  
        if (Input.GetKey(KeyCode.E) == true)
        {
            rotation = rotation + player_rotation_speed * Time.deltaTime;
        }
        transform.Translate(direction * player_speed * Time.deltaTime);

        lazer_input_timer = lazer_input_timer + 1 * Time.deltaTime;
        //Debug.Log(lazer_input_timer);

        if (Input.GetKey(KeyCode.Space) == true && lazer_input_timer >= lazer_input_delay)
        {
            Instantiate(Lazer, transform.position, quaternion.identity);
            lazer_input_timer = 0.0f;
        }
        //wraparound
        float leftEdge = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).x;
        float rightEdge = Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth, 0, 0)).x;
        float screenWidth = rightEdge - leftEdge;
        float downEdge = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).y;
        float upEdge = Camera.main.ScreenToWorldPoint(new Vector3(0, Camera.main.pixelHeight, 0)).y;
        float screenHeight = upEdge - downEdge;

        if (transform.position.x > rightEdge)
        {
            transform.position = new Vector2(transform.position.x - screenWidth, transform.position.y);
        }
        if (transform.position.x < leftEdge)
        {
            transform.position = new Vector2(transform.position.x + screenWidth, transform.position.y);
        }
        if (transform.position.y < downEdge)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + screenHeight);
        }
        if (transform.position.y > upEdge)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - screenHeight);
        }

        //ghost wraparound
        float ghostX;

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
            ghost.position = new Vector2(ghostX, transform.position.y - screenHeight);
        }
        else
        {
            ghost.position = new Vector2(ghostX, transform.position.y + screenHeight);
        }

        ghost.position = new Vector2(ghostX, transform.position.y);



        // 1. Create a variable (direction), storing the input direction
        // 2. Check player input, assign (direction) based on input
        // 3. Translate player position, based on (direction)
    }
}

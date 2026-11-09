using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMove : MonoBehaviour
{
     [Header("Player Movement Settings")]
    [SerializeField] float player_rotation_speed = 50.0f;
    [SerializeField] float player_speed = 5.0f;
    [Header("Player Boost Settings")]
    [SerializeField] float player_boost_speed = 10.0f;
    [Header("Player Lazer Settings")]
    [SerializeField] GameObject Lazer;
    [Space(10)]
    [Header("Ghost Settings")]
     [SerializeField] Transform ghost;
     [SerializeField] Transform ghostDiagonal;
     [SerializeField] Transform ghostVertical;
     [Header("Lazer settings")]
    [SerializeField] float lazer_input_delay;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
     float lazer_input_timer = 5.0f;
    InputSystem_Actions actions;
    void Awake()
    {
        actions = new InputSystem_Actions();
    }
    void OnEnable()
    {
        actions.Player.Enable();
    }
    void OnDisable()
    {
        actions.Player.Disable();
    }
    void Start()
    {
        this.transform.position = new Vector2(0,0);
    }
    // Update is called once per frame
    void Update()
    {
        float turn = actions.Player.LookKey.ReadValue<float>();
        float ghostX;
        float ghostY;
        float leftEdge = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).x;
        float rightEdge = Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth, 0, 0)).x;
        float screenWidth = rightEdge - leftEdge;
        float downEdge = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).y;
        float upEdge = Camera.main.ScreenToWorldPoint(new Vector3(0, Camera.main.pixelHeight, 0)).y;
        float screenHeight = upEdge - downEdge;

        float player_boost = player_speed;
        if (actions.Player.Boost.IsPressed())
        {
            player_boost = player_speed + player_boost_speed;
        }
#region gamepad movment
        transform.Translate( actions.Player.Movement.ReadValue<Vector2>()* player_boost * Time.deltaTime, Space.World);
        Vector2 look = actions.Player.LookPad.ReadValue<Vector2>();
        
        transform.Rotate(Vector3.forward, turn * player_rotation_speed * Time.deltaTime);
        if (look.magnitude > 0.2f)
        {
            transform.up = look;

        }
#endregion        
#region shooting
        lazer_input_timer = lazer_input_timer + 1 * Time.deltaTime;

        if (actions.Player.Shoot.IsPressed() && lazer_input_timer >= lazer_input_delay)
        {
            Instantiate(Lazer, transform.position, transform.rotation);
            lazer_input_timer = 0.0f;
        }
#endregion
#region wraparound
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
#endregion
#region ghost wraparound
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
        ghost.position = new Vector2(ghostX, transform.position.y);
        ghostDiagonal.position = new Vector2(ghostX, ghostY);
        ghostVertical.position = new Vector2(transform.position.x, ghostY); 
#endregion
    }
}
using Unity.Mathematics;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public Vector3 WorldToScreenPoint(Vector3 position, Camera.MonoOrStereoscopicEye eye)
    {
        throw new System.NotImplementedException();
    }
    public GameObject Lazer;
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
        
        transform.Translate(direction * 5 * Time.deltaTime);
     
        lazer_input_timer = lazer_input_timer + 5 * Time.deltaTime;
        //Debug.Log(lazer_input_timer);
        
        if (Input.GetKey(KeyCode.Space) == true && lazer_input_timer >= lazer_input_delay)
        {
            Instantiate(Lazer, transform.position, quaternion.identity);
            lazer_input_timer = 0.0f;
        }
        
        Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);
        float leftEdge = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).x;
        float rightEdge = Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth, 0, 0)).x;
        
        if (transform.position.x > rightEdge)
        {
             transform.position = new Vector2(leftEdge, transform.position.y);
        }
        if (transform.position.x < leftEdge)
        {
            transform.position = new Vector2(rightEdge, transform.position.y);
        }
        Debug.Log("X: " + transform.position.x);   // sist i Update
        Debug.Log("Wrap höger!");   // inuti if-satsen för höger sida    



        // 1. Create a variable (direction), storing the input direction
        // 2. Check player input, assign (direction) based on input
        // 3. Translate player position, based on (direction)
    }
}

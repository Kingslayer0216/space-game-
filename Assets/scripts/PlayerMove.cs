using Unity.Mathematics;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public GameObject Lazer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       this.transform.position = new Vector2(0,0); 
    }

    // Update is called once per frame
    void Update()
    {
    //movment 
        Vector2 direction = Vector2.zero;

        bool pressingW = Input.GetKey(KeyCode.W);
        bool pressingA = Input.GetKey(KeyCode.A);
        bool pressingS = Input.GetKey(KeyCode.S);
        bool pressingD = Input.GetKey(KeyCode.D);
        if (pressingW == true)
             direction.y++;
        if (pressingA == true)
            direction.x--;
        if (pressingS == true)
            direction.y--;
        if (pressingD == true)
            direction.x++;
        
        transform.Translate(direction * 1 * Time.deltaTime);

    //lazer
    bool pressingSpace = Input.GetKey(KeyCode.Space);
    if (pressingSpace == true)
     
     Instantiate(Lazer, transform.position, quaternion.identity);
     
        
    



        // 1. Create a variable (direction), storing the input direction
        // 2. Check player input, assign (direction) based on input
        // 3. Translate player position, based on (direction)
    }
}

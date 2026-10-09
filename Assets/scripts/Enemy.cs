using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int hober_pointers = 2;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (hober_pointers <= 0)
        {
            Destroy(gameObject);
        }
    }
}

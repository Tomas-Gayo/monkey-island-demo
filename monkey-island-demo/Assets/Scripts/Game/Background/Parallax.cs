using UnityEngine;

public class Parallax : MonoBehaviour
{
    public float parallax; 
    public float length;

    private Vector2 StartPosition;

    void Start()
    {
        // Save start position at the beginning 
        StartPosition = transform.position;
    }

    private void Update()
    {
        // Loop between 0 and length with Mathf.Repeat and update position depending on the parallax variable
        // This is creating the movement of the background by changing the position on each frame
        transform.position = StartPosition + Vector2.right * Mathf.Repeat(Time.time * parallax, length);

    }
}

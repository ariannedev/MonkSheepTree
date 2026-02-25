using UnityEngine;

public class WorldMover : MonoBehaviour
{
    public float speed = 5f;

    void Update()
    {
        // Move everything left
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }
}

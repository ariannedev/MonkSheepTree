using UnityEngine;

public class Player : MonoBehaviour
{
    public float gravityAtMinSpeed = 3f;
    public float gravityAtMaxSpeed = 0.5f;
    public WorldMover worldMover;

    private Rigidbody2D rb;
    private Collider2D col;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
    }

    void Update()
    {
        decreaseGravity();
    }

    //as the world speeds up, the gravity decreases (sense of "flying" off hills at higher speeds)
    void decreaseGravity()
    {
        float t = Mathf.InverseLerp(worldMover.startSpeed, worldMover.maxSpeed, worldMover.CurrentSpeed);
        rb.gravityScale = Mathf.Lerp(gravityAtMinSpeed, gravityAtMaxSpeed, t);
    }
}

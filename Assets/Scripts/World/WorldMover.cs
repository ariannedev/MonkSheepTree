using UnityEngine;

public class WorldMover : MonoBehaviour
{
    public float startSpeed = 5f;
    public float maxSpeed = 14f;
    //seconds to reach max speed 
    public float rampDuration = 240f;

    private float elapsed = 0f;

    public float CurrentSpeed => speed;
    private float speed;

    void Update()
    {
        MoveWorld();
    }

    //move the background
    void MoveWorld()
    {
        //decide whether to speed up more
        if (elapsed < rampDuration)
            CalcRampUpSpeed();
        //move
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }

    //calculate the amount to speed up
    void CalcRampUpSpeed()
    {
        elapsed += Time.deltaTime;

        // slow speed increase early, accelerates as the speed does
        float t = Mathf.Clamp01(elapsed / rampDuration);
        // quadratic...gradual at first
        float curve = t * t;
        speed = Mathf.Lerp(startSpeed, maxSpeed, curve);

    }
}

using UnityEngine;

public class Car : MonoBehaviour
{
    public float speed;
    public Axle[] axles;

    public float rotation;

    public Rigidbody2D rb;

    public void OnGas()
    {
        SetTorque(-speed);
    }

    public void OnBrake()
    {
        SetTorque(speed);
    }

    void SetTorque(float speed)
    {
        foreach(Axle axle in axles)
        {
            axle.wheel.AddTorque(speed * axle.speedMultiplier);
        }

        rb.AddTorque(rotation * speed);
    }
}

[System.Serializable]
public class Axle
{
    public Rigidbody2D wheel;
    public float speedMultiplier;
}

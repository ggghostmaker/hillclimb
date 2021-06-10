using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform car;

    public float followSpeed;

    Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - car.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, car.position + offset, followSpeed);
    }
}

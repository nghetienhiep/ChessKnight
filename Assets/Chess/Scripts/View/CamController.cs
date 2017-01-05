using UnityEngine;
using System.Collections;

public class CamController : MonoBehaviour
{
    public float Z_MIN, Z_MAX;
    [SerializeField, Range(0.0f, 1.0f)]
    private float rotationSpeed = 1;
    private Vector3 first_touch, second_touch;
    private float zRotation, yRotation;
    private Vector3 newPos;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            first_touch = Input.mousePosition;
        }
        if (Input.GetMouseButton(0))
        {
            second_touch = Input.mousePosition;
            RightSwipe();
            first_touch = second_touch;
        }
    }
    public void RightSwipe()
    {
        yRotation = 0;
        zRotation = 0;
        zRotation = (second_touch.y - first_touch.y) * rotationSpeed;
        yRotation = (second_touch.x - first_touch.x) * rotationSpeed;
        newPos += new Vector3(0, yRotation, zRotation);
        newPos.z = Mathf.Clamp(newPos.z, Z_MIN, Z_MAX);
        transform.eulerAngles = newPos;
        transform.eulerAngles = newPos;
    }
}

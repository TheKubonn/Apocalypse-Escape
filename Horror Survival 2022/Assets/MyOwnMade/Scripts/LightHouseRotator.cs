using UnityEngine;

public class LightHouseRotator : MonoBehaviour
{
    private float rotateSpeed = 9.5f;
    void Update()
    {
        transform.Rotate(Vector3.forward * (rotateSpeed * Time.deltaTime));
    }
}

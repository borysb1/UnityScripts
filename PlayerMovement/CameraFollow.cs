using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // gracz
    public float smoothSpeed = 5f; // szybko�� "doganiania"
    public Vector3 offset; // przesuni�cie kamery wzgl�dem gracza

    void LateUpdate()
    {
        if (target == null) return;

        // Docelowa pozycja kamery
        Vector3 desiredPosition = target.position + offset;

        // P�ynne przej�cie
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);

        // Ustawienie nowej pozycji kamery
        transform.position = smoothedPosition;
    }
}

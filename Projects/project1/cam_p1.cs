using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // gracz
    public float smoothSpeed = 5f; // szybkoœæ "doganiania"
    public Vector3 offset; // przesuniêcie kamery wzglêdem gracza

    void LateUpdate()
    {
        if (target == null) return;

        // Docelowa pozycja kamery
        Vector3 desiredPosition = target.position + offset;

        // P³ynne przejœcie
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);

        // Ustawienie nowej pozycji kamery
        transform.position = smoothedPosition;
    }
}
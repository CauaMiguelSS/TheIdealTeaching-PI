using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;   // Refer�ncia ao jogador
    public Vector3 offset;     // Dist�ncia da c�mera em rela��o ao jogador
    public float smoothSpeed = 5f; // Suavidade do movimento

    void LateUpdate()
    {
        if (player != null)
        {
            Vector3 desiredPosition = player.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
        }
    }
}

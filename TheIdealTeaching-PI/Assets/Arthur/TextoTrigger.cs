using UnityEngine;

public class TextoTrigger : MonoBehaviour
{
    [TextArea(2, 5)]
    public string mensagem; // Texto exibido quando o player entra

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            TextoComFadeManager.Instance.MostrarTexto(mensagem);
        }
    }
}


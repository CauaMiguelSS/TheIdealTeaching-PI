using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class AtivarBotao : MonoBehaviour
{
    public bool estaPressionado = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Caixa") || collision.CompareTag("Player"))
        {
            estaPressionado = true;
            Debug.Log("Bot�o Ativado");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Caixa") || collision.CompareTag("Player"))
        {
            estaPressionado = false;
            Debug.Log("Bot�o Inativo");
        }
    }
}

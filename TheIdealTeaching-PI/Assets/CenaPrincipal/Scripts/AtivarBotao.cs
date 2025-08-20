using UnityEngine;

public class AtivarBotao : MonoBehaviour
{
    public bool estaPressionado = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Caixa"))
        {
            estaPressionado = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Caixa"))
        {
            estaPressionado = false;
        }
    }
}

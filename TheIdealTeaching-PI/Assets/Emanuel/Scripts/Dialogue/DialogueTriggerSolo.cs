using UnityEngine;

public class DialogueTriggerSolo : MonoBehaviour
{
    [TextArea(2, 5)]
    public string[] falasSolo;

    public GameObject objetoParaDestruir;

    private bool falando = false;

    void OnCollisionStay2D(Collision2D collision)
    {
        if (!collision.collider.CompareTag("Player")) return;

        // se já tá falando, NÃO chama de novo
        if (falando || DialogueSystem.Instance.DialogueAtivo()) return;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            falando = true;

            DialogueSystem.Instance.StartDialogue(
                falasSolo,
                gameObject.name,
                false,
                "",
                AoTerminarDialogo
            );
        }
    }

    private void AoTerminarDialogo()
    {
        falando = false; // permite falar de novo depois

        if (objetoParaDestruir != null)
        {
            Destroy(objetoParaDestruir);
            objetoParaDestruir = null;
        }
    }
}





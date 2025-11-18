using UnityEngine;

public class PlayerInteractor : MonoBehaviour
{
    public Transform interactionPoint;
    public float interactionRadius = 0.5f;
    public LayerMask interactableLayer;

    void Update()
    {
        // Se já tem um diálogo ativo, não tente iniciar outro.
        // Isso evita que o Space abra o diálogo de novo enquanto você tenta avançar as linhas.
        if (DialogueSystem.Instance != null && DialogueSystem.Instance.DialogueAtivo())
            return;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Verifica se tem algo no ponto de interação
            Collider2D hit = Physics2D.OverlapCircle(
                interactionPoint.position,
                interactionRadius,
                interactableLayer
            );

            if (hit != null)
            {
                // Primeiro tenta um DialogueTrigger normal
                DialogueTrigger trigger = hit.GetComponent<DialogueTrigger>();
                if (trigger != null)
                {
                    trigger.Interact();
                    return;
                }

                // Depois tenta o DialogueTriggerSolo
                DialogueTriggerSolo triggerSolo = hit.GetComponent<DialogueTriggerSolo>();
                if (triggerSolo != null)
                {
                    triggerSolo.Interact();
                    return;
                }
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        if (interactionPoint != null)
        {
            Gizmos.color = Color.cyan;
            Gizmos.DrawWireSphere(interactionPoint.position, interactionRadius);
        }
    }
}

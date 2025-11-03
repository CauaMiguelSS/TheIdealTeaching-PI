using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [TextArea(2, 5)]
    public string[] lines;

    private bool hasInteracted = false;
    public GameObject porta;

    public void Interact()
    {
        if (hasInteracted) return;

        hasInteracted = true;

        // Chama o diálogo e passa o callback pra abrir a porta no fim
        DialogueSystem.Instance.StartDialogue(lines, gameObject.name, false, "", OnDialogueFinished);
    }

    private void OnDialogueFinished()
    {
        if (porta != null)
        {
            porta.SetActive(false); // Porta "abre" (desaparece)
            Debug.Log("Porta aberta após o diálogo!");
        }
    }
}


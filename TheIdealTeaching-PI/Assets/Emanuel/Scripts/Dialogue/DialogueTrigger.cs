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

        
        DialogueSystem.Instance.StartDialogue(lines, gameObject.name, false, "", OnDialogueFinished);
    }

    private void OnDialogueFinished()
    {
        if (porta != null)
        {
            Debug.Log("Tentando destruir a porta...");
            Destroy(porta);
        }
        else
        {
            Debug.LogWarning("Nenhuma porta atribuída ao DialogueTrigger!");
        }
    }
}



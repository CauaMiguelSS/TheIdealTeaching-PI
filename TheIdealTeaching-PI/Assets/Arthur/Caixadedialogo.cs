using UnityEngine;
using TMPro; // Necess�rio se for usar TextMeshPro

public class NPCDialogue : MonoBehaviour
{
    [TextArea(3, 5)]
    public string dialogueText; // Texto da fala
    public GameObject dialogueUI; // Refer�ncia ao painel de di�logo
    public TMP_Text dialogueTMP; // Refer�ncia ao TextMeshPro

    private bool playerInRange;

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            ShowDialogue();
        }
    }

    void ShowDialogue()
    {
        dialogueUI.SetActive(true);
        dialogueTMP.text = dialogueText;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            playerInRange = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            dialogueUI.SetActive(false);
        }
    }
}

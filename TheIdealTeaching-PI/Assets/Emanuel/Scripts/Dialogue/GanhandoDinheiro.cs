using UnityEngine;

public class GanhandoDinheiro : MonoBehaviour
{
    [TextArea(2, 5)]
    public string[] lines;

    [SerializeField] private string playerTag = "Player";
    [SerializeField] private int quantia = 20;

    private bool playerEncostando = false;
    private bool jaInteragiu = false;

    void Update()
    {
        if (playerEncostando && !jaInteragiu && Input.GetKeyDown(KeyCode.Space))
        {
            jaInteragiu = true;

            DialogueSystem.Instance.StartDialogue(
                lines,
                gameObject.name,
                false,
                "",
                OnDialogueFinished
            );
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag(playerTag))
            playerEncostando = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag(playerTag))
            playerEncostando = false;
    }

    private void OnDialogueFinished()
    {
        DinheiroManager.Instance.Ganhar(quantia);
    }
}


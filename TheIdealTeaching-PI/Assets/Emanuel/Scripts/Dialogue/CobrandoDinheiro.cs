using UnityEngine;

public class CobrandoDinheiro : MonoBehaviour
{
    [TextArea(2, 5)]
    public string[] lines;

    [SerializeField] private GameObject objetoParaAbrir; 
    [SerializeField] private string playerTag = "Player";
    [SerializeField] private int preco = 10;

    private bool playerEncostando = false;
    private bool pagamentoFeito = false; 
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
        {
            playerEncostando = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag(playerTag))
        {
            playerEncostando = false;
        }
    }

    private void OnDialogueFinished()
    {
        
        if (pagamentoFeito)
            return;

        
        if (DinheiroManager.Instance.TentarPagar(preco))
        {
            pagamentoFeito = true;

            if (objetoParaAbrir != null)
                Destroy(objetoParaAbrir);

            Debug.Log("Valetão: Pagou, pode passar campeão.");
        }
        else
        {
            Debug.Log("Valetão: Tá duro? Volta quando tiver a grana...");
        }
    }
}


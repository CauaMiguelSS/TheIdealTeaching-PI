using UnityEngine;
using TMPro; // caso você use TextMeshPro

public class DialogueDestroyObject : MonoBehaviour
{
    [TextArea(2, 5)]
    public string[] lines;

    [Header("Sistema de Mensagem da Escola")]
    [SerializeField] private GameObject painelMensagemEscola; // painel UI que será ativado
    [SerializeField] private TextMeshProUGUI textoMensagemEscola; // texto dentro do painel
    [TextArea(2, 5)]
    [SerializeField] private string mensagemDaEscola; // mensagem que você quer exibir

    [Header("Outros")]
    [SerializeField] private GameObject objetoParaDestruir;
    [SerializeField] private string playerTag = "Player";

    private bool playerEncostando = false;
    private bool hasInteracted = false;

    void Start()
    {
        if (painelMensagemEscola != null)
            painelMensagemEscola.SetActive(false); // começa escondido
    }

    void Update()
    {
        if (playerEncostando && !hasInteracted && Input.GetKeyDown(KeyCode.Space))
        {
            hasInteracted = true;

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
 
        if (objetoParaDestruir != null)
            Destroy(objetoParaDestruir);
 
        if (painelMensagemEscola != null)
        {
            painelMensagemEscola.SetActive(true);

            if (textoMensagemEscola != null)
                textoMensagemEscola.text = mensagemDaEscola;
        }
    }
}







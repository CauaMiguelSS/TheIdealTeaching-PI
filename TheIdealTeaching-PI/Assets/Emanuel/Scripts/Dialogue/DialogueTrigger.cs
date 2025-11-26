using UnityEngine;
using TMPro; // caso use TextMeshPro

public class DialogueTrigger : MonoBehaviour
{
    [TextArea(2, 5)]
    public string[] lines;

    [Header("Mensagem da Escola")]
    [SerializeField] private GameObject painelMensagemEscola; // painel UI
    [SerializeField] private TextMeshProUGUI textoMensagemEscola; // texto dentro do painel
    [TextArea(2, 5)]
    [SerializeField] private string mensagemDaEscola; // texto que será mostrado

    [Header("Outros")]
    private bool hasInteracted = false;
    public GameObject porta;

    void Start()
    {
        if (painelMensagemEscola != null)
            painelMensagemEscola.SetActive(false); // começa oculto
    }

    public void Interact()
    {
        if (hasInteracted) return;

        hasInteracted = true;

        DialogueSystem.Instance.StartDialogue(
            lines,
            gameObject.name,
            false,
            "",
            OnDialogueFinished
        );
    }

    private void OnDialogueFinished()
    {
        // destrói a porta depois do diálogo
        if (porta != null)
            Destroy(porta);

        // ativa painel da escola
        if (painelMensagemEscola != null)
        {
            painelMensagemEscola.SetActive(true);

            if (textoMensagemEscola != null)
                textoMensagemEscola.text = mensagemDaEscola;
        }
    }
}




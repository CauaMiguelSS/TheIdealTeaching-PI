using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class DialogueSystem : MonoBehaviour
{
    public static DialogueSystem Instance;

    [Header("UI")]
    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private TextMeshProUGUI characterNameText;
    [SerializeField] private float typingSpeed = 0.04f;

    private string[] lines;
    private int currentLine;
    private bool isTyping;

    // Configuração da troca de cena (setada pelo NPC que chama)
    private bool trocaCenaNoFim = false;
    private string nomeCena = "";

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        if (dialogueBox == null || dialogueText == null || characterNameText == null)
        {
            Debug.LogError("DialogueSystem: arraste todos os campos do Inspector!");
        }
        else
        {
            dialogueBox.SetActive(false);
        }
    }

    void Update()
    {
        if (dialogueBox.activeSelf && Input.GetKeyDown(KeyCode.Space))
        {
            if (isTyping)
            {
                StopAllCoroutines();
                dialogueText.text = lines[currentLine];
                isTyping = false;
            }
            else
            {
                currentLine++;
                if (currentLine < lines.Length)
                {
                    StartCoroutine(TypeLine(lines[currentLine]));
                }
                else
                {
                    dialogueBox.SetActive(false);
                    OnDialogueEnd();
                }
            }
        }
    }

    // Diálogo simples (sem troca de cena)
    public void StartDialogue(string[] dialogueLines, string characterName)
    {
        StartDialogue(dialogueLines, characterName, false, "");
    }

    // Diálogo com troca de cena
    public void StartDialogue(string[] dialogueLines, string characterName, bool trocaCena, string cena)
    {
        lines = dialogueLines;
        currentLine = 0;
        dialogueBox.SetActive(true);

        characterNameText.text = characterName;

        // Configuração de troca de cena
        trocaCenaNoFim = trocaCena;
        nomeCena = cena;

        StartCoroutine(TypeLine(lines[currentLine]));
    }

    IEnumerator TypeLine(string line)
    {
        dialogueText.text = "";
        isTyping = true;

        foreach (char c in line)
        {
            dialogueText.text += c;
            yield return new WaitForSeconds(typingSpeed);
        }

        isTyping = false;
    }

    private void OnDialogueEnd()
    {
        if (trocaCenaNoFim && !string.IsNullOrEmpty(nomeCena))
        {
            SceneManager.LoadScene(nomeCena);
        }
    }
}





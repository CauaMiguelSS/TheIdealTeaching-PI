using UnityEngine;

public class DialogueWithChangeScene : MonoBehaviour
{
    [TextArea(2, 5)]
    public string[] lines;

    [SerializeField] private string cenaParaTrocar;
    [SerializeField] private Transform player; 
    [SerializeField] private float distanciaInteracao = 3f; 

    private bool hasInteracted = false;

    void Update()
    {
        if (hasInteracted) return;

        
        float distancia = Vector3.Distance(player.position, transform.position);

        if (distancia <= distanciaInteracao && Input.GetKeyDown(KeyCode.Space))
        {
            hasInteracted = true;
            DialogueSystem.Instance.StartDialogue(lines, gameObject.name, true, cenaParaTrocar);
        }
    }
}





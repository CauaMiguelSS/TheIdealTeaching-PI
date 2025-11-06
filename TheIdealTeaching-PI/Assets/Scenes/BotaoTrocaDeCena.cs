using UnityEngine;
<<<<<<< Updated upstream
using UnityEngine.SceneManagement;

public class BotaoTrocarDeCena : MonoBehaviour
{
    [SerializeField] private string nomeCenaDestino; // Nome da cena pra trocar

    public void TrocarCena()
    {
        if (!string.IsNullOrEmpty(nomeCenaDestino))
        {
            Debug.Log($"Trocando para a cena: {nomeCenaDestino}");
            SceneManager.LoadScene(nomeCenaDestino);
        }
        else
        {
            Debug.LogWarning("?? Nenhuma cena foi definida no botão!");
        }
    }
}

=======

public class BotaoTrocaDeCena : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
>>>>>>> Stashed changes

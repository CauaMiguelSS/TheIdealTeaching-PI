using UnityEngine;
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


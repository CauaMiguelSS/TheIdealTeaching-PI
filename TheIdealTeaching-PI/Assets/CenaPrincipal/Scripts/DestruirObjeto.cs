using UnityEngine;

public class DestruirObjeto : MonoBehaviour
{
    public AtivarBotao botao1;
    public AtivarBotao botao2;

    void Update()
    {
        if (botao1.estaPressionado && botao2.estaPressionado)
        {
            gameObject.SetActive(false); // Porta abre (desativa)
        }
        else
        {
            gameObject.SetActive(true); // Porta fecha (ativa de novo)
        }
    }
}
using UnityEngine;

public class DestruirObjX4 : MonoBehaviour
{
    public AtivarBotao botao1;
    public AtivarBotao botao2;
    public AtivarBotao botao3;
    public AtivarBotao botao4;

    void Update()
    {
        if (botao1.estaPressionado && botao2.estaPressionado && botao3.estaPressionado && botao4.estaPressionado)
        {
            gameObject.SetActive(false); // Porta abre (desativa)
        }
        else
        {
            gameObject.SetActive(true); // Porta fecha (ativa de novo)
        }
    }
}

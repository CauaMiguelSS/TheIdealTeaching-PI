using UnityEngine;

public class DestruirObjX4 : MonoBehaviour
{
    public AtivarBotao botao5;
    public AtivarBotao botao6;
    public AtivarBotao botao3;
    public AtivarBotao botao4;

    void Update()
    {
        if (botao6.estaPressionado && botao5.estaPressionado && botao3.estaPressionado && botao4.estaPressionado)
        {
            gameObject.SetActive(false);
            Debug.Log("Portão Destroido");
        }
        else
        {
            gameObject.SetActive(true);
        }
    }
}

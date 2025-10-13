using System.Collections;
using UnityEngine;
using TMPro;

public class TextoComFade : MonoBehaviour
{
    public TextMeshProUGUI texto;
    public float duracao = 2f; // Tempo de fade in e fade out
    public float tempoVisivel = 6f; // Tempo que o texto permanece vis�vel ap�s o fade in

    void Start()
    {
        StartCoroutine(MostrarTextoComFade("Paulo freire house"));
    }

    IEnumerator MostrarTextoComFade(string mensagem)
    {
        texto.text = mensagem;
        texto.gameObject.SetActive(true);

        Color cor = texto.color;

        // Fade in
        for (float t = 0; t < duracao; t += Time.deltaTime)
        {
            cor.a = Mathf.Lerp(0, 1, t / duracao);
            texto.color = cor;
            yield return null;
        }
        cor.a = 1;
        texto.color = cor;

        yield return new WaitForSeconds(tempoVisivel);

        // Fade out
        for (float t = 0; t < duracao; t += Time.deltaTime)
        {
            cor.a = Mathf.Lerp(1, 0, t / duracao);
            texto.color = cor;
            yield return null;
        }
        cor.a = 0;
        texto.color = cor;

        texto.gameObject.SetActive(false);
    }
}
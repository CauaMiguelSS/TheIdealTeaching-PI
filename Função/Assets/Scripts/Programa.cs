using UnityEngine;

public class Programa : MonoBehaviour
{

    void Start()
    {
        int n = 5;
        ImprimirSequencia(n);
    }

    void ImprimirSequencia(int n)
    {
        string resultado = "";

        for (int i = 1; i <= n; i++)
        {
            for (int j = 1; j <= i; j++)
            {
                resultado += i.ToString();
            }
            resultado += "\n"; 
        }

        Debug.Log(resultado);
    }

}

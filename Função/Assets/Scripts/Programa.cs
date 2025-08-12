using UnityEngine;

public class Programa : MonoBehaviour
{

    void Start()
    {
        int numeroTeste = 5; 
        char resultado = VerificarNumero(numeroTeste);
        Debug.Log("Resultado: " + resultado);
    }
    char VerificarNumero(float numero)
    {
        if (numero > 0)
            return 'P';
        else
            return 'N';
    }
}

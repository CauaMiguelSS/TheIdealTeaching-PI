using UnityEngine;

public class DinheiroManager : MonoBehaviour
{
    public static DinheiroManager Instance;

    public int dinheiroAtual = 0;

    private void Awake()
    {
        Instance = this;
    }

    public bool TemDinheiro(int valor)
    {
        return dinheiroAtual >= valor;
    }

    public void Gastar(int valor)
    {
        dinheiroAtual -= valor;
    }

    public void Ganhar(int valor)
    {
        dinheiroAtual += valor;
    }

    public bool TentarPagar(int valor)
    {
        if (TemDinheiro(valor))
        {
            Gastar(valor);
            return true;
        }

        return false;
    }
}


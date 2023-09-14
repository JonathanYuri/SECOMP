using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GerenciadorDePersonagens : MonoBehaviour
{
    TrocarDeCenas trocarDeCenas;

    private void Start()
    {
        trocarDeCenas = FindObjectOfType<TrocarDeCenas>();
    }

    public void MatarPersonagem(GameObject personagem)
    {
        Destroy(personagem);
        StartCoroutine(VoltarParaOMenu());
    }

    IEnumerator VoltarParaOMenu()
    {
        yield return new WaitForSeconds(2f);
        trocarDeCenas.VoltarParaOMenu();
    }
}

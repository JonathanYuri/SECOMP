using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TrocarPontuacao : MonoBehaviour
{
    TrocarDeCena trocarDeCena;

    [SerializeField] TMP_Text pontuacao;

    private void Start()
    {
        trocarDeCena = FindObjectOfType<TrocarDeCena>();
        pontuacao.text = trocarDeCena.pontuacao.ToString();
    }
}

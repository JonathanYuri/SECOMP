using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TrocarPontuacao : MonoBehaviour
{
    [SerializeField] TMP_Text pontuacao;

    // Start is called before the first frame update
    void Start()
    {
        pontuacao.text = TrocarDeCena.Instance.GetScore().ToString();
    }
}

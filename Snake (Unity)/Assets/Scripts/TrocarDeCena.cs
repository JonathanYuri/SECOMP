using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrocarDeCena : MonoBehaviour
{
    public int pontuacao = 0;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void Jogar()
    {
        SceneManager.LoadScene("Jogo");
    }

    public void IrParaOMenu(int pontuacao)
    {
        this.pontuacao = pontuacao;
        SceneManager.LoadScene("Menu");
    }

    public void SairDoJogo()
    {
        Application.Quit();
    }
}

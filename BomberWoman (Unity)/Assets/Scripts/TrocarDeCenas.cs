using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrocarDeCenas : MonoBehaviour
{
    [SerializeField] GameObject menu;
    [SerializeField] GameObject selecaoPersonagens;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void SelecionarPersonagens()
    {
        selecaoPersonagens.SetActive(true);
        menu.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Jogar()
    {
        SceneManager.LoadScene("Jogo");
    }

    public void VoltarParaOMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelecionarJogadores : MonoBehaviour
{
    [SerializeField]
    int qntPraSelecionar = 2;

    [SerializeField]
    List<GameObject> jogadores;

    List<GameObject> selecionados;

    private void Awake()
    {
        selecionados = new();
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    public void SelecionarJogador(string name)
    {
        selecionados.Add(jogadores.Find(x => x.name.Equals(name)));
        if (selecionados.Count == qntPraSelecionar)
        {
            TrocarDeCenas.ChangeScene("Jogo");
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Jogo")
        {
            for (int i = 0; i < selecionados.Count; i++)
            {
                if (i == 0) // instaciar na ponta esq
                {
                    GameObject selecionado = Instantiate(selecionados[i], new Vector3(-8, 4), Quaternion.identity);
                    Personagem personagem = selecionado.GetComponent<Personagem>();
                    personagem.upArrow = KeyCode.W;
                    personagem.downArrow = KeyCode.S;
                    personagem.leftArrow = KeyCode.A;
                    personagem.rightArrow = KeyCode.D;
                    personagem.colocarBomba = KeyCode.L;
                }
                else if (i == 1)
                {
                    GameObject selecionado = Instantiate(selecionados[i], new Vector3(8, 4), Quaternion.identity);
                    Personagem personagem = selecionado.GetComponent<Personagem>();
                    personagem.upArrow = KeyCode.UpArrow;
                    personagem.downArrow = KeyCode.DownArrow;
                    personagem.leftArrow = KeyCode.LeftArrow;
                    personagem.rightArrow = KeyCode.RightArrow;
                    personagem.colocarBomba = KeyCode.Keypad1;
                }
                else if (i == 2)
                {
                    Instantiate(selecionados[i], new Vector3(8, -4), Quaternion.identity);
                }
                else if (i == 3)
                {
                    Instantiate(selecionados[i], new Vector3(-8, -4), Quaternion.identity);
                }
            }
        }
    }
}

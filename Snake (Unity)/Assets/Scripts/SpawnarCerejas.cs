using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnarCerejas : MonoBehaviour
{
    List<Vector3> possibilidades;
    Snake snake;

    [SerializeField] GameObject cereja;

    private void Awake()
    {
        possibilidades = new();

        for (int i = -8; i <= 8; i++)
        {
            for (int j = 4; j >= -4; j--)
            {
                possibilidades.Add(new Vector3(i, j));
            }
        }
    }

    private void Start()
    {
        snake = FindObjectOfType<Snake>();
        SpawnarCereja();
    }

    public void SpawnarCereja()
    {
        List<Vector3> posicoesDaCobra = snake.PosicoesDaCobra();
        List<Vector3> possibilidadesSemSerNaCobra = possibilidades.Except(posicoesDaCobra).ToList();

        int escolhido = Random.Range(0, possibilidadesSemSerNaCobra.Count);
        Instantiate(cereja, possibilidadesSemSerNaCobra[escolhido], Quaternion.identity);
    }
}

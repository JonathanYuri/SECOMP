using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstaculo : MonoBehaviour
{
    [SerializeField] List<GameObject> upgrades;
    [SerializeField] float chanceDeSpawnarUmObstaculo = 0.3f;

    GerenciadorDeObstaculos gerenciadorDeObstaculos;

    [SerializeField]
    bool indestrutivel;

    private void Start()
    {
        gerenciadorDeObstaculos = FindObjectOfType<GerenciadorDeObstaculos>();
    }

    public void Destruir()
    {
        if (indestrutivel)
        {
            return;
        }

        if (Random.value < chanceDeSpawnarUmObstaculo)
        {
            GameObject escolhido = upgrades[Random.Range(0, upgrades.Count)];
            Instantiate(escolhido, this.transform.position, Quaternion.identity);
        }
        gerenciadorDeObstaculos.ExcluirObstaculo(this.gameObject);
        Destroy(gameObject);
    }
}

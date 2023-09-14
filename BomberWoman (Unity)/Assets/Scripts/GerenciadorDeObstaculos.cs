using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GerenciadorDeObstaculos : MonoBehaviour
{
    public List<GameObject> obstaculos;

    [SerializeField]
    GameObject obstaculoIndestrutivel;

    [SerializeField]
    GameObject obstaculoDestrutivel;

    [SerializeField]
    GameObject obstaculoLados;

    [SerializeField]
    GameObject cenario;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = -7; i <= 7; i += 2)
        {
            for (int j = 3; j >= -3; j -= 2)
            {
                GameObject obstaculo = Instantiate(obstaculoIndestrutivel, new Vector3(i, j), Quaternion.identity, cenario.transform);
                obstaculos.Add(obstaculo);
            }
        }

        for (int i = -8; i <= 8; i += 2)
        {
            for (int j = 4; j >= -4; j -= 2)
            {
                if (i == -8 || i == 8)
                {
                    if (j == 4 || j == -4)
                    {
                        continue;
                    }
                }
                GameObject obstaculo = Instantiate(obstaculoDestrutivel, new Vector3(i, j), Quaternion.identity, cenario.transform);
                obstaculos.Add(obstaculo);
            }
        }

        for (int i = -9; i <= 9; i++)
        {
            GameObject obstaculo = Instantiate(obstaculoLados, new Vector3(i, 5), Quaternion.identity, cenario.transform);
            obstaculos.Add(obstaculo);
            obstaculo = Instantiate(obstaculoLados, new Vector3(i, -5), Quaternion.identity, cenario.transform);
            obstaculos.Add(obstaculo);
        }

        for (int j = 4; j >= -4; j--)
        {
            GameObject obstaculo = Instantiate(obstaculoLados, new Vector3(-9, j), Quaternion.identity, cenario.transform);
            obstaculos.Add(obstaculo);
            obstaculo = Instantiate(obstaculoLados, new Vector3(9, j), Quaternion.identity, cenario.transform);
            obstaculos.Add(obstaculo);
        }
    }

    public Obstaculo TemUmObstaculoNaPosicao(int x, int y)
    {
        foreach (var obstaculo in obstaculos)
        {
            if (obstaculo.transform.position.x == x && obstaculo.transform.position.y == y)
            {
                return obstaculo.GetComponent<Obstaculo>();
            }
        }

        return null;
    }

    public void ExcluirObstaculo(GameObject obstaculo)
    {
        obstaculos.Remove(obstaculo);
    }
}

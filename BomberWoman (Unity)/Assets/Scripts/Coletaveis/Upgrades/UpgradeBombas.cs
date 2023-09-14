using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeBombas : MonoBehaviour, IColetavel
{
    public bool Pego { get; private set; }

    public void Coletar(Personagem personagem)
    {
        personagem.bombas++;
        Pego = true;
        Destruir();
    }

    public void Destruir()
    {
        Destroy(gameObject);
    }
}

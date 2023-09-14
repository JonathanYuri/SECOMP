using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeRangeBombas : MonoBehaviour, IColetavel
{
    public bool Pego { get; private set; }

    public void Coletar(Personagem personagem)
    {
        personagem.range++;
        Pego = true;
        Destruir();
    }

    public void Destruir()
    {
        Destroy(gameObject);
    }
}

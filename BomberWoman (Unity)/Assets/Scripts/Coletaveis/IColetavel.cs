using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IColetavel
{
    public bool Pego { get; }

    public void Coletar(Personagem personagem);
}

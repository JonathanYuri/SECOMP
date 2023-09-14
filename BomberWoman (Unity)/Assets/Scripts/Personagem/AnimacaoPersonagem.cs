using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimacaoPersonagem : MonoBehaviour
{
    Animator animator;
    Personagem personagem;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        personagem = GetComponent<Personagem>();
    }

    void Update()
    {
        animator.SetFloat("OlhandoHorizontal", personagem.olhandoPara.x);
        animator.SetFloat("OlhandoVertical", personagem.olhandoPara.y);

        animator.SetBool("isMoving", !personagem.movement.Equals(Vector3.zero));
        animator.SetFloat("HorizontalMovement", personagem.movement.x);
        animator.SetFloat("VerticalMovement", personagem.movement.y);
    }
}

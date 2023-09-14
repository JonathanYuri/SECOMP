using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] float timeToUpdate;
    float time;

    Snake snake;

    private void Start()
    {
        snake = FindObjectOfType<Snake>();
    }

    private void Update()
    {
        time += Time.deltaTime;
        if (time > timeToUpdate)
        {
            time = 0;
            snake.Move();
            snake.AddFilho();
        }
    }
}

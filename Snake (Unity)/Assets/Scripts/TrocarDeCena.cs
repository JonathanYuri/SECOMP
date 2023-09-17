using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrocarDeCena : MonoBehaviour
{
    private static TrocarDeCena instance;

    int score = 0;

    public static TrocarDeCena Instance { get => instance; set => instance = value; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public static void ChangeScene(string sceneName)
    {
        if (Instance != null)
        {
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            Debug.LogError("SceneManager instance is null. Make sure to attach the SceneManager script to a GameObject.");
        }
    }

    public void SetScore(int pontos)
    {
        score = pontos;
    }

    public int GetScore()
    {
        return score;
    }

    public void SairDoJogo()
    {
        Application.Quit();
    }
}

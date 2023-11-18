using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class menuScript : MonoBehaviour
{

    public Button startGame;

    void Start()
    {
    }

    void Update()
    {

    }

    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
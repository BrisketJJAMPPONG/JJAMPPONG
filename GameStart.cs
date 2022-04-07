using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameStart : MonoBehaviour
{
    public Button StartBtn;
    public GameObject StopPanel;
    bool isPausing = false;

    public void StopGame()
    {
        
        Application.Quit();
    }
     public void InitGame() //���� ���� �Լ�
    {
        SceneManager.LoadScene("GameScene");
    }
    public void PauseGame() //���� �Ͻ����� �Լ�
    {
        Time.timeScale = 0f;

    }

    public void ContinueGame() //���� �簳 �Լ�
    {
        Time.timeScale = 1f;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPausing == false)
            {
                isPausing = true;
                StopPanel.SetActive(true);
                PauseGame();
                return;
            }
            if(isPausing == true)
            {
                isPausing = false;
                StopPanel.SetActive(false);
                ContinueGame();
                return;
            }
            
        }

    }
}

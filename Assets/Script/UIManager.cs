using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject WhiteScreen;
    public GameObject Quit;

    public Text ScoreText;

    void Update()
    {
        ScoreText.text = GameManager.instance.Score.ToString();
    }

    public void Restart()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GameOver()
    {
        WhiteScreen.SetActive(true);
        ScoreText.gameObject.SetActive(false);
        if (PlayerPrefs.GetInt("BestScore", 0) < int.Parse(ScoreText.text))
            PlayerPrefs.SetInt("BestScore", int.Parse(ScoreText.text));
    }

    public void SetQuit()
    {
        Quit.SetActive(true);
        Quit.transform.Find("ScoreScreen").GetComponent<Text>().text = ScoreText.text;
        Quit.transform.Find("BestScreen").GetComponent<Text>().text = PlayerPrefs.GetInt("BestScore").ToString();
    }
}

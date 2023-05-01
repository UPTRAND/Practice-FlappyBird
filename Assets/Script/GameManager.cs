using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance
    {
        get
        {
            if (m_instance == null)
            {
                m_instance = FindObjectOfType<GameManager>();
            }

            return m_instance;
        }
    }
    private static GameManager m_instance;

    public UIManager uiManager;
    public float Score = 0;
    public float MaxScore;
    public bool isStop = false;

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour
{
    private TMP_InputField playerNameInputField;
    private TMP_Text highscoreText;

    private void Awake()
    {
        playerNameInputField = GameObject.Find("Player Name Input Field").GetComponent<TMP_InputField>();
        highscoreText = GameObject.Find("Current Highscore").GetComponent<TMP_Text>();

        playerNameInputField.text = PersistencyManager.Instance.currentPlayerName;
        highscoreText.text = "Highscore: " + PersistencyManager.Instance.highscorePlayerName + " with " + PersistencyManager.Instance.highscoreScore + " Points";
    }

    public void StartGame()
    {
        PersistencyManager.Instance.currentPlayerName = playerNameInputField.text;
        PersistencyManager.Instance.SaveHighscore();
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}

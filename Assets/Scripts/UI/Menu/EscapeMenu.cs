using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EscapeMenu : Menu
{    
    [SerializeField] private Button backToGame;
    [SerializeField] private Button backToMenu;
    [SerializeField] private Button quit;

    [SerializeField] private GameObject escMenu;
    void Start()
    {
        backToGame.onClick.AddListener(TogglePause);
        backToMenu.onClick.AddListener(ToMenu);
        quit.onClick.AddListener(Quit);

        escMenu.SetActive(false);
    }

    void Update() {
        if (Input.GetButtonDown("Escape")) {
            TogglePause();
        }
    }
    void ToMenu() {
        Run.ChangeMenuCount(false, this);
        Game.i.LoadScene(Game.SceneName.MainMenu);
    }

    void TogglePause() {
        escMenu.SetActive(!escMenu.activeSelf);
        Run.ChangeMenuCount(escMenu.activeSelf, this);
    }

    void Quit()
    {
        Game.i.Quit();
    }
}

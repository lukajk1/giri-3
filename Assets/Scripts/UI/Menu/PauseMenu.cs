using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : Menu
{    
    [SerializeField] private Button backToGame;
    [SerializeField] private Button settings;
    [SerializeField] private Button backToMenu;
    [SerializeField] private Button quit;

    [SerializeField] private GameObject escMenu;
    void Start()
    {
        backToGame.onClick.AddListener(ToggleMenu);
        settings.onClick.AddListener(Settings);
        backToMenu.onClick.AddListener(ToMenu);
        quit.onClick.AddListener(Quit);

        escMenu.SetActive(false);
    }

    void Update() {
        if (Input.GetButtonDown("Escape")) {
            ToggleMenu();
        }
    }
    void ToMenu() {
        Run.ChangeMenuCount(false, this);
        Game.i.LoadScene(GameScene.MainMenu);
    }

    void Settings()
    {
        SettingsMenu.i.Open();
    }

    void ToggleMenu() {
        escMenu.SetActive(!escMenu.activeSelf);
        Run.ChangeMenuCount(escMenu.activeSelf, this);
    }

    void Quit()
    {
        ToggleMenu();
        Game.i.Quit();
    }
}

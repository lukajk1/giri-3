using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : Menu
{

    [SerializeField] private Button play;
    [SerializeField] private Button settings;
    [SerializeField] private Button quit;

    [SerializeField] private GameObject settingsMenu; 

    void Awake() 
    {
        play.onClick.AddListener(Play);
        settings.onClick.AddListener(OpenOptions);
        quit.onClick.AddListener(Quit);
    }
    private void Play() 
    {
        Game.i.LoadScene(Game.SceneName.Game);
    }

    void OpenOptions() 
    { 
        settingsMenu.SetActive(true);
    }

    void Quit()
    {
        Game.i.Quit();
    }
}

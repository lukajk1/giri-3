using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : Menu
{

    [SerializeField] private Button play;
    [SerializeField] private Button options;
    [SerializeField] private Button quit;

    void Awake() 
    {
        play.onClick.AddListener(Play);
        options.onClick.AddListener(OpenOptions);
        quit.onClick.AddListener(Application.Quit);
    }
    private void Play() 
    {
        Game.i.LoadScene(Game.Scene.Game);
    }

    void OpenOptions() { }
}

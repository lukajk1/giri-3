using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour, IDataPersistence {
    [SerializeField] private Button play;
    [SerializeField] private Button options;
    [SerializeField] private Button quit;
    [SerializeField] private TextMeshProUGUI highScoreTxt;
    private int highScore;
    private DataPersistenceManager dataPersistence;
    void Start() {
        play.onClick.AddListener(playGame);
        options.onClick.AddListener(optionsOpen);
        quit.onClick.AddListener(Application.Quit);

        dataPersistence = DataPersistenceManager.instance;
        dataPersistence.LoadGame();
        highScoreTxt.text = "Best: " + highScore.ToString();
    }
    void playGame() {
        SceneManager.LoadScene("Game");
    }
    
    public void LoadData(GameData data) {
        highScore = data.highScore;
    }

    public void SaveData(ref GameData data) {}

    void optionsOpen() {
        
    }
}

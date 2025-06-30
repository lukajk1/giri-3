using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;
using System;

public class DataPersistenceManager : MonoBehaviour
{
    [Header("File Storage Config")]
    [SerializeField] private string fileName;
    public GameData gameData;
    private List<IDataPersistence> dataPersistenceObjects;
    private FileDataHandler dataHandler;
    public static DataPersistenceManager instance { get; private set; }
    //static type cannot be instantiated

    private void Awake() {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start() {
        this.dataHandler = new FileDataHandler(Application.persistentDataPath, fileName);
        FindAllDataPersistenceObjects();
        //LoadGame();
    }

    public void NewGame() {
        this.gameData = new GameData();
    }

    public void LoadGame() {
        try {
            this.gameData = dataHandler.Load();
        }
        catch (NullReferenceException ex) {
            print(ex + "probably due to launching through the game scene rather than menu");
        }

        //load save data from data handler
        if (this.gameData == null) {
            print("no data found. initializing to defaults");
            NewGame();
        }

        FindAllDataPersistenceObjects();
        //push loaded data to respective scripts
        foreach (IDataPersistence dataPersistenceObj in dataPersistenceObjects) {
            dataPersistenceObj.LoadData(gameData);
        }

        //print("loaded pos " + gameData.playerPos);
    }

    public void SaveGame() {
        // print("SaveGame() has been called in scene " + SceneManager.GetActiveScene().name);
        // print("there are " + dataPersistenceObjects.Count() + " objects information needs to be saved to");
        FindAllDataPersistenceObjects();
        foreach (IDataPersistence dataPersistenceObj in dataPersistenceObjects) {
            // if (dataPersistenceObj == null) {
            //     print(dataPersistenceObj + " was null, now skipping..");
            //     continue;
            // }

            // print("attempting to save " + dataPersistenceObj);
            dataPersistenceObj.SaveData(ref gameData);
            // print("saved " + dataPersistenceObj);
        }
        

        dataHandler.Save(gameData); //writes to json
        //print("saved");
    }

    public void FindAllDataPersistenceObjects() {
        IEnumerable<IDataPersistence> dataPersistenceObjects 
            = FindObjectsByType<MonoBehaviour>(FindObjectsSortMode.None).OfType<IDataPersistence>();

        //print("updated list of dataPersistenceObjects");
        //print("the length of dataPersistenceObjects is " + dataPersistenceObjects.Count());

        //print("trying again");
        // foreach (IDataPersistence obj in dataPersistenceObjects) {
        //     print(obj + "is an item in dataPersistenceObjects");    
        // }
        // print("the length of dataPersistenceObjects is " + dataPersistenceObjects.Count());

        this.dataPersistenceObjects = new List<IDataPersistence>(dataPersistenceObjects);

        //return new List<IDataPersistence>(dataPersistenceObjects);
    }

}

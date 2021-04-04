using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    
    public enum GameState
    {

        PREGAME,
        RUNNING,
        PAUSED

    }

    private GameState _currentState = GameState.RUNNING;

    public GameState currentState
    {

        get { return _currentState; }

        private set { _currentState = value; }

    }

    public Events.EventGameState OnGameStateChanged;

    [Header("Level Loading and Unloading")]
    private string _currentLevel = string.Empty;
    public string CurrentLevel { get { return _currentLevel; }}

    List<AsyncOperation> _loadOperations;

    [Header("Other Persistent Systems")]
    public GameObject[] SystemPrefabs;
    List<GameObject> _instancedPrefabs;

    private void Start()
    {

        DontDestroyOnLoad(this.gameObject);

        _instancedPrefabs = new List<GameObject>();
        _loadOperations = new List<AsyncOperation>();
        InstantiateSystemPrefabs();


    }

    private void Update()
    {
        
        if(_currentState == GameState.PREGAME)
        {
            return;
        }

    }

    public void LoadLevel(string levelName)
    {

        AsyncOperation ao = SceneManager.LoadSceneAsync(levelName, LoadSceneMode.Additive);

        if(ao == null)
        {
            Debug.LogError("[GameManager] Could not load level " + levelName);
            return;
        }

        ao.completed += OnLoadOperationComplete;
        _loadOperations.Add(ao);

        _currentLevel = levelName;


    }

    private void OnLoadOperationComplete(AsyncOperation ao)
    {
        if (_loadOperations.Contains(ao))
        {

            _loadOperations.Remove(ao);

            if (_loadOperations.Count == 0)
            {

                UpdateState(GameState.RUNNING);

            }

        }

        Debug.Log("Load Complete.");
    }

    private void UnloadLevel(string levelName)
    {

        AsyncOperation ao = SceneManager.UnloadSceneAsync(levelName);

        if (ao == null)
        {

            Debug.LogError("[GameManager] Could not unload level " + levelName);
            return;

        }

        ao.completed += OnUnloadOperationComplete;

    }

    private void OnUnloadOperationComplete(AsyncOperation ao)
    {
        throw new NotImplementedException();
    }

    private void UpdateState(GameState newState)
    {
        GameState _oldState = _currentState;
        _currentState = newState;

        switch (_currentState)
        {

            case GameState.PREGAME:

                Time.timeScale = 1.0f;
                break;

            case GameState.PAUSED:

                Time.timeScale = 0.0f;
                break;

            case GameState.RUNNING:

                Time.timeScale = 1.0f;
                break;

            default:
                break;

        }

        OnGameStateChanged?.Invoke(_currentState, _oldState);

    }

    private void InstantiateSystemPrefabs()
    {
        foreach (GameObject obj in SystemPrefabs)
        {

            GameObject instanced = Instantiate(obj);
            _instancedPrefabs.Add(instanced);

        }
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();

        foreach (GameObject obj in _instancedPrefabs)
        {
            Destroy(obj);

        }

        _instancedPrefabs.Clear();

    }

    public void StartGame()
    {

        LoadLevel("Main");

    }

    public void TogglePause()
    {

        UpdateState(_currentState == GameState.RUNNING ? GameState.PAUSED : GameState.RUNNING);

    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void RestartGame()
    {
        UpdateState(GameState.RUNNING);
    }

}

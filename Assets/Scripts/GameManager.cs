using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoSingleton<GameManager>
{
    public static event System.Action RequestsMinigameEnd;

    public Player Player { get
        {
            if (player == null)
                player = FindObjectOfType<Player>();
            return player;
        } 
    }
    Player player;

    [ShowInInspector] private GameState state;
    [ShowInInspector] Scene mainScene;

    protected override void Awake()
    {
        base.Awake();
        EventManager.RequestGameStart += () => StartGame("Game");
        if (Player == null)
            FindObjectOfType<Player>();
    }

    private void OnDisable()
    {
        EventManager.RequestGameStart -= () => StartGame("Game");
    }

    public void StartGame(string scene)
    {
        Debug.Log("Game Loading");
        mainScene = SceneManager.GetActiveScene();
        SetState(GameState.LoadingScene);
        StartCoroutine(LoadScene(scene));
    }
    public void EndGame(string scene)
    {
        SetState(GameState.UnloadingScene);
        StartCoroutine(UnloadScene(scene));
    }

    public void MinigameEndRequest()
    {
        if (state == GameState.MinigameActive)
            RequestsMinigameEnd?.Invoke();
        else
            Debug.LogWarning("Should not exit game before it is loaded! Or not active!");
    }

    public IEnumerator LoadScene(string scene)
    {
        var progress = SceneManager.LoadSceneAsync(scene, LoadSceneMode.Single);
        while (!progress.isDone)
            yield return null;

        SetState(GameState.MinigameActive);
    }

    public IEnumerator UnloadScene(string scene)
    {
        //SceneManager.SetActiveScene(mainScene);
        var progress = SceneManager.LoadSceneAsync(scene, LoadSceneMode.Additive);

        while (!progress.isDone)
            yield return null;

        SetState(GameState.MainActive);
    }

    public void SetState(GameState state)
    {
        this.state = state;
    }
}
public enum GameState
{
    MainActive,
    LoadingScene,
    MinigameActive,
    UnloadingScene
}
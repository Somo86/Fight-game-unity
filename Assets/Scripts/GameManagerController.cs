using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManagerController : MonoBehaviour
{
    public string Level;
    public Text LevelText;
    public Text FinalText;
    public GameObject Heroe;
    private GameObject[] Enemies;
    private List<GameObject> EnemiesInGame;
    private void Awake()
    {
        EnemiesInGame = new List<GameObject>();
        Enemies = GameObject.FindGameObjectsWithTag("Enemy");
        for (int i = 0; i < Enemies.Length; i++)
        {
            AddEnemyToList(Enemies[i]);
        }
    }

    void Start()
    {
        LevelUI();
        AssignDelegates();
    }

    private void LevelUI()
    {
        LevelText.text = Level;
    }

    private void AssignDelegates()
    {
        // Heroe delegates
        var heroeController = Heroe.GetComponent<HeroController>();
        heroeController.OnKill += KillHeroe;

        // Enemies delegates
        for (int i = 0; i < Enemies.Length; i++)
        {
            var EnemyController = Enemies[i].GetComponent<EnemyController>();
            EnemyController.OnKill += UpdateCharactersList;
        }
    }

    private void AddEnemyToList(GameObject EnemyInGame)
    {
        EnemiesInGame.Add(EnemyInGame);
    }

    public void KillHeroe()
    {
        // Reload current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void UpdateCharactersList(GameObject enemy)
    {
        EnemiesInGame.Remove(enemy);
        CheckForWinner();
    }

    private void CheckForWinner()
    {
        if (EnemiesInGame.Count == 0)
        {
            FinalText.text = "Level Done";
            // Go to next Scene
            Invoke(nameof(Win), 4f);
        }
    }

    private void Win()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}

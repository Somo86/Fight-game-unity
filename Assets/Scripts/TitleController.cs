using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleController : MonoBehaviour
{
    void Start()
    {
        Invoke(nameof(GoToScene1), 3f);
    }

    private void GoToScene1()
    {
        SceneManager.LoadScene("Menu");
    }
}

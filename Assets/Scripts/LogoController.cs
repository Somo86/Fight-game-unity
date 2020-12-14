using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LogoController : MonoBehaviour
{
    void Start()
    {
        Invoke(nameof(GoToTitle), 3f);
    }

    private void GoToTitle()
    {
        SceneManager.LoadScene("Title");
    }
}

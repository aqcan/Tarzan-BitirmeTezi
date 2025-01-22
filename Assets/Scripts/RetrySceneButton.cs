using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RetrySceneButton : MonoBehaviour
{
    public void RetryButton()
    {
        SceneManager.LoadScene(1);
    }
}

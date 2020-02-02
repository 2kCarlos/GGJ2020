using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetButtonBehav : MonoBehaviour
{
    public void OnResetButton()
    {
        SceneManager.LoadScene("Floor 1");
    }
}

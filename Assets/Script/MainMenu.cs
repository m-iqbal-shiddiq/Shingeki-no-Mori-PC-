using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void SelectLevel(string nameScene)
    {
        Application.LoadLevel(nameScene);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2 : MonoBehaviour
{
    public void Menu(string nameScene)
    {
        Application.LoadLevel(nameScene);
    }
}

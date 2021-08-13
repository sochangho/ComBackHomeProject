using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorialinitialization : MonoBehaviour
{
    

    private void Start()
    {
        TutorialSystem.Instance.TutorialsAdd();
        TutorialSystem.Instance.RestartQuest();
        
    }
}

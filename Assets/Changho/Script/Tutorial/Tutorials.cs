using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorials : MonoBehaviour
{
    [HideInInspector]
    public string name;

    [HideInInspector]
    public string suscript;

    public TutorialState tutorialState = TutorialState.Before;

    public virtual void TutorialSet()
    {



    }

    public virtual TutorialState CompleteConditon()
    {

        return tutorialState;

    }

    public virtual string SetCondition()
    {

        return "";
    }

}

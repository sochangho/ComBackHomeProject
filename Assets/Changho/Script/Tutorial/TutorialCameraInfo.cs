using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialCameraInfo : MonoBehaviour
{



   int tutorial_index; 
   Vector3 destination_position;
   Transform look_transform; 
   

    public TutorialCameraInfo(int index , Vector3 position , Transform look_transform)
    {
        tutorial_index = index;
        destination_position = position;
        this.look_transform = look_transform;
        

    }

    public void GetTutorialCameraInfo( out Vector3 destiantion , out Transform look)
    {

        destiantion = destination_position;
        look = look_transform;

    }

   public int GetTutorialIndex()
    {

        return tutorial_index;
    }
    


}

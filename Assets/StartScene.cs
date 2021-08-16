
using UnityEngine;

public class StartScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {

        if (FindObjectOfType<ItemSystem>() != null)
        {
            Destroy(FindObjectOfType<ItemSystem>().gameObject);
        }
        if (FindObjectOfType<ObjectPoolMgr>() != null)
        {
            Destroy(FindObjectOfType<ObjectPoolMgr>().gameObject);
        }
        if (FindObjectOfType<TutorialSystem>() != null)
        {
            Destroy(FindObjectOfType<TutorialSystem>().gameObject);
        }
        if (FindObjectOfType<DaySystem>() != null)
        {
            Destroy(FindObjectOfType<DaySystem>().gameObject);
        }
        if (FindObjectOfType<Sounds>() != null)
        {
            Destroy(FindObjectOfType<Sounds>().gameObject);
        }
    }

}

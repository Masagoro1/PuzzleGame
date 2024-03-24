using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class firstTutorialButton : MonoBehaviour
{
    public Button tutorial;
    // Start is called before the first frame update
    void Start()
    {
        tutorial.onClick.AddListener(deleteSelf);
    }

    void deleteSelf()
    {
        Destroy(tutorial.gameObject);
    }
}

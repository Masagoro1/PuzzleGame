// To use this example, attach this script to an empty GameObject.
// Create three buttons (Create>UI>Button). Next, select your
// empty GameObject in the Hierarchy and click and drag each of your
// Buttons from the Hierarchy to the Your First Button, Your Second Button
// and Your Third Button fields in the Inspector.
// Click each Button in Play Mode to output their message to the console.
// Note that click means press down and then release.

using UnityEngine;
using UnityEngine.UI;

public class Example : MonoBehaviour
{
    //Make sure to attach these Buttons in the Inspector
    public Button level, quit, level1, level2;

    void Start()
    {
        //Calls the TaskOnClick/TaskWithParameters/ButtonClicked method when you click the Button
        level.onClick.AddListener(levelSelector);
        quit.onClick.AddListener(Quit);
        level1.onClick.AddListener(Quit);
        level2.onClick.AddListener(Quit);

    }

    void Quit()
    {
        Application.Quit();
    }

    void levelSelector()
    {
        level.gameObject.SetActive(false);
        level1.gameObject.SetActive(true);
        level2.gameObject.SetActive(true);
    }
}
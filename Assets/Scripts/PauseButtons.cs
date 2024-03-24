using UnityEngine;
using UnityEngine.UI;

public class PauseButtons : MonoBehaviour
{
    public Button resume, quit;
    public GameObject canv;
    // Start is called before the first frame update
    void Start()
    {
        resume.onClick.AddListener(Resume);
        quit.onClick.AddListener(Quit);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            canv.SetActive(true);
        }
    }

    void Quit()
    {
        Application.Quit();
    }

    void Resume()
    {
        canv.SetActive(false);
    }
}

using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class InGameMenu : MonoBehaviour
{
    public Button mainMenu;
    public Button options;
    public Button quitGame;
    public Button settingsApply;
    public Button settingsCancel;
    public GameObject settings;
    private bool settingsOpened = false;
    // Start is called before the first frame update
    void Start()
    {
        Button main = mainMenu.GetComponent<Button>();
		main.onClick.AddListener(MainMenu);

        Button option = options.GetComponent<Button>();
		option.onClick.AddListener(Options);

        Button quit = quitGame.GetComponent<Button>();
		quit.onClick.AddListener(QuitGame);

        Button cancel = settingsCancel.GetComponent<Button>();
		cancel.onClick.AddListener(Cancel);

        Button apply = settingsApply.GetComponent<Button>();
		apply.onClick.AddListener(Apply);

        settings.SetActive(false);
    }

    void MainMenu()
    {
        SceneManager.LoadScene("StartMenu");
        Time.timeScale = 1;
    }
    void Options()
    {
        settings.SetActive(true);
    }
    void Apply()
    {

    }
    void Cancel()
    {
        settings.SetActive(false);
    }
    void QuitGame()
    { 
        Application.Quit();  
    }
    
}

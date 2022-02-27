using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class mainMenu : MonoBehaviour
{
    public Button startGame;
    public Button options;
    public Button quitGame;
    // Start is called before the first frame update
    void Start()
    {
        Button start = startGame.GetComponent<Button>();
		start.onClick.AddListener(StartGame);

        Button option = options.GetComponent<Button>();
		option.onClick.AddListener(Options);

        Button quit = quitGame.GetComponent<Button>();
		quit.onClick.AddListener(QuitGame);
    }

    void StartGame()
    {
        SceneManager.LoadScene("Scene_A");
    }
    void Options()
    {
        
    }
    void QuitGame()
    { 
        Application.Quit();  
    }
    
}

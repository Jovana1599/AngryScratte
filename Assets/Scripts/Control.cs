using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Control : MonoBehaviour
{

    [SerializeField]
    Text message;

    public Board myboard;

    public static Control instance;

    bool hasGameFinished;

    // Ova metoda će se pozvati kada želite da napustite igru

   public void Quit()
    {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    // Ova metoda će se pozvati kada želite ponovo da pokrenete scenu
    public void Restart()
    {
        // Ponovno učitavanje trenutne scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        message.text = "Play the next turn";
        hasGameFinished = false;

        myboard = new Board();
    }

}

using UnityEngine;
using UnityEngine.SceneManagement;

public class Control : MonoBehaviour
{
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
}

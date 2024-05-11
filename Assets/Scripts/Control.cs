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

        if (message != null)
        {
            message.text = "Play the Next Turn";
        }
        else
        {
            Debug.LogError("Referenca na objekt 'message' je postavljena na null.");
        }

        hasGameFinished = false;

        myboard = new Board();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (hasGameFinished) return;

            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);

            if (!hit.collider) return;

            if (hit.collider.CompareTag("Card"))
            {

                Card card = hit.collider.gameObject.GetComponent<Card>();

                if (card.hasClicked) return;

                card.PlayTurn();

                if (card.mychoice == Choice.ZIR)
                {
                    hasGameFinished = true;
                    message.text = "You Win!";
                }
                else if (card.mychoice == Choice.SKRATZENA)
                {
                    hasGameFinished = true;
                    message.text = "You Lose...";
                }

            }
        }
    }

}

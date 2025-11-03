using UnityEngine;
using TMPro;


public class finishZone_p1 : MonoBehaviour
{
    public TMP_Text WinText; // przypisz w Inspectorze
    public float delayBeforeRestart = 3f;

    private bool hasWon = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!hasWon && collision.CompareTag("Player"))
        {
            hasWon = true;
            WinText.enabled = true; // pokaż napis
            Debug.Log("xxxx");
            

            // opcjonalnie — zatrzymaj gracza
            var rb = collision.GetComponent<Rigidbody2D>();
            if (rb != null) rb.linearVelocity = Vector2.zero;

            // opcjonalnie — restart po kilku sekundach
            Invoke(nameof(RestartGame), delayBeforeRestart);
        }
    }

    void RestartGame()
    {
        // proste ponowne załadowanie sceny
        UnityEngine.SceneManagement.SceneManager.LoadScene(
            UnityEngine.SceneManagement.SceneManager.GetActiveScene().name
        );
    }
    
}

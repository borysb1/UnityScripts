using System.Collections;
using TMPro;
using UnityEngine;

public class TypewriterEffect : MonoBehaviour
{
    [Header("UI")]
    public TextMeshProUGUI textUI;

    [Header("Dialogi")]
    [TextArea(2, 5)]
    public string[] messages;

    [Header("Ustawienia")]
    public float letterDelay = 0.05f;   // Opóźnienie między literami
    public float messageDelay = 2f;     // Ile czeka po zakończeniu tekstu

    void Start()
    {
        StartCoroutine(TypeMessages());
    }

    IEnumerator TypeMessages()
    {
        foreach (string message in messages)
        {
            // Wyczyść pole tekstowe
            textUI.text = "";

            // Wypisuj litery jedna po drugiej
            foreach (char letter in message)
            {
                textUI.text += letter;
                yield return new WaitForSeconds(letterDelay);
            }

            // Poczekaj chwilę zanim przejdziesz do następnego tekstu
            yield return new WaitForSeconds(messageDelay);
        }

        // Po zakończeniu wszystkich dialogów można wyczyścić tekst
        textUI.text = "";
    }
}

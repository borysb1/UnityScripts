using System.Collections;
using TMPro;
using UnityEngine;

public class TypewriterEffect : MonoBehaviour
{
    [Header("UI")]
    public TextMeshProUGUI textUI;

    [TextArea(3, 10)]
    public string fullText;

    [Header("Settings")]
    public float letterDelay = 0.05f; // czas miedzy literami

    void Start()
    {
        StartCoroutine(TypeText());
    }

    IEnumerator TypeText()
    {
        textUI.text = "";

        foreach (char letter in fullText)
        {
            textUI.text += letter;
            yield return new WaitForSeconds(letterDelay);
        }
    }
}

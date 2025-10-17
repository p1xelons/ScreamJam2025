using UnityEngine;
using TMPro;
using System.Collections;

public class Dialogue : MonoBehaviour
{

    [SerializeField]
    TextMeshProUGUI textComponent;
    [SerializeField] private GameObject dialogueBox;
    public string[] lines;
    public float textSpeed;
    private bool isDialougeActive;
    private bool hasBeenClicked;

    private int index;
    private Coroutine typingCoroutine;
    private static bool anyDialougueActive;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isDialougeActive = false;
        hasBeenClicked = false;
        textComponent.text = string.Empty;
        anyDialougueActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isDialougeActive && Input.GetMouseButtonDown(0))
        {
            if (textComponent.text != lines[index])
            {
                StopCoroutine(typingCoroutine);
                textComponent.text = lines[index];
            }
            else
            {
                NextLine();
            }
        }

    }

    public void TriggerDialogue()
    {
        if (isDialougeActive || anyDialougueActive) return;

        dialogueBox.SetActive(true);
        anyDialougueActive = true;
        isDialougeActive = true;
        index = 0;
        textComponent.text = string.Empty;
        typingCoroutine = StartCoroutine(TypeLine());
    }

    void StartDialogue()
    {
        isDialougeActive = true;
        index = 0;
        textComponent.text = string.Empty;
        typingCoroutine = StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if (index < lines.Length -1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            isDialougeActive = false;
            textComponent.text = string.Empty;
            anyDialougueActive = false;
            hasBeenClicked = false;
            dialogueBox.SetActive(false);
        }
    }
}

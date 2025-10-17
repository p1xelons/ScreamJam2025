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
    private static bool anyDialogueActive;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isDialougeActive = false;
        hasBeenClicked = false;
        textComponent.text = string.Empty;
        anyDialogueActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDialougeActive && !hasBeenClicked && !anyDialogueActive && Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = Camera.main.WorldToScreenPoint(transform.position).z;
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);

            Bounds bound = GetComponent<SpriteRenderer>().bounds;
            if (bound.Contains(worldPos))
            {
                hasBeenClicked = true;
                dialogueBox.SetActive(true);
                anyDialogueActive = true;
                StartDialogue();
            }
        }

        else if (isDialougeActive && Input.GetMouseButtonDown(0))
        {
            // line still typing, skip to full line
            if (textComponent.text != lines[index])
            {
                StopCoroutine(typingCoroutine);
                textComponent.text = lines[index];
            }
            // go to next line or end
            else
            {
                NextLine();
            }
        }
   
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
            anyDialogueActive = false;
            hasBeenClicked = false;
            dialogueBox.SetActive(false);
        }
    }
}

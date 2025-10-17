using UnityEngine;
using TMPro;
using System.Collections;

public class Dialogue : MonoBehaviour
{

    [SerializeField]
    TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;
    private bool isDialougeActive;
    private bool hasBeenClicked;

    private int index;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isDialougeActive = false;
        hasBeenClicked = false;
        textComponent.text = string.Empty;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDialougeActive && !hasBeenClicked && Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = Camera.main.WorldToScreenPoint(transform.position).z;
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);

            Bounds bound = GetComponent<SpriteRenderer>().bounds;
            if (bound.Contains(worldPos))
            {
                hasBeenClicked = true;
                StartDialogue();
            }
        }

        if (isDialougeActive && Input.GetMouseButtonDown(0))
        {
            if (textComponent.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }
   
    }

    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
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
            textComponent.text += string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            isDialougeActive = false;
            gameObject.SetActive(false);
        }
    }
}

using UnityEngine;

public class autoTriggerDiologue : MonoBehaviour
{
    private Dialogue dialogue;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        dialogue = GetComponent<Dialogue>();
        dialogue.TriggerDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

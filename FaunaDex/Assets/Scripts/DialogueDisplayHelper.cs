using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

// TODO: Should this class also decide whether or not the bubble is hidden or should the bubble get it's own helper class for that?
public class DialogueDisplayHelper : MonoBehaviour
{
    [Header("GameObject Links")]
    [SerializeField]
    private TextMeshProUGUI speakerField;

    [SerializeField]
    private TextMeshProUGUI textField;

    [Space(10)]
    [Header("Tweakable Section")]
    public float waitTimeInSeconds = 1.0f;  //?< Could be modified while playing by something else? => Fast-forward. 
                                            //?  But this modification should be done via an additional function call inside DialogueDisplayHelper...

    [Space(10)]
    [Header("Visualization Section")]
    [SerializeField]
    private List<DialogueEntry> DialogueEntries;
    private int currentDialogueEntriesPosition;     //< The index of the currently selected dialogue

    private DialogueEntry selectedEntry { get { return DialogueEntries[currentDialogueEntriesPosition]; } }
    private bool isCurrentlyDisplaying = false;

    //# Custom Events 
    [Space(20)]
    [Header("Events Section")]
    public UnityEvent OnTextFinishedDisplaying;     //?< The indicator for clicking to see the next text could be hooked up to this event.

    private void Start()
    {
        if (speakerField == null || textField == null)
            Debug.LogWarning($"You forgot to set mandatory variables in the DialogueDisplayHelper on {this.gameObject.name}!", this);
        Display();
    }

    public void Display()
    {
        if (currentDialogueEntriesPosition >= DialogueEntries.Count)    //< If index out of bounds
            return;
        if (isCurrentlyDisplaying)
            return;

        StartCoroutine(DisplayTextGradually());
    }

    private IEnumerator DisplayTextGradually()
    {
        isCurrentlyDisplaying = true;

        speakerField.text = DialogueEntries[currentDialogueEntriesPosition].speaker;

        string text = selectedEntry.text;
        string displayedText = "";

        foreach (char letter in text)
        {
            displayedText += letter;
            textField.text = displayedText;

            //> Wait for waitTimeInSeconds before appending the next character
            if (!string.IsNullOrWhiteSpace(letter.ToString()))      //< This way, whitespace characters do not cause additional wait time.
                yield return new WaitForSeconds(waitTimeInSeconds);
        }

        currentDialogueEntriesPosition += 1;
        isCurrentlyDisplaying = false;
        OnTextFinishedDisplaying.Invoke();
    }
}

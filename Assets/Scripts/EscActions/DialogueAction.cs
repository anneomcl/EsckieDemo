using Esckie;
using UnityEngine;

namespace Assets.Scripts.EscActions
{
    public class DialogueAction : EscAction
    {
        public static DialogueBox DialogueBox = GameObject.Find("DialogueBox").GetComponent<DialogueBox>();

        public static void Say(string actor, string content)
        {
            DialogueBox.currentDialogue.Enqueue(actor + ": " + content);
        }
    }
}

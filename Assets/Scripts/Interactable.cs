using Esckie;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace Assets.Scripts
{
    public abstract class Interactable : MonoBehaviour
    {
        private EscController Controller { get; } // should probably be somewhere else
        protected abstract string ScriptPath { get; }
        protected Dictionary<string, EscEvent> Actions { get; }

        protected GameObject player;
        protected DialogueBox dialogueBox;

        public Interactable()
        {
            this.Controller = new EscController(Assembly.GetExecutingAssembly());
            this.Actions = this.Controller.Compile(this.ScriptPath);
        }

        // Use this for initialization
        void Start()
        {
            player = GameObject.Find("Player");
            dialogueBox = GameObject.Find("DialogueBox").GetComponent<DialogueBox>();

            this.Controller.RunEvent(this.Actions, "on-start");
        }

        void Update()
        {
            if (this.IsTalk())
            {
                this.Controller.RunEvent(this.Actions, "on-talk");
            }
        }

        protected bool IsTalk()
        {
            return !dialogueBox.inDialogue && Vector3.Distance(player.transform.position, this.transform.position) < 3.0f && Input.GetKeyUp(KeyCode.E);
        }
    }
}

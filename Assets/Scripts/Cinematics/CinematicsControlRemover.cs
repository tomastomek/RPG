using RPG.Control;
using RPG.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

namespace RPG.Cinematics
{
    public class CinematicsControlRemover : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            GetComponent<PlayableDirector>().played += DisableControl;
            GetComponent<PlayableDirector>().stopped += EnableControl;
        }

        // Update is called once per frame
        void Update()
        {

        }
        void DisableControl(PlayableDirector playableDirector)
        {
            GameObject.FindWithTag("Player").GetComponent<ActionScheduler>().CancelCurrentAction();
            GameObject.FindWithTag("Player").GetComponent<PlayerController>().enabled = false;
        }

        void EnableControl(PlayableDirector playableDirector)
        {
            GameObject.FindWithTag("Player").GetComponent<PlayerController>().enabled = true;
        }
    }
}

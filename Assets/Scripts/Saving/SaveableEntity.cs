using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Saving
{
    public class SaveableEntity : MonoBehaviour
    {
        public string GetUniqueIdentifier()
        {
            
        }

        public object CaptureState()
        {
            return null;
        }

        public void RestoreState(object state)
        {
            Dictionary<string, object> stateDictionary = state as Dictionary<string, object>;
        }
    }
}

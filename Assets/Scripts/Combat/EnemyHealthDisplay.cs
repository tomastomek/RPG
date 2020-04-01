using RPG.Resources;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace RPG.Combat
{
    public class EnemyHealthDisplay : MonoBehaviour
    {
        Fighter fighter;

        private void Awake()
        {
            fighter = GameObject.FindWithTag("Player").GetComponent<Fighter>();

        }

        void Update()
        {
            if (fighter.GetTaraget() != null)
            {
                Health health = fighter.GetTaraget();
                GetComponent<Text>().text = String.Format("{0:0}%", health.GetPercentage());
            }
            else
            {
                GetComponent<Text>().text = "N/A";
            }
        }
    }
}

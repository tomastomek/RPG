﻿using System;
using UnityEngine;
using UnityEngine.UI;

namespace RPG.Resources
{
    public class ExperienceDisplay : MonoBehaviour
    {
        Experience experience;

        private void Awake()
        {
            experience = GameObject.FindWithTag("Player").GetComponent<Experience>();

        }

        void Update()
        {
            GetComponent<Text>().text = experience.GetPoints();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RPG.Stats
{
    public class LevelDisplay : MonoBehaviour
    {
        BaseStats baseStats;

        void Awake()
        {
            baseStats = GameObject.FindGameObjectWithTag("Player").GetComponent<BaseStats>();
        }

        // Update is called once per frame
        void Update()
        {
            GetComponent<Text>().text = baseStats.GetLevel().ToString();
        }
    }
}

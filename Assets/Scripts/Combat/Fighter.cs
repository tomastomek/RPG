using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Movement;

namespace RPG.Combat
{
    public class Fighter : MonoBehaviour
    {
        [SerializeField] float weaponRange = 2f;

        Transform target;
        Mover mover;

        private void Start()
        {
            mover = GetComponent<Mover>();
        }
        private void Update()
        {
            if (target)
            {
                mover.MoveTo(target.position);
                if (Vector3.Distance(transform.position, target.position) <= weaponRange)
                {
                    mover.StopNav();
                }
            }
        }

        public void Attack(CombatTarget combatTarget)
        {
            target = combatTarget.transform;
        }
    }
}
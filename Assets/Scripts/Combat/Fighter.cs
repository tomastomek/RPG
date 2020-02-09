using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Movement;
using RPG.Core;

namespace RPG.Combat
{
    public class Fighter : MonoBehaviour, IAction
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
                    mover.Cancel();
                    AttackBehaviour();
                }
            }
        }

        private void AttackBehaviour()
        {
            GetComponent<Animator>().SetTrigger("attack");
        }

        public void Attack(CombatTarget combatTarget)
        {
            GetComponent<ActionScheduler>().StartAction(this);
            target = combatTarget.transform;
        }

        public void Cancel()
        {
            target = null;
        }

        // Animation event
        private void Hit()
        {
            
        }
    }
}
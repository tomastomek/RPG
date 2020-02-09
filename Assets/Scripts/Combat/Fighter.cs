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
        [SerializeField] float timeBetweenAttacks = 1f;
        [SerializeField] float weaponDamage = 5f;

        Transform target;
        Mover mover;
        float timeSinceLastAttack = 0;

        private void Start()
        {
            mover = GetComponent<Mover>();
        }
        private void Update()
        {
            timeSinceLastAttack += Time.deltaTime;

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
            if (timeSinceLastAttack >= timeBetweenAttacks)
            {
                GetComponent<Animator>().SetTrigger("attack");
                timeSinceLastAttack = 0;
            }
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
            Health heathComponent = target.GetComponent<Health>();
            heathComponent.TakeDamage(weaponDamage);
        }
    }
}
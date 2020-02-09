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

        Health target;
        Mover mover;
        float timeSinceLastAttack = 0;
        Animator animator;

        private void Start()
        {
            mover = GetComponent<Mover>();
            animator = GetComponent<Animator>();
        }
        private void Update()
        {
            timeSinceLastAttack += Time.deltaTime;
            if (target.IsDead()) return;

            if (target)
            {
                mover.MoveTo(target.transform.position);
                if (Vector3.Distance(transform.position, target.transform.position) <= weaponRange)
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
                animator.SetTrigger("attack");
                timeSinceLastAttack = 0;
            }
        }

        public void Attack(CombatTarget combatTarget)
        {
            GetComponent<ActionScheduler>().StartAction(this);
            target = combatTarget.GetComponent<Health>();
        }

        public void Cancel()
        {
            animator.SetTrigger("stopAttack");
            target = null;
        }

        // Animation event
        private void Hit()
        {
            target.TakeDamage(weaponDamage);
        }
    }
}
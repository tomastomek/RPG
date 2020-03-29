using UnityEngine;
using RPG.Movement;
using RPG.Core;

namespace RPG.Combat
{
    public class Fighter : MonoBehaviour, IAction
    {
        [SerializeField] float timeBetweenAttacks = 1f;
        [SerializeField] Transform handTransform = null;
        [SerializeField] Weapon defaultWeapon = null;

        Health target;
        Mover mover;
        float timeSinceLastAttack = Mathf.Infinity;
        Weapon currentWeapon = null;
        Animator animator;

        private void Start()
        {
            mover = GetComponent<Mover>();
            animator = GetComponent<Animator>();
            EquipWeapon(defaultWeapon);
        }
        private void Update()
        {
            timeSinceLastAttack += Time.deltaTime;

            if (target)
            {
                if (target.IsDead()) return;
                mover.MoveTo(target.transform.position, 1f);
                if (Vector3.Distance(transform.position, target.transform.position) <= currentWeapon.GetWeaponRange())
                {
                    mover.Cancel();
                    AttackBehaviour();
                }
            }
        }

        private void AttackBehaviour()
        {
            transform.LookAt(target.transform);
            if (timeSinceLastAttack >= timeBetweenAttacks)
            {
                TriggerAttack();
                timeSinceLastAttack = 0;
            }
        }

        private void TriggerAttack()
        {
            animator.ResetTrigger("stopAttack");
            animator.SetTrigger("attack");
        }

        public void Attack(GameObject combatTarget)
        {
            GetComponent<ActionScheduler>().StartAction(this);
            target = combatTarget.GetComponent<Health>();
        }

        public void Cancel()
        {
            StopAttack();
            target = null;
            mover.Cancel();
        }

        private void StopAttack()
        {
            animator.ResetTrigger("attack");
            animator.SetTrigger("stopAttack");
        }

        // Animation event
        private void Hit()
        {
            if (target == null) return;
            target.TakeDamage(currentWeapon.GeWeaponDamage());
        }

        public bool CanAttack(GameObject combatTarget)
        {
            if (combatTarget == null) { return false; }
            Health targetToTest = combatTarget.GetComponent<Health>();
            return (targetToTest != null && !targetToTest.IsDead());
        }

        public void EquipWeapon(Weapon weapon)
        {
            currentWeapon = weapon;
            Animator animator = GetComponent<Animator>();
            weapon.Spawn(handTransform, animator);
        }
    }
}
using UnityEngine;

public class Weapon_Melee : Weapon
{
    [System.Serializable]
    public enum WeaponState
    {
        Charging,
        Attacking,
        CoolingDown,
        Idle
    }

    [System.Serializable]
    public class MeleeConfig
    {
        [SerializeField] private float chargeTime = 1f;
        public float ChargeTime { get { return chargeTime; } }

        [SerializeField] private float coolDownTime = 1f;
        public float CoolDownTime { get { return coolDownTime; } }
    }

    [SerializeField] protected MeleeConfig meleeConfig;

    [SerializeField] BoxCollider weaponCollider;

    protected WeaponState weaponState;

    protected override void Start()
    {
        base.Start();
        weaponState = WeaponState.Idle;

        gameObject.SetActive(false);
    }

    public override void Attack()
    {
        base.Attack();

        if(CanAttack())
        {
            Debug.Log("Weapon_Melee.Attack()");

            PlayerAnimator.SetTrigger("Attack");
            weaponState = WeaponState.Charging;
        }
    }

    /* Animation Events */
    #region AnimationEvents

    public override void OnAnimationEvent(string eventName)
    {
        switch (eventName)
        {
            case "attack_start":
                Debug.Log("attack_start");
                weaponState = WeaponState.Attacking;
                break;

            case "draw_weapon":
                gameObject.SetActive(true);
                break;

            case "sheathe_weapon":
                gameObject.SetActive(false);
                break;

            case "cooling_down":
                Debug.Log("cooling_down");
                weaponState = WeaponState.CoolingDown;
                break;

            case "attack_end":
                Debug.Log("attack_end");
                Invoke("ResetWeaponState", meleeConfig.CoolDownTime);
                break;
        }
    }

    public void ResetWeaponState()
    {
        weaponState = WeaponState.Idle;
    }

    #endregion

    /* Weapon Control */
    #region WeaponControl

    public virtual bool CanAttack()
    {
        bool bPlayerCheck = !GameManager.Instance.PlayerHealth.PlayerDied;
        bool bStateCheck = weaponState == WeaponState.Idle;

        return bPlayerCheck && bStateCheck;
    }

    public override bool IsAttacking()
    {
        return weaponState != WeaponState.Idle;
    }

    #endregion
}

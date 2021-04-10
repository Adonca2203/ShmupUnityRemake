using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : Singleton<PlayerStats>
{

    private PlayerShoot _ps;
    public PlayerShoot ps { get { return _ps; } private set { _ps = value; } }

    private int _maxHealth = 3;
    public int maxHealth { get { return _maxHealth;} private set { _maxHealth = value; } }
    private int _currentHealth;
    public int currentHealth { get { return _currentHealth; } private set { _currentHealth = value; } }

    private int _maxAmmo = 5;

    public int maxAmmo { get { return _maxAmmo; } private set { _maxAmmo = value; } }
    private int _currentAmmo;
    public int currentAmmo { get { return _currentAmmo; } private set { _currentAmmo = value; } }

    private int _maxFuel = 4;

    public int maxFuel { get { return _maxFuel; } private set { _maxFuel = value; } }

    public enum PlayerState
    {

        normal,
        dash,
        hurt

    }

    private PlayerState _playerCurrentState = PlayerState.normal;
    public PlayerState PlayerCurrentState { get { return _playerCurrentState; } private set { _playerCurrentState = value; } }

    public bool canDash = true;
    public Events.AmmoChange onAmmoChange;
    public Events.HealthChange onHealthChange;
    public Events.Overheal onOverheal;

    protected override void Awake()
    {
        base.Awake();
        ps = FindObjectOfType<PlayerMovement>().gameObject.GetComponent<PlayerShoot>();
        //LoadStats();

        maxAmmo = 5;
        currentAmmo = maxAmmo;
        maxHealth = 3;
        currentHealth = maxHealth;
        maxFuel = 4;

    }

    private void Start()
    {

        ps.onPlayerShoot.AddListener(DecreaseAmmoCount);
        DontDestroyOnLoad(this.gameObject);

    }

    private void DecreaseAmmoCount()
    {

        if(currentAmmo > 0)
        {
            currentAmmo -= 1;
            ps.instantiated.GetComponent<ProjectileMovement>().onProjectileDestroyed.AddListener(ReloadBullet);
            onAmmoChange?.Invoke();
        }

    }

    private void ReloadBullet()
    {

        if(currentAmmo < maxAmmo)
        {
            currentAmmo++;
            onAmmoChange?.Invoke();
        }

    }


    public void IncreaseAmmo(int quantity)
    {

        if (maxAmmo < 20)
        {

            maxAmmo += quantity;
            currentAmmo = maxAmmo;
            onAmmoChange?.Invoke();
        
        }

    }

    public void HealPlayer(int amnt)
    {

        if(currentHealth >= maxHealth && amnt > 0)
        {
            currentHealth = maxHealth;
            onOverheal?.Invoke();
            return;
        }

        currentHealth += amnt;
        onHealthChange?.Invoke();
    }

    public void ChangeState(PlayerState newState)
    {

        _playerCurrentState = newState;

    }

    private void SaveStats()
    {

        string jsonData = JsonUtility.ToJson(this, true);
        PlayerPrefs.SetString("Player Stats", jsonData);
        PlayerPrefs.Save();

    }

    public void LoadStats()
    {

        if(!PlayerPrefs.HasKey("Player Stats"))
        { 

            maxAmmo = 5;
            maxHealth = 3;
            maxFuel = 4;
            string jsonData = JsonUtility.ToJson(this, true);
            PlayerPrefs.SetString("Player Stats", jsonData);
            PlayerPrefs.Save();

        }

        else
        {
            
            JsonUtility.FromJsonOverwrite(PlayerPrefs.GetString("Player Stats"), this);

        }

    }

    protected override void OnDestroy()
    {
        base.OnDestroy();
        SaveStats();
    }

}

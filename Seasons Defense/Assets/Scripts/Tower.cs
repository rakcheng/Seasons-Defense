using System;
using UnityEngine;
using TMPro;

public class Tower : MonoBehaviour
{
    public TextMeshProUGUI ammoText;
    
    public GameObject missilePrefab;
    public GameObject firePositionGameObject;

    [Header("Cannon Tower")] 
    public bool rotateAsCannon = false;
    public GameObject rotatePositionGameObject;
    
    public Animator cannonAnimator;
    public GameObject cannonDeathParticles;

    public GameSO gameSo;
    
    private int _missileCount = 10;
    private Vector3 _targetPosition;
    private bool _targeting;
    private bool _disabled;

    private void Start()
    {
        _missileCount = gameSo.towerAmmo;
        _disabled = false;
        _targeting = false;
        UpdateAmmoCount();
    }

    private void Update()
    {
        if (!rotateAsCannon) return;
        LookAtTarget();
    }

    public void Fire(Vector3 targetPoint) {

        // a tower will only fire if their missile count is greater than 0
        if (_missileCount == 0) return;
        
        _targetPosition = targetPoint;
        _targeting = true;

        _missileCount--;
        Missile missile = Instantiate(missilePrefab, firePositionGameObject.transform.position, Quaternion.identity).GetComponent<Missile>();
        
        AudioManager.Instance.Play("PlayerMissileSound");
        
        // Give the missile the attributes it needs to move towards its target position

        if (missile != null)
        {
            missile.target = targetPoint;
        }
        
        UpdateAmmoCount();
    }


    // Methods to set or get the missile count
    public int GetMissileCount()
    {
        return _missileCount;
    }

    public void ReloadTower(int amount)
    {
        _missileCount += amount;
    }

    public void DisableTurret()
    {
        if (_disabled) return;

        GetComponent<Collider>().enabled = false;
        _disabled = true;
        _targeting = false;
        _missileCount = 0;

        cannonAnimator.enabled = true;
        GameObject effect = Instantiate(cannonDeathParticles, firePositionGameObject.transform.position, Quaternion.identity);
        Destroy(effect, 2f);
        
        LevelManager.Instance.towersCount--;
        LevelManager.Instance.BuildingDestroyed();
        
        
        UpdateAmmoCount();
    }

    public void EnableTower()
    {
        // TODO: enables tower for the next wave.
    }

    
    private void UpdateAmmoCount()
    {
        ammoText.SetText($"{_missileCount}");
    }

    private void LookAtTarget()
    {
        if (!_targeting)
            return;
        
        // rotatePositionGameObject.transform.LookAt(_targetPosition);
        Vector3 dir = _targetPosition - rotatePositionGameObject.transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir, rotatePositionGameObject.transform.up);
        Vector3 rotation = Quaternion.Lerp(rotatePositionGameObject.transform.rotation, lookRotation, Time.deltaTime * 10f).eulerAngles;
        rotatePositionGameObject.transform.rotation = rotatePositionGameObject.transform.position.x > _targetPosition.x ? 
            Quaternion.Euler(180 - rotation.x, 90f , 0f) : 
            Quaternion.Euler(rotation.x, 90f , 0f);
    }
}

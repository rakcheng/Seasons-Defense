using UnityEngine;
using TMPro;

public class Tower : MonoBehaviour
{
    public TextMeshProUGUI ammoText;
    
    public GameObject missilePrefab;
    public float offset;
    
    private int _missileCount = 5;
    private Vector3 _offsetFirePosition;

    private bool _disabled;
    
    private void Start()
    {
        _disabled = false;
        _offsetFirePosition = new Vector3(transform.position.x, transform.position.y + offset, 0);
        UpdateAmmoCount();
    }

    public void Fire(Vector3 targetPoint) {

        // a tower will only fire if their missile count is greater than 0
        if (_missileCount == 0) return;

        _missileCount--;
        Missile missile = Instantiate(missilePrefab, _offsetFirePosition, Quaternion.identity).GetComponent<Missile>();
        
        AudioManager.Instance.Play("MissileSound");
        
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
        _missileCount = 0;

        
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
        ammoText.SetText("Ammo: " + _missileCount);
    }
}

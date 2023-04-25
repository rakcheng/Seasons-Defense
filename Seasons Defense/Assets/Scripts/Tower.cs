using UnityEngine;
using TMPro;

public class Tower : MonoBehaviour
{
    public TextMeshProUGUI ammoText;
    
    public GameObject missilePrefab;
    public float offset;
    
    private int _missileCount = 5;
    private Vector3 _towerPosition;

    private bool _disabled;
    
    private void Start()
    {
        _disabled = false;
        _towerPosition = new Vector3(transform.position.x, transform.position.y + offset, 0);
        UpdateAmmoCount();
    }

    public void Fire() {

        // a tower will only fire if their missile count is greater than 0
        if (_missileCount == 0) return;

        _missileCount--;

        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z);
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        worldPosition.z = transform.position.z;
        GameObject missileInstance = Instantiate(missilePrefab, _towerPosition, Quaternion.identity);
      
        // Give the missile the attributes it needs to move towards its target position
        Missile missile = missileInstance.GetComponent<Missile>();

        if (missile != null)
        {
            missile.target = worldPosition;
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

        _disabled = true;
        
        _missileCount = 0;
        
        LevelManager.Instance.towersCount--;
        LevelManager.Instance.BuildingDestroyed();
        
        UpdateAmmoCount();
    }
    
    private void UpdateAmmoCount()
    {
        ammoText.SetText("Ammo: " + _missileCount);
    }
}

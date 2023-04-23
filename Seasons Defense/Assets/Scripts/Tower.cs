using UnityEngine;
using TMPro;

public class Tower : MonoBehaviour
{
    public TextMeshProUGUI ammoText;
    
    public GameObject missilePrefab;
    public float offset;
    
    private int missileCount = 5;
    private Vector3 _towerPosition;

    public bool _disabled;
    
    private void Start()
    {
        _disabled = false;
        _towerPosition = new Vector3(transform.position.x, transform.position.y + offset, 0);
        UpdateAmmoCount();
    }

    public void Fire() {

        // a tower will only fire if their missile count is greater than 0
        if (missileCount == 0) return;

        missileCount--;

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
    public int getMissileCount()
    {
        return this.missileCount;
    }

    public void ReloadTower(int amount)
    {
        this.missileCount += amount;
    }

    public void disableTurret()
    {
        if (_disabled) return;

        _disabled = true;
        
        this.missileCount = 0;
        
        LevelManager.TowersCount--;
        LevelManager.BuildingDestroyed();
        
        UpdateAmmoCount();
    }
    
    private void UpdateAmmoCount()
    {
        ammoText.SetText("Ammo: " + missileCount);
    }
}

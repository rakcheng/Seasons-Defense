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

    public void Fire() {

        // a tower will only fire if their missile count is greater than 0
        if (_missileCount == 0) return;

        int layerMask = LayerMask.GetMask("TargetPlane");

        Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);

        if (!Physics.Raycast(ray, out RaycastHit hit, 100, layerMask)) return;

        _missileCount--;
        Missile missile = Instantiate(missilePrefab, _offsetFirePosition, Quaternion.identity).GetComponent<Missile>();
        
        // Give the missile the attributes it needs to move towards its target position
        if (missile != null)
        {
            missile.target = hit.point;
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

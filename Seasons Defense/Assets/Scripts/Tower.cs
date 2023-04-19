using UnityEngine;

public class Tower : MonoBehaviour
{
    public GameObject missilePrefab;
    public float offset;
    private Vector3 _towerPosition;

    private void Start()
    {
        _towerPosition = new Vector3(transform.position.x, transform.position.y + offset, 0);
    }

    public void Fire() {

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
    }
}

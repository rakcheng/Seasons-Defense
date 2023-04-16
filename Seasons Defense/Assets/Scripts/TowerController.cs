using UnityEngine;

public class TowerController : MonoBehaviour
{
    public GameObject missilePrefab;
    public float offset;

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane);
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            worldPosition.z = transform.position.z;
            GameObject missileInstance = Instantiate(missilePrefab, new Vector3(transform.position.x, transform.position.y + offset, 0), Quaternion.identity);

            // Give the missile the attributes it needs to move towarsd its target position
            Missile missile = missileInstance.GetComponent<Missile>();

            if (missile != null)
            {
                missile.speed = 5;
                missile.target = worldPosition;
            }
        }
    }
}
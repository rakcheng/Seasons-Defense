using UnityEngine;

public class TowerDecider : MonoBehaviour
{
    public GameObject leftTurret;
    public GameObject middleTurret;
    public GameObject rightTurret;

    private float THIRD = Screen.width / 3f;

    private void Update()
    {
        
        if(Input.GetMouseButtonDown(0))
        {
            float xPosOnClick = Input.mousePosition.x;

            //TODO: Add more logic to this algorithm to decide the next best turret to use,
            //      if the current one has no missiles left

            if (xPosOnClick < THIRD) TowerToShoot(leftTurret);
            else if (xPosOnClick > THIRD && xPosOnClick < (THIRD * 2f)) TowerToShoot(middleTurret);
            else TowerToShoot(rightTurret);
        }
    }

    private void TowerToShoot(GameObject turret)
    {
        TowerController turretController = turret.GetComponent<TowerController>();
        turretController.Fire();
    }
}

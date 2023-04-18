using UnityEngine;

public class TowerDecider : MonoBehaviour
{
    public Tower leftTower;
    public Tower middleTower;
    public Tower rightTower;

    private float _third = Screen.width / 3f;

    private void Update()
    {
        
        if(Input.GetMouseButtonDown(0))
        {
            float xPosOnClick = Input.mousePosition.x;

            //TODO: Add more logic to this algorithm to decide the next best turret to use,
            //      if the current one has no missiles left

            if (xPosOnClick < _third) TowerToShoot(leftTower);
            else if (xPosOnClick > _third && xPosOnClick < (_third * 2f)) TowerToShoot(middleTower);
            else TowerToShoot(rightTower);
        }
    }

    private void TowerToShoot(Tower tower)
    {
        tower.Fire();
    }
}

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

            if (xPosOnClick < _third) TowerToShoot(leftTower, middleTower, rightTower);
            else if (xPosOnClick > _third && xPosOnClick < (_third * 2f)) TowerToShoot(middleTower, leftTower, rightTower);
            else TowerToShoot(rightTower, middleTower, leftTower);
        }
    }

    public void TowerToShoot(Tower optimal, Tower secondChoice, Tower lastChoice)
    {
        // This can be more complex, but for the time being it works.

        if(optimal.getMissileCount() > 0)
        {
            optimal.Fire();
        }
        else if(secondChoice.getMissileCount() > 0)
        {
            secondChoice.Fire();
        }
        else if(lastChoice.getMissileCount() > 0)
        {
            lastChoice.Fire();
        }
    }

}

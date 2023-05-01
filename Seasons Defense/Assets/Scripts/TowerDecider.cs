using System;
using UnityEngine;

public class TowerDecider : MonoBehaviour
{
    public Tower leftTower;
    public Tower middleTower;
    public Tower rightTower;
    
    [Header("Targeting")]
    public GameObject plane;

    public float targetingBias = -0.5f;

    private float _forthX;

    private void Start()
    {
        _forthX = plane.GetComponent<Renderer>().bounds.size.x / 4.0f + targetingBias;
        // Debug.Log(_forthX);
    }

    private void Update()
    {

        if (LevelManager.Instance.gameOver)
            return;

        if (Input.GetMouseButtonDown(0))
        {
            int layerMask = LayerMask.GetMask("TargetPlane");
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            
            if (!Physics.Raycast(ray, out RaycastHit hit, 100, layerMask)) return;
            
            float planeHitX = hit.point.x;
            // Debug.Log($"Firing... X={planeHitX}");

            if (planeHitX <= -_forthX)
                TowerToShoot(leftTower, middleTower, rightTower, hit.point);
            
            else if (planeHitX >= -_forthX && planeHitX < _forthX)
                TowerToShoot(middleTower, leftTower, rightTower, hit.point);
            
            else 
                TowerToShoot(rightTower, middleTower, leftTower, hit.point);

            
        }

    }

    private void TowerToShoot(Tower optimal, Tower secondChoice, Tower lastChoice, Vector3 targetPoint)
    {
        // This can be more complex, but for the time being it works.

        if(optimal.GetMissileCount() > 0)
        {
            optimal.Fire(targetPoint);
        }
        else if(secondChoice.GetMissileCount() > 0)
        {
            secondChoice.Fire(targetPoint);
        }
        else if(lastChoice.GetMissileCount() > 0)
        {
            lastChoice.Fire(targetPoint);
        }
    }

    public int GetTotalAmmo()
    {
        return rightTower.GetMissileCount() + middleTower.GetMissileCount() + leftTower.GetMissileCount();
    }

}

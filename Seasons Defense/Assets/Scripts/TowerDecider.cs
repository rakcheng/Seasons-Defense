using System;
using UnityEngine;

public class TowerDecider : MonoBehaviour
{
    public Tower leftTower;
    public Tower middleTower;
    public Tower rightTower;

    public GameObject plane;

    private float _sixthX;

    private void Start()
    {
        _sixthX = plane.GetComponent<Renderer>().bounds.extents.x / 6.0f * plane.transform.localScale.x;
        Debug.Log(_sixthX);
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
            Debug.Log($"Firing... X={planeHitX}");

            if (planeHitX <= -_sixthX)
                TowerToShoot(leftTower, middleTower, rightTower, hit.point);
            
            else if (planeHitX >= -_sixthX && planeHitX < _sixthX)
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

}

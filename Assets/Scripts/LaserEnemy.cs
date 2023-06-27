using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserEnemy : MonoBehaviour
{
    [SerializeField] private Transform laserStart;
    [SerializeField] private Transform laserEnd;
    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] private float timeActivated = 1f;

    private Collider laserCollider;

    private void Start()
    {
        lineRenderer.positionCount = 2;
        laserCollider = GetComponent<Collider>();

    }
    
    private IEnumerator LaserAnimation()
    {
        while(true)
        {
            yield return new WaitForSeconds(timeActivated);
            laserCollider.enabled = !laserCollider.enabled;
            lineRenderer.enabled = !lineRenderer.enabled;
            if(lineRenderer.enabled)
            {
                var points = new Vector3[] {
                   laserStart.position,
                   laserEnd.position
                };
                lineRenderer.SetPositions(points);
            }
        }
    }
}

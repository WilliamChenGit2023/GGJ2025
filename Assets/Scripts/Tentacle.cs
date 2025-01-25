using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tentacle : MonoBehaviour
{
    [SerializeField] private int length;
    [SerializeField] private LineRenderer lineRend;
    [SerializeField] private Vector3[] segmentPoses;
    [SerializeField] private Vector3[] segmentV;

    [SerializeField] Transform targetDir;
    [SerializeField] private float targetDist;
    [SerializeField] private float smoothSpeed;
    [SerializeField] private float trailSpeed;

    [SerializeField] private float wiggleSpeed;
    [SerializeField] private float wiggleMag;
    [SerializeField] Transform wiggleDir;

    private void Start()
    {
        lineRend.positionCount = length;
        segmentPoses = new Vector3[length];
        segmentV = new Vector3[length];
    }

    // Update is called once per frame
    void Update()
    {
        wiggleDir.localRotation = Quaternion.Euler(0f, 0f, Mathf.Sin(Time.time * wiggleSpeed) * wiggleMag);

        segmentPoses[0] = targetDir.position;

        for (int i = 1; i < segmentPoses.Length; i++)
        {
            segmentPoses[i] = Vector3.SmoothDamp(segmentPoses[i], segmentPoses[i - 1] + targetDir.right * targetDist, ref segmentV[i], smoothSpeed + i/trailSpeed);
        }
        lineRend.SetPositions(segmentPoses);
    }
}

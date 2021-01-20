using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLine : MonoBehaviour
{
    private Queue<Vector3> queue;
    private Vector3[] positions;

    private Camera cachedCamera;

    const int capacity = 100;

    [SerializeField]
    private LineRenderer line = null;

    void Awake()
    {
        positions = new Vector3[capacity];
        queue = new Queue<Vector3>();
        cachedCamera = Camera.main;
    }

    public void AddPosition(Vector2 pos)
    {
        var targetPos = cachedCamera.ScreenToWorldPoint(new Vector3(pos.x, pos.y, 10));
        queue.Enqueue(targetPos);
        if (queue.Count > capacity)
            queue.Dequeue();

        if (queue.Count != 0)
            Draw();
    }

    void Draw()
    {
        queue.CopyTo(positions, 0);
        line.positionCount = queue.Count;
        line.SetPositions(positions);
    }
}
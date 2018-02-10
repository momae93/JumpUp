using UnityEngine;

public class Platform {
    private GameObject instance;
    private int size;
   
    public int Size
    {
        get { return size; }
        set { size = value; }
    }

    private Vector3 position;

    public Vector3 Position
    {
        get { return position; }
        set
        {
            position = value;
            instance.transform.position = value;
        }
    }

    public Platform(GameObject model, int size)
    {
        Size = size;
        instance = Object.Instantiate(model);
    }

    public void SetMovingBehavior(float x, int level)
    {
        const float basicSpeed = 2;
        float speed = level / 5 + basicSpeed;
        instance.AddComponent<GameObjectMove>();
        instance.GetComponent<GameObjectMove>().leftLimit = -x;
        instance.GetComponent<GameObjectMove>().rightLimit = x;
        instance.GetComponent<GameObjectMove>().speed = speed;
    }
    public void SetFallingBehavior()
    {
        instance.AddComponent<FallingPlatform>();
        instance.GetComponent<FallingPlatform>().rg = instance.GetComponent<Rigidbody>();
    }
}

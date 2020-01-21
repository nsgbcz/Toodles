using UnityEngine;

public class Destroyed : MonoBehaviour, IAction//SimpleDestroyed
{
    public UnityEngine.Object[] preys;

    public Framework.Type targetFramework;
    int fCount = 0;

    public void Action()
    {
        if (preys.Length == 0) Destroy(gameObject);
        else foreach (var item in preys) if (item != null) Destroy(item);
    }

    public void OnTriggerEnter2D(Collider2D coll)
    {
        if (targetFramework == Framework.Type.Nothing) fCount++;
        else
        {
            var framework = coll.GetComponent<Framework>();
            if (framework != null && framework.type == targetFramework)
            {
                fCount++;
            }
        }
    }
    public void OnTriggerExit2D(Collider2D coll)
    {
        if (targetFramework == Framework.Type.Nothing)
        {
            fCount--;
            TryDestroy();
        }
        else
        {
            var framework = coll.GetComponent<Framework>();
            if (framework != null && framework.type == targetFramework)
            {
                fCount--;
                TryDestroy();
            }
        }
    }

    public void TryDestroy()
    {
        if (fCount <= 0) Action();
    }
}

using UnityEngine;
using System.Collections.Generic;

public class Helper
{

    /// <summary>
    /// Returns closest MonoBehaviour in a list of MonoBehaviours, given a centre
    /// </summary>
    /// <typeparam name="T">Type of monobehaviour</typeparam>
    /// <param name="objects">Array of objects</param>
    /// <param name="centre">Centre vector</param>
    /// <returns>The closest object to the centre</returns>
    public static MonoBehaviour GetClosestGameObject<T>(List<T> objects, Vector2 centre) where T : MonoBehaviour
    {
        if(objects.Count == 0) return null;
        if (objects.Count == 1) return objects[0];

        T closest = objects[0];
        float distance = Vector2.Distance(closest.gameObject.transform.position, centre);

        foreach (T obj in objects)
        {
            float objDistance = Vector2.Distance(obj.gameObject.transform.position, centre);
            if (objDistance < distance)
            {
                closest = obj;
                distance = objDistance;
            }
        }
        return closest;
    }
}

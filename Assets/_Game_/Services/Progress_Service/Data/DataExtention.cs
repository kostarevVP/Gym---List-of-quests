using UnityEngine;

public static class DataExtention
{
    public static T ToDeserialized<T>(this string json) =>
           JsonUtility.FromJson<T>(json);

    public static string ToJson(this object obj) => JsonUtility.ToJson(obj);
}

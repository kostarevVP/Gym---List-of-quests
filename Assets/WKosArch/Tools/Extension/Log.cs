using UnityEngine;

namespace WKosArch.Extentions
{
    public static class Log
    {
        public static void Print(string text) =>
            Debug.Log(text);

        public static void Print(string text, GameObject gameObject) =>
            Debug.Log(text, gameObject);

        public static void Print(string text, object obj) =>
            Debug.Log(text + "log from = " + obj.ToString());

        public static void PrintColor(string text, Color color) =>
            Debug.Log("<color=#" + ColorUtility.ToHtmlStringRGBA(color) + $">{text}" + "</color>");

        public static void PrintYellow(string text) =>
            PrintColor(text, Color.yellow);

        public static void PrintRed(string text) =>
             PrintColor(text, Color.red);

        public static void PrintCyan(string text) =>
            PrintColor(text, Color.cyan);

        public static void PrintWarning(string text) =>
            Debug.LogWarning(text);

        public static void PrintWarning(string text, GameObject gameObject) =>
            Debug.LogWarning(text, gameObject);

        public static void PrintWarning(string text, object obj) =>
            Debug.Log(text + "log from = " + obj.ToString());

        public static void PrintError(string text) =>
            Debug.LogError(text);
        public static void PrintError(string text, object obj) =>
           Debug.LogError(text + "log from = " + obj.ToString());

        public static void PrintError(string text, GameObject gameObject) =>
            Debug.LogError(text, gameObject);

        public static void CheckForNull<T>(T o, string errorMessage)
        {
            if (o == null)
            {
                Debug.Log(errorMessage);
            }
        }

        public static void DrawRay(Vector3 position, Vector3 vector3, Color color) =>
            Debug.DrawRay(position, vector3, color);
        
        public static void DrawLineYellow(Vector3 startPoint, Vector3 endPoint) =>
            Debug.DrawLine(startPoint, endPoint, Color.yellow);
        public static void DrawLineGreen(Vector3 startPoint, Vector3 endPoint) =>
           Debug.DrawLine(startPoint, endPoint, Color.green);
        public static void DrawLineRed(Vector3 startPoint, Vector3 endPoint) =>
           Debug.DrawLine(startPoint, endPoint, Color.red);
        public static void DrawLine(Vector3 startPoint, Vector3 endPoint) =>
           Debug.DrawLine(startPoint, endPoint);
    }
}

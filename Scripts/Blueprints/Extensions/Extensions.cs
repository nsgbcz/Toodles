using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

namespace BP
{
    public static class Extensions
    {
        static string[] _layers = null;
        public static string[] Layers
        {
            get
            {
                if (_layers == null)
                {
                    List<string> layerNames = new List<string>();
                    for (int i = 0; i <= 31; i++) layerNames.Add(LayerMask.LayerToName(i));

                    _layers = layerNames.ToArray();
                }
                return _layers;
            }
        }

        public static bool[] ToBool(this float[] array)
        {
            bool[] temp = new bool[array.Length];

            for (int i = 0; i < array.Length; i++) temp[i] = array[i] <= 0;
            return temp;
        }

        public static bool Include(this bool[] array, bool[] array1)
        {
            if (array1.Length > array.Length) return false;
            for (int i = 0; i < array.Length; i++) if (array1[i] == true && array[i] == false) return false;
            return true;
        }

        public static void RemoveAt<T>(this T[] array, int index, ref T[] arr)
        {
            //if (index < 0) throw new Exception("Start index cannot be negative");

            //Array.Copy(array, index + 1, array, index, array.Length - index - 1);
            //Array.Resize(ref array, array.Length - 1);
            //return array;
            arr = new T[array.Length - 1];
            Array.Copy(array, arr, index);
            Array.Copy(array, index + 1, arr, index, array.Length - index - 1);
        }

        public static T[] NullClear<T>(this T[] array)
        {
            int newlength = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] != null)
                {
                    array[newlength++] = array[i];
                }
            }
            Array.Resize(ref array, newlength);
            return array;
        }
        public static void NullClear<T>(this List<T> list)
        {
            for (int i = 0; i < list.Count;)
            {
                if (list[i] == null) list.RemoveAt(i);
                else i++;
            }
        }

        public static T[] Insert<T>(this T[] array, int index, T obj)
        {
            var nArray = new T[array.Length + 1];
            if (index > 0)
                Array.Copy(array, 0, nArray, 0, index);
            nArray[index] = obj;
            if (index < array.Length - 1)
                Array.Copy(array, index, nArray, index + 1, array.Length - index);
            return nArray;
        }

        public static T[] Insert<T>(this T[] array, int index)
        {
            var nArray = new T[array.Length + 1];
            if (index > 0)
                Array.Copy(array, 0, nArray, 0, index);
            if (index < array.Length - 1)
                Array.Copy(array, index, nArray, index + 1, array.Length - index);
            return nArray;
        }

        public static T[] Cut<T>(this T[] array, int index, int count)
        {
            //if (index < 0 || count < 0) throw new Exception("Start index cannot be negative");
            var nArray = new T[count];
            var tCount = index + count;

            if (array.Length < tCount) tCount = array.Length;
            for (int j = index, i = 0; j < tCount; j++, i++) nArray[i] = array[j];
            return nArray;
        }
        public static T[] Cut<T>(this T[] array, int count)
        {
            //if (count < 0) throw new Exception("Start index cannot be negative");
            Array.Resize(ref array, array.Length - count);
            return array;
        }

        public static T[] Select<T>(this T[] array, int length)
        {
            if (length < array.Length) Array.Resize(ref array, array.Length - length);
            return array;
        }

        public static T[] Add<T>(this T[] array, T obj)
        {
            Array.Resize(ref array, array.Length + 1);
            array[array.Length - 1] = obj;
            return array;
        }

        public static T[] Add<T>(this T[] array, T[] objs)
        {
            Array.Resize(ref array, array.Length + objs.Length);
            Array.Copy(objs, 0, array, array.Length - objs.Length, objs.Length);
            return array;
        }

        public static Color MoveToward(Color current, Color target, float step)
        {
            return new Color(Mathf.MoveTowards(current.r, target.r, step),
                       Mathf.MoveTowards(current.g, target.g, step),
                       Mathf.MoveTowards(current.b, target.b, step),
                       Mathf.MoveTowards(current.a, target.a, step));
        }

        public static void Cut(this Texture2D first, Texture2D second)
        {
            var pixs = first.GetPixels();
            var pixsS = second.GetPixels();
            for (int i = 0; i < pixs.Length && i < pixsS.Length; i++)
            {
                pixs[i].a *= pixsS[i].a;
            }
            first.SetPixels(pixs);
            first.Apply();
        }

        public static float Dist(this Vector2 value) => value.y - value.x;

        public static Vector2 Combine(this Vector2 A, Vector2 B)
        {
            var v = A;
            if (A.y < B.y) v.y = B.y;
            if (A.x > B.x) v.x = B.x;
            return v;
        }
        public static Vector3 Combine(this Vector3 A, Vector2 B)
        {
            var v = A;
            if (A.y < B.y) v.y = B.y;
            if (A.x > B.x) v.x = B.x;
            return v;
        }
        public static Vector3 Replace(this Vector3 A, Vector2 B)
        {
            return new Vector3(B.x, B.y, A.z);
        }
        public static Vector3 Divide(this Vector3 A, Vector3 B)
        {
            return new Vector3(A.x / B.x, A.y / B.y, A.z / B.z);
        }
        public static Vector3 Divide(this Vector2 A, Vector3 B)
        {
            return new Vector3(A.x / B.x, A.y / B.y, B.z);
        }
        public static Vector3 MoveTowards(this Vector3 A, Vector3 B, float step)
        {
            return new Vector3(Mathf.MoveTowards(A.x, B.x, step), Mathf.MoveTowards(A.y, B.y, step), Mathf.MoveTowards(A.z, B.z, step));
        }
        public static int ToLayerIndex(this LayerMask mask)
        {
            int lay = mask.value;
            int pow = 0;
            while (lay > 1)
            {
                lay = lay >> 1;
                if (++pow > 32) break;
            }
            return pow;
        }
    }
}
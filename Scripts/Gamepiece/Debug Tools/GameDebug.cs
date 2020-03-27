using UnityEngine;
using System.Diagnostics.Tracing;
using SD = System.Diagnostics;

public static class GameDebug
{
	private static bool Enabled;
	private static bool Max;
	[RuntimeInitializeOnLoadMethod]
	public static void Init()
	{
#if UNITY_EDITOR
		Enabled = true;
		Max = false;
#elif DEBUG
		Enabled = true;
		Max = true;
#else
			
		Enabled = false;
		Max = false;
#endif
		Debug.unityLogger.logEnabled = Enabled;
	}

	/// <param name="wrap">If true - also sends Class and Method names where you call Debug.</param>
	public static void Log(object message = null, bool wrap = true)
	{
		if (Enabled)
		{
			Debug.Log(wrap ? WrapMessage(message) : message);
		}
	}

	/// <param name="wrap">If true - also sends Class and Method names where you call Debug.</param>
	public static void LogWarning(object message = null, bool wrap = true)
	{
		if (Enabled)
		{
			Debug.LogWarning(wrap ? WrapMessage(message) : message);
		}
	}

	/// <param name="wrap">If true - also sends Class and Method names where you call Debug.</param>
	public static void LogError(object message = null, bool wrap = true)
	{
		if (Enabled)
		{
			Debug.LogError(wrap ? WrapMessage(message) : message);
		}
	}

	/// <param name="wrap">If true - also sends Class and Method names where you call Debug.</param>
	public static void LogMax(object message = null, bool wrap = false)
	{
		if (Max)
		{
			Debug.Log(wrap ? WrapMessage(message) : message);
		}
	}
	/// <summary>
	/// You don't need explicitly point where you call Debug.
	/// </summary>
	static string WrapMessage(object message = null)
	{
		var meth = new SD.StackTrace().GetFrame(2).GetMethod();
		return $"{meth.DeclaringType.Name}.{meth.Name}:\"{message ?? ""}\"";
	}
}
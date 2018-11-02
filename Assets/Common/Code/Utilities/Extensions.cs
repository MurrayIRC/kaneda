using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class VectorExtensions {
	#region Vector2

	public static Vector2 SetX(this Vector2 vec, float x) {
		vec.x = x;
		return vec;
	}

	public static Vector2 SetY(this Vector2 vec, float y) {
		vec.y = y;
		return vec;
	}

	#endregion

	#region Vector3

	public static Vector3 SetX(this Vector3 vec, float x) {
		vec.x = x;
		return vec;
	}

	public static Vector3 SetY(this Vector3 vec, float y) {
		vec.y = y;
		return vec;
	}

	public static Vector3 SetZ(this Vector3 vec, float z) {
		vec.z = z;
		return vec;
	}

	#endregion

	#region Vector4

	public static Vector4 SetX(this Vector4 vec, float x) {
		vec.x = x;
		return vec;
	}

	public static Vector4 SetY(this Vector4 vec, float y) {
		vec.y = y;
		return vec;
	}

	public static Vector4 SetZ(this Vector4 vec, float z) {
		vec.z = z;
		return vec;
	}

	public static Vector4 SetW(this Vector4 vec, float w) {
		vec.w = w;
		return vec;
	}

	#endregion

	#region Vector2Int

	public static Vector2Int SetX(this Vector2Int vec, int x) {
		vec.x = x;
		return vec;
	}

	public static Vector2Int SetY(this Vector2Int vec, int y) {
		vec.y = y;
		return vec;
	}

	#endregion

	#region Vector3Int

	public static Vector3Int SetX(this Vector3Int vec, int x) {
		vec.x = x;
		return vec;
	}

	public static Vector3Int SetY(this Vector3Int vec, int y) {
		vec.y = y;
		return vec;
	}

	public static Vector3Int SetZ(this Vector3Int vec, int z) {
		vec.z = z;
		return vec;
	}

	#endregion
}

public static class TransformExtensions {
	#region Position

	public static void AddPosX(this Transform t, float x) {
		t.position = new Vector3(t.position.x + x, t.position.y, t.position.z);
	}

	public static void AddPosY(this Transform t, float y) {
		t.position = new Vector3(t.position.x, t.position.y + y, t.position.z);
	}
	
	public static void AddPosZ(this Transform t, float z) {
		t.position = new Vector3(t.position.x, t.position.y, t.position.z + z);
	}

	public static void SetPosX(this Transform t, float x) {
		t.position = new Vector3(x, t.position.y, t.position.z);
	}

	public static void SetPosY(this Transform t, float y) {
		t.position = new Vector3(t.position.x, y, t.position.z);
	}

	public static void SetPosZ(this Transform t, float z) {
		t.position = new Vector3(t.position.x, t.position.y, z);
	}

	#endregion
}
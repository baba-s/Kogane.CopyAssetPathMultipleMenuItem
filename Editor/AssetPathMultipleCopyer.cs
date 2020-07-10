using System;
using System.Linq;
using UnityEditor;

namespace Kogane.Internal
{
	internal static class AssetPathMultipleCopyer
	{
		private const string ITEM_NAME = @"Assets/Copy Path (Multiple)";

		[MenuItem( ITEM_NAME )]
		private static void FromAssets()
		{
			var paths = Selection.objects
					.Select( x => AssetDatabase.GetAssetPath( x ) )
					.OrderBy( x => x )
				;

			var text = string.Join( Environment.NewLine, paths );

			EditorGUIUtility.systemCopyBuffer = text;
		}

		[MenuItem( ITEM_NAME, true )]
		private static bool Validate()
		{
			var objects = Selection.objects;
			return objects != null && 0 < objects.Length;
		}
	}
}
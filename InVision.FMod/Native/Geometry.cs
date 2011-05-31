using System;
using System.Runtime.InteropServices;

namespace InVision.FMod.Native
{
	public class Geometry
	{
		public RESULT release               ()
		{
			return FMOD_Geometry_Release(geometryraw);
		}       
		public RESULT addPolygon            (float directocclusion, float reverbocclusion, bool doublesided, int numvertices, VECTOR[] vertices, ref int polygonindex)
		{
			return FMOD_Geometry_AddPolygon(geometryraw, directocclusion, reverbocclusion, (doublesided ? 1 : 0), numvertices, vertices, ref polygonindex);
		}


		public RESULT getNumPolygons        (ref int numpolygons)
		{
			return FMOD_Geometry_GetNumPolygons(geometryraw, ref numpolygons);
		}
		public RESULT getMaxPolygons        (ref int maxpolygons, ref int maxvertices)
		{
			return FMOD_Geometry_GetMaxPolygons(geometryraw, ref maxpolygons, ref maxvertices);
		}
		public RESULT getPolygonNumVertices (int index, ref int numvertices)
		{
			return FMOD_Geometry_GetPolygonNumVertices(geometryraw, index, ref numvertices);
		}
		public RESULT setPolygonVertex      (int index, int vertexindex, ref VECTOR vertex)
		{
			return FMOD_Geometry_SetPolygonVertex(geometryraw, index, vertexindex, ref vertex);
		}
		public RESULT getPolygonVertex      (int index, int vertexindex, ref VECTOR vertex)
		{
			return FMOD_Geometry_GetPolygonVertex(geometryraw, index, vertexindex, ref vertex);
		}
		public RESULT setPolygonAttributes  (int index, float directocclusion, float reverbocclusion, bool doublesided)
		{
			return FMOD_Geometry_SetPolygonAttributes(geometryraw, index, directocclusion, reverbocclusion, (doublesided ? 1 : 0));
		}
		public RESULT getPolygonAttributes  (int index, ref float directocclusion, ref float reverbocclusion, ref bool doublesided)
		{
			RESULT result;
			int ds = 0;

			result = FMOD_Geometry_GetPolygonAttributes(geometryraw, index, ref directocclusion, ref reverbocclusion, ref ds);

			doublesided = (ds != 0);

			return result;
		}

		public RESULT setActive             (bool active)
		{
			return FMOD_Geometry_SetActive  (geometryraw, (active ? 1 : 0));
		}
		public RESULT getActive             (ref bool active)
		{
			RESULT result;
			int a = 0;

			result = FMOD_Geometry_GetActive  (geometryraw, ref a);

			active = (a != 0);

			return result;
		}
		public RESULT setRotation           (ref VECTOR forward, ref VECTOR up)
		{
			return FMOD_Geometry_SetRotation(geometryraw, ref forward, ref up);
		}
		public RESULT getRotation           (ref VECTOR forward, ref VECTOR up)
		{
			return FMOD_Geometry_GetRotation(geometryraw, ref forward, ref up);
		}
		public RESULT setPosition           (ref VECTOR position)
		{
			return FMOD_Geometry_SetPosition(geometryraw, ref position);
		}
		public RESULT getPosition           (ref VECTOR position)
		{
			return FMOD_Geometry_GetPosition(geometryraw, ref position);
		}
		public RESULT setScale              (ref VECTOR scale)
		{
			return FMOD_Geometry_SetScale(geometryraw, ref scale);
		}
		public RESULT getScale              (ref VECTOR scale)
		{
			return FMOD_Geometry_GetScale(geometryraw, ref scale);
		}
		public RESULT save                  (IntPtr data, ref int datasize)
		{
			return FMOD_Geometry_Save(geometryraw, data, ref datasize);
		}


		public RESULT setUserData               (IntPtr userdata)
		{
			return FMOD_Geometry_SetUserData(geometryraw, userdata);
		}
		public RESULT getUserData               (ref IntPtr userdata)
		{
			return FMOD_Geometry_GetUserData(geometryraw, ref userdata);
		}

		public RESULT getMemoryInfo(uint memorybits, uint event_memorybits, ref uint memoryused, ref MEMORY_USAGE_DETAILS memoryused_details)
		{
			return FMOD_Geometry_GetMemoryInfo(geometryraw, memorybits, event_memorybits, ref memoryused, ref memoryused_details);
		}

		#region importfunctions

		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_Geometry_Release              (IntPtr geometry);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_Geometry_AddPolygon           (IntPtr geometry, float directocclusion, float reverbocclusion, int doublesided, int numvertices, VECTOR[] vertices, ref int polygonindex);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_Geometry_GetNumPolygons       (IntPtr geometry, ref int numpolygons);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_Geometry_GetMaxPolygons       (IntPtr geometry, ref int maxpolygons, ref int maxvertices);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_Geometry_GetPolygonNumVertices(IntPtr geometry, int index, ref int numvertices);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_Geometry_SetPolygonVertex     (IntPtr geometry, int index, int vertexindex, ref VECTOR vertex);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_Geometry_GetPolygonVertex     (IntPtr geometry, int index, int vertexindex, ref VECTOR vertex);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_Geometry_SetPolygonAttributes (IntPtr geometry, int index, float directocclusion, float reverbocclusion, int doublesided);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_Geometry_GetPolygonAttributes (IntPtr geometry, int index, ref float directocclusion, ref float reverbocclusion, ref int doublesided);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_Geometry_Flush                (IntPtr geometry);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_Geometry_SetActive            (IntPtr geometry, int active);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_Geometry_GetActive            (IntPtr geometry, ref int active);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_Geometry_SetRotation          (IntPtr geometry, ref VECTOR forward, ref VECTOR up);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_Geometry_GetRotation          (IntPtr geometry, ref VECTOR forward, ref VECTOR up);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_Geometry_SetPosition          (IntPtr geometry, ref VECTOR position);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_Geometry_GetPosition          (IntPtr geometry, ref VECTOR position);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_Geometry_SetScale             (IntPtr geometry, ref VECTOR scale);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_Geometry_GetScale             (IntPtr geometry, ref VECTOR scale);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_Geometry_Save                 (IntPtr geometry, IntPtr data, ref int datasize);
		[DllImport (VERSION.dll)]                   
		private static extern RESULT FMOD_Geometry_SetUserData          (IntPtr geometry, IntPtr userdata);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_Geometry_GetUserData          (IntPtr geometry, ref IntPtr userdata);
		[DllImport(VERSION.dll)]
		private static extern RESULT FMOD_Geometry_GetMemoryInfo        (IntPtr geometry, uint memorybits, uint event_memorybits, ref uint memoryused, ref MEMORY_USAGE_DETAILS memoryused_details);
		#endregion

		#region wrapperinternal

		private IntPtr geometryraw;

		public void setRaw(IntPtr geometry)
		{
			geometryraw = new IntPtr();

			geometryraw = geometry;
		}

		public IntPtr getRaw()
		{
			return geometryraw;
		}

		#endregion
	}
}
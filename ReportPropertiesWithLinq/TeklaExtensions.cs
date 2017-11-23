using System.Collections.Generic;
using Tekla.Structures.Model;

namespace ReportPropertiesWithLinq
{
	public static class TeklaExtensions
	{
		public static IList<ModelObject> ToList(this ModelObjectEnumerator enumerator)
		{
			var modelObjects = new List<ModelObject>();
			while (enumerator.MoveNext())
			{
				var modelObject = enumerator.Current;
				if (modelObject == null) continue;
				modelObjects.Add(modelObject);
			}

			return modelObjects;
		}
	}
}
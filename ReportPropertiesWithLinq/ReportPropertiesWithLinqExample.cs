using System;
using System.Collections;
using System.Linq;
using Newtonsoft.Json;
using Tekla.Structures.Model;

namespace ReportPropertiesWithLinq
{
	public class ReportPropertiesWithLinqExample
	{
		private readonly ArrayList _stringReportProperties = new ArrayList
		{
			"ASSEMBLY_POS",
			"NAME",
			"PROFILE",
			"PROFILE_TYPE",
			"MATERIAL",
			"MATERIAL_TYPE",
			"FINISH",
			"TOP_LEVEL"
		};

		public void Run()
		{
			Console.WriteLine("Report Properties with Linq Example");

			var model = new Model();

			//fetch all model objects from the model
			ModelObjectEnumerator.AutoFetch = true;
			var moe = model.GetModelObjectSelector().GetAllObjects();

			//create collection using extension method
			var modelObjects = moe.ToList();

			Console.WriteLine("Creating report ...");

			//create list of beam string properties
			var beamProperties = modelObjects
				.OfType<Beam>()
				.Select(b =>
				{
					var properties = new Hashtable();
					b.GetStringReportProperties(_stringReportProperties, ref properties);
					return new
					{
						Beam = b,
						StringProperties = properties
					};
				})
				.ToList();

			var json = JsonConvert.SerializeObject(beamProperties, Formatting.Indented);

			Console.Write(json);
		}
	}
}
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Xml.Linq;
using VectorTests.Vectors;

namespace VectorTests
{
	internal class Program
	{
		/// <summary>
		/// 	Mains the specified args.
		/// </summary>
		/// <param name = "args">The args.</param>
		private static void Main(string[] args)
		{
			var actions = new Action<int>[] { SimpleVectorSum, ArrayVectorSum, PArrayVectorSum, PArrayClassVectorSum };

			var actionResults =
				from numElements in new[] { 10, 20, 50, 100, 500, 1000, 5000, 10000, 1000000 }
				let results = from result in
								  (from action in actions
								   select Bench(action, numElements))
							  orderby result.Key
							  select result
				select new
					   {
						   Results = results,
						   NumElements = numElements
					   };

			var xdoc = new XDocument(new XDeclaration("1.0", "utf-8", "yes"));
			var xbody = new XElement("benchmarks");
			xdoc.Add(xbody);

			foreach (var actionResult in actionResults)
			{
				var xbench = new XElement("benchmark");
				xbench.Add(new XAttribute("elements", actionResult.NumElements));
				xbody.Add(xbench);

				int i = 0;

				foreach (var result in actionResult.Results)
				{
					var xresult = new XElement("result");
					xresult.SetAttributeValue("index", ++i);
					xresult.SetAttributeValue("elapsedTime", result.Key);
					xresult.SetAttributeValue("method", result.Value);
					xbench.Add(xresult);
				}
			}

			xdoc.Save("Benchmarks.xml");
			Process.Start("Benchmarks.xml");
		}

		/// <summary>
		/// 	Benches the specified action.
		/// </summary>
		/// <param name = "action">The action.</param>
		/// <param name = "elements">The elements.</param>
		/// <returns></returns>
		private static KeyValuePair<double, string> Bench(Action<int> action, int elements)
		{
			const int maxTimes = 5;
			int times = 0;
			long sum = 0;

			do
			{
				long ticks = DateTime.Now.Ticks;
				action(elements);
				sum += DateTime.Now.Ticks - ticks;
			} while (++times < maxTimes);

			double elapsedTime = new TimeSpan((long)Math.Ceiling(sum / (float)maxTimes)).TotalMilliseconds;

			GC.Collect();
			GC.WaitForPendingFinalizers();

			return new KeyValuePair<double, string>(elapsedTime, action.Method.Name);
		}

		/// <summary>
		/// 	Ps the array class vector sum.
		/// </summary>
		private static void PArrayClassVectorSum(int elements)
		{
			var values = new PArrayClassVector3[elements];
			values[0] = new PArrayClassVector3(0, 0, 0);
			values[1] = new PArrayClassVector3(1, 1, 1);

			for (int i = 2; i < values.Length; i++)
			{
				values[i] = values[i - 1] + values[i - 2];
			}
		}

		/// <summary>
		/// 	Ps the array vector sum.
		/// </summary>
		private static void PArrayVectorSum(int elements)
		{
			var values = new PArrayVector3[elements];
			values[0] = new PArrayVector3(0, 0, 0);
			values[1] = new PArrayVector3(1, 1, 1);

			for (int i = 2; i < values.Length; i++)
			{
				values[i] = values[i - 1] + values[i - 2];
				values[i - 2].Dispose();
			}

			values[values.Length - 2].Dispose();
			values[values.Length - 1].Dispose();
		}

		/// <summary>
		/// 	Arrays the vector sum.
		/// </summary>
		private static void ArrayVectorSum(int elements)
		{
			var values = new ArrayVector3[elements];
			values[0] = new ArrayVector3(0, 0, 0);
			values[1] = new ArrayVector3(1, 1, 1);

			for (int i = 2; i < values.Length; i++)
			{
				values[i] = values[i - 1] + values[i - 2];
			}
		}

		/// <summary>
		/// 	Simples the vector sum.
		/// </summary>
		private static void SimpleVectorSum(int elements)
		{
			var values = new SimpleVector3[elements];
			values[0] = new SimpleVector3(0, 0, 0);
			values[1] = new SimpleVector3(1, 1, 1);

			for (int i = 2; i < values.Length; i++)
			{
				values[i] = values[i - 1] + values[i - 2];
			}
		}
	}
}
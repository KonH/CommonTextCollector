using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace CommonTextCollector {
	class Program {
		
		static void Main(string[] args) {
			var comparer = StringComparer.OrdinalIgnoreCase;
			var files = Directory.GetFiles(Directory.GetCurrentDirectory(), "*.txt");
			List<string> commonData = null;
			foreach ( var file in files ) {
				Console.WriteLine($"Processing '{file}'");
				var curData = File.ReadAllLines(file).Select(s => s.Trim()).Where(s => !string.IsNullOrWhiteSpace(s));
				if ( commonData == null ) {
					commonData = curData.ToList();
				}
				commonData = commonData.Where(s => curData.Contains(s, comparer)).ToList();
			}
			Console.WriteLine($"Processed {files.Length} files.");
			Console.WriteLine($"Found {commonData?.Count()} common lines.");
			Console.WriteLine();
			foreach (var line in commonData) {
				Console.WriteLine(line);
			}
		}
	}
}

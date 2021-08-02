using System.Collections.Generic;

namespace Count4U.Model.Common
{
	public class SettingsRepository : ISettingsRepository
    {
        public string CurrentLanguage { get; set; }
        public string LogPath { get; set; }
		public string ProcessCode { get; set; }
		public Dictionary<string, string> StartupArgumentDictionary { get; set; }
        public IturAnalyzesRepositoryEnum ReportRepositoryGet { get; set; } 
    }
}
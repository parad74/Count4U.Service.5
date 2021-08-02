using System.Collections.Generic;

namespace Count4U.Model.Common
{
	public interface ISettingsRepository
    {
        string CurrentLanguage { get; set; }
        string LogPath { get; set; }
		//string ProcessCode { get; set; }
		Dictionary<string, string> StartupArgumentDictionary { get; set; }
        IturAnalyzesRepositoryEnum ReportRepositoryGet { get; set; } 
    }
}
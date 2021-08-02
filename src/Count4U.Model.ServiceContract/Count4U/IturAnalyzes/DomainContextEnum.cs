namespace Count4U.Model.Count4U
{
	public enum LevelInAnalyzesEnum        //? уровень с которого запускаем, ? только для IA 	 Level
	{
		Itur = 0,
		Doc = 1,
		Location = 2,
		Product = 3,
		InventProduct = 4,
		PDA = 5,
		Iturs = 6,
		Customer = 7,
		Branch = 8,
		Inventor = 9,
		AuditConfig = 10,
		None = 20
	}

	public enum IturAnalyzeTypeEnum
	{
		Simple = 0,
		SimpleSum = 1,
		Full = 20,
		FullFamilySortLocationIturMakat = 21
	}

	public enum AnalezeValueTypeEnum
	{
		CountItems_InsertManually = 1,
		CountItems_InsertFromBarcode = 2,
		CountItems_Total = 3,
		CountPDAMakats_Total = 4,
		CountERPMakats_Total = 5,
		SumDifferenceValueLess0_Total = 6,
		SumDifferenceValueGrate0_Total = 7
	}
}
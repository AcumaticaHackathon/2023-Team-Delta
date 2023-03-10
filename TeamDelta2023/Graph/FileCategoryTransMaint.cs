using System;
using PX.Data;

namespace RulesEngine
{
  public class FileCategoryTransMaint : PXGraph<FileCategoryTransMaint>
  {

    public PXFilter<MasterTable> MasterView;
    public PXSelectReadonly<DeltaFileGeneral> DetailsView;

    [Serializable]
    public class MasterTable : IBqlTable
    {
      #region NameFilter
      [PXDBString(255, IsUnicode = true, InputMask = "")]
      [PXUIField(DisplayName = "File Contains")]
      public virtual string NameFilter { get; set; }
      public abstract class nameFilter : PX.Data.BQL.BqlString.Field<nameFilter> { }
      #endregion

      #region CategoryFilter
      [PXDBString(255, IsUnicode = true, InputMask = "")]
      [PXUIField(DisplayName = "Category Contains")]
      public virtual string CategoryFilter { get; set; }
      public abstract class categoryFilter : PX.Data.BQL.BqlString.Field<categoryFilter> { }
      #endregion

      #region SummaryFilter
      [PXDBString(IsUnicode = true, InputMask = "")]
      [PXUIField(DisplayName = "Summary Contains")]
      public virtual string SummaryFilter { get; set; }
      public abstract class summaryFilter : PX.Data.BQL.BqlString.Field<summaryFilter> { }
      #endregion
    }
  }
}
using System;
using PX.Data;

namespace RulesEngine
{
  [Serializable]
  [PXCacheName("DeltaFileGeneral")]
  public class DeltaFileGeneral : IBqlTable
  {
    #region Fileid
    [PXDBGuid()]
    [PXUIField(DisplayName = "Fileid")]
    public virtual Guid? Fileid { get; set; }
    public abstract class fileid : PX.Data.BQL.BqlGuid.Field<fileid> { }
    #endregion

    #region Name
    [PXDBString(255, IsUnicode = true, InputMask = "")]
    [PXUIField(DisplayName = "Name")]
    public virtual string Name { get; set; }
    public abstract class name : PX.Data.BQL.BqlString.Field<name> { }
    #endregion

    #region Category
    [PXDBString(255, IsUnicode = true, InputMask = "")]
    [PXUIField(DisplayName = "Category")]
    public virtual string Category { get; set; }
    public abstract class category : PX.Data.BQL.BqlString.Field<category> { }
    #endregion

    #region Summary
    [PXDBString(IsUnicode = true, InputMask = "")]
    [PXUIField(DisplayName = "Summary")]
    public virtual string Summary { get; set; }
    public abstract class summary : PX.Data.BQL.BqlString.Field<summary> { }
    #endregion
  }
}
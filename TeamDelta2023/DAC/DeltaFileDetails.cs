using System;
using PX.Data;
using RulesEngine;

namespace TeamDelta2023
{
  [Serializable]
  [PXCacheName("DeltaFileDetails")]
  public class DeltaFileDetails : IBqlTable
  {
    #region Fileid
    [PXDBGuid()]
    [PXUIField(DisplayName = "Fileid")]
    public virtual Guid? Fileid { get; set; }
    public abstract class fileid : PX.Data.BQL.BqlGuid.Field<fileid> { }
    #endregion

    #region LineNbr
    [PXDBIdentity(IsKey = true)]
    public virtual int? LineNbr { get; set; }
    public abstract class lineNbr : PX.Data.BQL.BqlInt.Field<lineNbr> { }
    #endregion

    #region CategoryID
    [PXDBInt()]
    [PXUIField(DisplayName = "Category ID")]
        [PXSelector(typeof(Search<DeltaCategory.categoryID>),
       DescriptionField = typeof(DeltaCategory.description),
       SubstituteKey = typeof(DeltaCategory.name))]
        public virtual int? CategoryID { get; set; }
    public abstract class categoryID : PX.Data.BQL.BqlInt.Field<categoryID> { }
        #endregion

        //#region Category
        //[PXDBString(255, IsUnicode = true, InputMask = "")]
        //[PXUIField(DisplayName = "Category")]
        //public virtual string Category { get; set; }
        //public abstract class category : PX.Data.BQL.BqlString.Field<category> { }
        //#endregion

        #region Summary
        [PXDBString(IsUnicode = true, InputMask = "")]
    [PXUIField(DisplayName = "Summary")]
    public virtual string Summary { get; set; }
    public abstract class summary : PX.Data.BQL.BqlString.Field<summary> { }
    #endregion

    #region Tstamp
    [PXDBTimestamp()]
    [PXUIField(DisplayName = "Tstamp")]
    public virtual byte[] Tstamp { get; set; }
    public abstract class tstamp : PX.Data.BQL.BqlByteArray.Field<tstamp> { }
        #endregion

        //[PXSearchable(PX.Objects.SM.SearchCategory.All ,
        //          titlePrefix: "Summary :{0}",// -: Category {1}",
        //          titleFields: new Type[] { typeof(DeltaFileDetails.summary) },//, typeof(DeltaFileDetails.category) },
        //          fields: new Type[] { typeof(DeltaFileDetails.summary) },// typeof(DeltaFileDetails.category), typeof(DeltaFileDetails.summary) },
        //          NumberFields = new Type[] { typeof(DeltaFileDetails.lineNbr) },
        //        Line1Format = "{0}",
        //        Line1Fields = new Type[] { typeof(DeltaFileDetails.summary) }
        //        //Line2Format = "{0}",
        //        //Line2Fields = new Type[] { typeof(DeltaFileDetails.category) }
        //        )]
        #region Noteid
        [PXNote()]
    public virtual Guid? Noteid { get; set; }
    public abstract class noteid : PX.Data.BQL.BqlGuid.Field<noteid> { }
    #endregion

    #region CreatedByID
    [PXDBCreatedByID()]
    public virtual Guid? CreatedByID { get; set; }
    public abstract class createdByID : PX.Data.BQL.BqlGuid.Field<createdByID> { }
    #endregion

    #region CreatedByScreenID
    [PXDBCreatedByScreenID()]
    public virtual string CreatedByScreenID { get; set; }
    public abstract class createdByScreenID : PX.Data.BQL.BqlString.Field<createdByScreenID> { }
    #endregion

    #region CreatedDateTime
    [PXDBDate()]
    [PXUIField(DisplayName = "Created Date Time")]
    public virtual DateTime? CreatedDateTime { get; set; }
    public abstract class createdDateTime : PX.Data.BQL.BqlDateTime.Field<createdDateTime> { }
    #endregion

    #region LastModifiedByID
    [PXDBLastModifiedByID()]
    public virtual Guid? LastModifiedByID { get; set; }
    public abstract class lastModifiedByID : PX.Data.BQL.BqlGuid.Field<lastModifiedByID> { }
    #endregion

    #region LastModifiedByScreenID
    [PXDBLastModifiedByScreenID()]
    public virtual string LastModifiedByScreenID { get; set; }
    public abstract class lastModifiedByScreenID : PX.Data.BQL.BqlString.Field<lastModifiedByScreenID> { }
    #endregion

    #region LastModifiedDateTime
    [PXDBDate()]
    [PXUIField(DisplayName = "Last Modified Date Time")]
    public virtual DateTime? LastModifiedDateTime { get; set; }
    public abstract class lastModifiedDateTime : PX.Data.BQL.BqlDateTime.Field<lastModifiedDateTime> { }
    #endregion
  }
}
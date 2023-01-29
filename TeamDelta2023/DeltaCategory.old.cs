using PX.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PX.SM.AUStepField;

namespace TeamDelta2023
{
    [Serializable]
    [PXCacheName("DeltaCategory")]
    public class DeltaCategory : IBqlTable
    {
        #region CategoryID

        [PXDBInt(IsKey = true)]
        [PXUIField(DisplayName = "Category ID")]
        public virtual int? CategoryID { get; set; }

        public abstract class categoryID : PX.Data.BQL.BqlInt.Field<categoryID>
        {
        }

        #endregion

        #region Name

        [PXDBString(50, IsKey = true, IsUnicode = true, InputMask = "")]
        [PXUIField(DisplayName = "Name")]
        public virtual string Name { get; set; }

        public abstract class name : PX.Data.BQL.BqlString.Field<name>
        {
        }

        #endregion

        #region Description

        [PXDBString(100, IsUnicode = true, InputMask = "")]
        [PXUIField(DisplayName = "Description")]
        public virtual string Description { get; set; }

        public abstract class description : PX.Data.BQL.BqlString.Field<description>
        {
        }

        #endregion

        #region CreatedByID

        [PXDBCreatedByID()] public virtual Guid? CreatedByID { get; set; }

        public abstract class createdByID : PX.Data.BQL.BqlGuid.Field<createdByID>
        {
        }

        #endregion

        #region CreatedByScreenID

        [PXDBCreatedByScreenID()] public virtual string CreatedByScreenID { get; set; }

        public abstract class createdByScreenID : PX.Data.BQL.BqlString.Field<createdByScreenID>
        {
        }

        #endregion

        #region CreatedDateTime

        [PXDBCreatedDateTime()] public virtual DateTime? CreatedDateTime { get; set; }

        public abstract class createdDateTime : PX.Data.BQL.BqlDateTime.Field<createdDateTime>
        {
        }

        #endregion

        #region LastModifiedByID

        [PXDBLastModifiedByID()] public virtual Guid? LastModifiedByID { get; set; }

        public abstract class lastModifiedByID : PX.Data.BQL.BqlGuid.Field<lastModifiedByID>
        {
        }

        #endregion

        #region LastModifiedByScreenID

        [PXDBLastModifiedByScreenID()] public virtual string LastModifiedByScreenID { get; set; }

        public abstract class lastModifiedByScreenID : PX.Data.BQL.BqlString.Field<lastModifiedByScreenID>
        {
        }

        #endregion

        #region LastModifiedDateTime

        [PXDBLastModifiedDateTime()] public virtual DateTime? LastModifiedDateTime { get; set; }

        public abstract class lastModifiedDateTime : PX.Data.BQL.BqlDateTime.Field<lastModifiedDateTime>
        {
        }

        #endregion

        #region Tstamp

        [PXDBTimestamp()]
        [PXUIField(DisplayName = "Tstamp")]
        public virtual byte[] Tstamp { get; set; }

        public abstract class tstamp : PX.Data.BQL.BqlByteArray.Field<tstamp>
        {
        }

        #endregion

        #region Noteid

        [PXNote()] public virtual Guid? Noteid { get; set; }

        public abstract class noteid : PX.Data.BQL.BqlGuid.Field<noteid>
        {
        }

        #endregion
    }
}

using PX.Common;
using PX.Data;
using PX.Objects.CS;
using PX.Objects.SO;
using PX.SM;
using RulesEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PX.Data.BQL.BqlPlaceholder;

namespace TeamDelta2023
{
    public class PXGraphExt : PXGraphExtension<PXGraph>
    {
        public static bool IsActive()
        {
            return AFMActive.IsActive();
        }

        public override void Initialize()
        {
            System.Diagnostics.Debug.Print(Base.GetType().FullName);
            if(!string.IsNullOrEmpty(Base.PrimaryView))
                Base.FieldUpdating.AddHandler(Base.PrimaryView, "NoteFiles", (sender, e) => {
                    var fileID = PXContext.GetSlot<Guid?>("SearchFileID");
                    if (fileID.HasValue)
                    {
                        PXContext.ClearSlot("SearchFileID");
                        var noteID = (Guid?)sender.Current.GetType().GetProperty("NoteID").GetValue(sender.Current);
                        //NoteDoc doc = PXSelect<NoteDoc, Where<NoteDoc.fileID, Equal<Required<NoteDoc.fileID>>>>.Select(Base, fileID);
                        AddUpdateSearch(sender, noteID??Guid.Empty,fileID??Guid.Empty,Base.PrimaryItemType.FullName);
                    }

                });

            if (Base.Caches<NoteDoc>() != null)
            {
               //Base.RowInserted.AddHandler<NoteDoc>((sender, e) =>
               //{
               //    AddUpdateSearch(sender, (NoteDoc)e.Row);

               //});
               // Base.RowUpdated.AddHandler<NoteDoc>((sender, e) =>
               // {
               //     AddUpdateSearch(sender, (NoteDoc)e.Row);

               // });
                //Base.RowPersisted.AddHandler<NoteDoc>((sender, e) =>
                //{
                //    AddUpdateSearch(sender, (NoteDoc)e.Row);

                //});

            }
            base.Initialize();
        }

        protected void AddUpdateSearch(PXCache sender, Guid noteID, Guid fileID, string entityName)
        {
            //var row = (NoteDoc)e.Row;
            //NoteDoc doc = PXSelect<NoteDoc, Where<NoteDoc.fileID, Equal<Required<NoteDoc.fileID>>>>.Select(Base, row.FileID);

            //if(doc != null)
            //{
            SearchIndex index = PXSelect<SearchIndex, Where<SearchIndex.noteID, Equal<Required<SearchIndex.noteID>>>>.Select(Base, noteID);
            if (index != null)
            {
                DeltaFileDetails detail = PXSelect<DeltaFileDetails, Where<DeltaFileDetails.fileid, Equal<Required<DeltaFileDetails.fileid>>>>.Select(Base, fileID);
                index.Content += detail.Summary;
                PXDatabase.Update<SearchIndex>(new PXDataFieldAssign<SearchIndex.content>(index.Content), new PXDataFieldRestrict<SearchIndex.indexID>(index.IndexID));
            }
            else
            {
                DeltaFileDetails detail = PXSelect<DeltaFileDetails, Where<DeltaFileDetails.fileid, Equal<Required<DeltaFileDetails.fileid>>>>.Select(Base, fileID);

                PXDatabase.Insert<SearchIndex>(new PXDataFieldAssign<SearchIndex.content>(detail.Summary),
                                      new PXDataFieldAssign<SearchIndex.entityType>(entityName ?? "PX.Objects.SO.SOOrder"),
                                      new PXDataFieldAssign<SearchIndex.noteID>(noteID),
                                      new PXDataFieldAssign<SearchIndex.category>(65535),
                                      new PXDataFieldAssign<SearchIndex.indexID>(Guid.NewGuid()));
            }
        }
    }
}
    


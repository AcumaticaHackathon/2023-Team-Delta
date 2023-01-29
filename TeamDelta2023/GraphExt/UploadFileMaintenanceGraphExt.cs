using PX.Common;
using PX.Data;
using PX.Objects.SO;
using PX.SM;
using RulesEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TeamDelta2023
{
    public class UploadFileMaintenanceExt : PXGraphExtension<UploadFileMaintenance>
    {
        public static bool IsActive()
        {
            return AFMActive.IsActive();
        }
        public virtual void __(Events.RowPersisting<UploadFile> e)
        {
            var row = (UploadFile)e.Row;
            var filenmae = System.IO.Path.GetTempFileName().Replace("tmp", row.Extansion);
            System.IO.File.WriteAllBytes(filenmae, row.Data);
            var text = FileIndexer.GetFileText(filenmae);
            var categories = PXSelect<DeltaCategoryRules>.Select(Base);
            int? catID = null;
            string cat = "";
            bool flag = true;
            foreach(DeltaCategoryRules category in categories)
            {
                var searches = category.SearchString.Split(',');
                foreach (var search in searches)
                {
                    var param = search.Split('#');
                    var result = Regex.Matches(text, param.First());
                    var limit = 1;
                    if (param.Length > 1)
                        limit = int.Parse(param.Last());
                    if(result.Count<limit)
                    {
                        flag &= false;
                        //catID = category.CategoryID.Value;
                        //DeltaCategory catRec = PXSelect<DeltaCategory, Where<DeltaCategory.categoryID, Equal<Required<DeltaCategory.categoryID>>>>.Select(Base, catID);
                        //cat = catRec?.Name;
                        //goto Here;
                    }
                }
                if(flag)
                {
                    catID = category.CategoryID.Value;
                    break;
                }
            }
            if (catID > 0)
            {
                var graph = PXGraph.CreateInstance<DeltaFileDetailMaint>();
                graph.Details.Insert(new DeltaFileDetails()
                {
                    Fileid = row.FileID,
                    Summary = text,
                    //Category = cat,
                    CategoryID = catID,
                    //Noteid=Guid.NewGuid(),
                });
                PXContext.SetSlot("SearchFileID", row.FileID);
                graph.Save.Press();
            }
        }


    }
}
    

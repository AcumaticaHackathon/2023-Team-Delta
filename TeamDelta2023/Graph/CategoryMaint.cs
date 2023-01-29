using System;
using PX.Data;

namespace RulesEngine
{
  public class CategoryMaint : PXGraph<CategoryMaint>
  {

    public PXSave<DeltaCategory> Save;
    public PXCancel<DeltaCategory> Cancel;


    public PXSelect<DeltaCategory> MasterView;
    public PXSelect<DeltaCategory> DetailsView;


  }
}
using System;
using PX.Data;

namespace RulesEngine
{
  public class DeltaCategoryRulesMaint : PXGraph<DeltaCategoryRulesMaint>
  {

    public PXSave<DeltaCategoryRules> Save;
    public PXCancel<DeltaCategoryRules> Cancel;

    public PXSelect<DeltaCategoryRules> MasterView;
    public PXSelect<DeltaCategoryRules> DetailsView;

  }
}
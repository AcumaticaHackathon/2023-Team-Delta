using PX.Data;
using RulesEngine;
using TeamDelta2023;

public class ManageCategories : PXGraph<ManageCategories,DeltaCategory>
{
    public PXFilter<DeltaCategory> MasterView;
}
using System;
using PX.Data;
using PX.Metadata;
using static PX.Api.SYWhatToShow;

namespace RulesEngine
{
  public class DeltaAFMPrefsMaint : PXGraph<DeltaAFMPrefsMaint>
  {

    public PXSave<DeltaAFMPrefs> Save;
    public PXCancel<DeltaAFMPrefs> Cancel;


    public PXSelect<DeltaAFMPrefs> MasterView;
    public PXSelect<DeltaAFMPrefs> DetailsView;


        public override void Persist()
        {
            base.Persist();
            PXDatabase.ResetSlots();
            this.Clear();
            throw new PXRefreshException();
        }
    }
}
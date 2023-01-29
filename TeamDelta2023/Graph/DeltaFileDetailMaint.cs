using PX.Data;
using TeamDelta2023;

public class DeltaFileDetailMaint : PXGraph<DeltaFileDetailMaint, DeltaFileDetails>
{
    public PXSelect<DeltaFileDetails> Details;
}
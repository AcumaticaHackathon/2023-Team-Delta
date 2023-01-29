using PX.Data;
using RulesEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PX.Data.BQL.BqlPlaceholder;

namespace TeamDelta2023
{
    public class AFMActive
    {
        public static bool IsActive()
        {
            bool state = false;
            try
            {
                using (var license = PXDatabase.SelectSingle<DeltaAFMPrefs>(new PXDataField<DeltaAFMPrefs.isOcrEnabled>()))
                {
                    var ext = license?.GetBoolean(0);
                    state = ext ?? false;
                }
            }
            catch (Exception ex)
            {
                PXTrace.WriteError(ex);
                state = false;
            }
            return state;
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using PX.Common;
using PX.Data;
using PX.Objects.AP;
using PX.Objects.AR;
using PX.Objects.CA;
using PX.Objects.CM;
using PX.Objects.CR;
using PX.Objects.CS;
using PX.Objects.DR;
using PX.Objects.EP;
using PX.Objects.GL;
using PX.Objects.IN;
using PX.Objects.PM;
using PX.Objects.PO;
using PX.Objects.TX;
using POLine = PX.Objects.PO.POLine;
using POOrder = PX.Objects.PO.POOrder;
//using PX.CarrierService;
using CRLocation = PX.Objects.CR.Standalone.Location;
using PX.Objects.AR.CCPaymentProcessing;
using PX.Objects.AR.CCPaymentProcessing.Common;
using PX.Objects.AR.CCPaymentProcessing.Helpers;
using PX.Objects.AR.CCPaymentProcessing.Interfaces;
using ARRegisterAlias = PX.Objects.AR.Standalone.ARRegisterAlias;
using PX.Objects.AR.MigrationMode;
using PX.Objects.Common;
using PX.Objects.Common.Discount;
using PX.Objects.Common.Extensions;
using PX.Objects.IN.Overrides.INDocumentRelease;
using PX.CS.Contracts.Interfaces;
//using Message = PX.CarrierService.Message;
//using PX.TaxProvider;
using PX.Data.DependencyInjection;
using PX.Data.WorkflowAPI;
//using PX.LicensePolicy;
using PX.Objects.Extensions.PaymentTransaction;
using PX.Objects.SO.GraphExtensions.CarrierRates;
using PX.Objects.SO.GraphExtensions.SOOrderEntryExt;
using PX.Objects.SO.Attributes;
using PX.Objects.Common.Attributes;
using PX.Objects.Common.Bql;
using OrderActions = PX.Objects.SO.SOOrderEntryActionsAttribute;
using PX.Objects.SO.DAC.Projections;
//using PX.Data.BQL.Fluent;
using PX.Data.Localization;
using PX.Data.Reports;
using PX.Objects;
using PX.Objects.SO;
using TeamDelta2023;

namespace RulesEngine
{
  public class SOOrderEntry_Extension : PXGraphExtension<PX.Objects.SO.SOOrderEntry>
  {
        public static bool IsActive()
        {
            return AFMActive.IsActive();
        }
        #region Views

        public PXSelectReadonly<DeltaFileSOOrder, Where<DeltaFileSOOrder.orderNbr, Equal<Current<SOOrder.orderNbr>>, And<DeltaFileSOOrder.orderType, Equal<Current<SOOrder.orderType>>>>> DeltaFileSOOrderView;

        protected void _(Events.RowSelected<SOOrder> e)
        {
            DeltaFileSOOrderView.Cache.Clear();
            DeltaFileSOOrderView.Cache.ClearQueryCache();
        }

    #endregion
  }
}
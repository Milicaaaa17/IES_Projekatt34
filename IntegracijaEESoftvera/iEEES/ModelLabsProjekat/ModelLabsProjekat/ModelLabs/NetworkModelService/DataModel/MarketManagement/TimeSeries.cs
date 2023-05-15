using FTN.Common;
using FTN.Services.NetworkModelService.DataModel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FTN.Services.NetworkModelService.DataModel.MarketManagement
{
    public class TimeSeries : IdentifiedObject
    {

        public TimeSeries(long globalId) : base(globalId)
        {

        }

        private string objectAggregation = String.Empty;
        private string product = String.Empty;
        private string version = String.Empty;
        private List<long> measurementPoints = new List<long>();
        private long marketDocument = 0;
        private long period = 0;

        public string ObjectAggregation { get => objectAggregation; set => objectAggregation = value; }
        public string Product { get => product; set => product = value; }
        public string Version { get => version; set => version = value; }
        public List<long> MeasurementPoints { get => measurementPoints; set => measurementPoints = value; }
        public long MarketDocument { get => marketDocument; set => marketDocument = value; }
        public long Period { get => period; set => period = value; }


        public override bool Equals(object obj)
        {
            if (base.Equals(obj))
            {
                TimeSeries x = (TimeSeries)obj;
                return (x.marketDocument == this.marketDocument &&
                        x.period == this.period &&
                        x.objectAggregation == this.objectAggregation &&
                        x.product == this.product &&
                        x.version == this.version &&
                        CompareHelper.CompareLists(x.measurementPoints, this.measurementPoints, true)
                        );
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }


        #region IAccess implementation

        public override bool HasProperty(ModelCode t)
        {
            switch (t)
            {
                case ModelCode.TIMESERIES_MARKETDOCUMENT:
                case ModelCode.TIMESERIES_MEASUREMENTPOINT:
                case ModelCode.TIMESERIES_OBJECTAGGREGATION:
                case ModelCode.TIMESERIES_PERIOD:
                case ModelCode.TIMESERIES_PRODUCT:
                case ModelCode.TIMESERIES_VERSION:
                    return true;

                default:
                    return base.HasProperty(t);
            }
        }

        public override void GetProperty(Property prop)
        {
            switch (prop.Id)
            {
                case ModelCode.TIMESERIES_MARKETDOCUMENT:
                    prop.SetValue(marketDocument);
                    break;

                case ModelCode.TIMESERIES_MEASUREMENTPOINT:
                    prop.SetValue(measurementPoints);
                    break;

                case ModelCode.TIMESERIES_OBJECTAGGREGATION:
                    prop.SetValue(objectAggregation);
                    break;

                case ModelCode.TIMESERIES_PERIOD:
                    prop.SetValue(period);
                    break;

                case ModelCode.TIMESERIES_PRODUCT:
                    prop.SetValue(product);
                    break;

                case ModelCode.TIMESERIES_VERSION:
                    prop.SetValue(version);
                    break;

                default:
                    base.GetProperty(prop);
                    break;
            }
        }

        public override void SetProperty(Property property)
        {
            switch (property.Id)
            {
                case ModelCode.TIMESERIES_MARKETDOCUMENT:
                    marketDocument = property.AsLong();
                    break;

                case ModelCode.TIMESERIES_OBJECTAGGREGATION:
                    objectAggregation = property.AsString();
                    break;

                case ModelCode.TIMESERIES_PRODUCT:
                    product = property.AsString();
                    break;

                case ModelCode.TIMESERIES_VERSION:
                    version = property.AsString();
                    break;

                case ModelCode.TIMESERIES_PERIOD:
                    period = property.AsLong();
                    break;

                default:
                    base.SetProperty(property);
                    break;
            }
        }

        #endregion IAccess implementation
        #region IReference implementation

        public override bool IsReferenced
        {
            get
            {
                return measurementPoints.Count > 0 || base.IsReferenced;
            }
        }

        public override void GetReferences(Dictionary<ModelCode, List<long>> references, TypeOfReference refType)
        {
            if (measurementPoints != null && measurementPoints.Count > 0 && (refType == TypeOfReference.Target || refType == TypeOfReference.Both))
            {
                references[ModelCode.TIMESERIES_MEASUREMENTPOINT] = measurementPoints.GetRange(0, measurementPoints.Count);
            }

            if (period != 0 && (refType == TypeOfReference.Reference || refType == TypeOfReference.Both))
            {
                references[ModelCode.TIMESERIES_PERIOD] = new List<long>();
                references[ModelCode.TIMESERIES_PERIOD].Add(period);
            }


            if (marketDocument != 0 && (refType == TypeOfReference.Reference || refType == TypeOfReference.Both))
            {
                references[ModelCode.TIMESERIES_MARKETDOCUMENT] = new List<long>();
                references[ModelCode.TIMESERIES_MARKETDOCUMENT].Add(marketDocument);
            }

            base.GetReferences(references, refType);
        }

        public override void AddReference(ModelCode referenceId, long globalId)
        {
            switch (referenceId)
            {
                case ModelCode.MEASUREMENTPOINT_TIMESERIES:
                    measurementPoints.Add(globalId);
                    break;

                default:
                    base.AddReference(referenceId, globalId);
                    break;
            }
        }

        public override void RemoveReference(ModelCode referenceId, long globalId)
        {
            switch (referenceId)
            {
                case ModelCode.MEASUREMENTPOINT_TIMESERIES:

                    if (measurementPoints.Contains(globalId))
                    {
                        measurementPoints.Remove(globalId);
                    }
                    else
                    {
                        CommonTrace.WriteTrace(CommonTrace.TraceWarning, "Entity (GID = 0x{0:x16}) doesn't contain reference 0x{1:x16}.", this.GlobalId, globalId);
                    }

                    break;

                default:
                    base.RemoveReference(referenceId, globalId);
                    break;
            }
        }


        #endregion IReference implementation

    }
}

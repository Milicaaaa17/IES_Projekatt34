using FTN.Common;
using FTN.Services.NetworkModelService.DataModel.Core;
using FTN.Services.NetworkModelService.DataModel.IESProjects;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace FTN.Services.NetworkModelService.DataModel.MarketManagement
{
    public class Period : IdentifiedObject
    {

        public Period(long globalId) : base(globalId)
        {

        }

        //private DateTime timeInterval;
        private long marketDocument = 0;
        List<long> point = new List<long>();
        List<long> timeSeries = new List<long>();

       // public DateTime TimeInterval { get => timeInterval; set => timeInterval = value; }
        public long MarketDocument { get => marketDocument; set => marketDocument = value; }
        public List<long> Point { get => point; set => point = value; }
        public List<long> TimeSeries { get => timeSeries; set => timeSeries = value; }


        public override bool Equals(object obj)
        {
            if (base.Equals(obj))
            {
                Period x = (Period)obj;
                return (   x.marketDocument == this.marketDocument &&
                         CompareHelper.CompareLists(x.point, this.point, true) &&
                        CompareHelper.CompareLists(x.timeSeries, this.timeSeries, true)

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
               // case ModelCode.PERIOD_TIMEINTERVAL:
                case ModelCode.PERIOD_MARKETDOCUMENT:
                case ModelCode.PERIOD_POINT:
                case ModelCode.PERIOD_TIMESERIES:

                    return true;

                default:
                    return base.HasProperty(t);
            }
        }

        public override void GetProperty(Property prop)
        {
            switch (prop.Id)
            {
               // case ModelCode.PERIOD_TIMEINTERVAL:
                   // prop.SetValue(timeInterval);
                   // break;

                case ModelCode.PERIOD_MARKETDOCUMENT:
                    prop.SetValue(marketDocument);
                    break;
                case ModelCode.PERIOD_POINT:
                    prop.SetValue(point);
                    break;

                case ModelCode.PERIOD_TIMESERIES:
                    prop.SetValue(timeSeries);
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
                //case ModelCode.PERIOD_TIMEINTERVAL:
                   // timeInterval = property.AsDateTime();
                   // break;

                case ModelCode.PERIOD_MARKETDOCUMENT:
                    marketDocument = property.AsLong();
                    break;
                case ModelCode.PERIOD_POINT:
                    marketDocument = property.AsLong();
                    break;
                case ModelCode.PERIOD_TIMESERIES:
                    marketDocument = property.AsLong();
                    break;


                default:
                    base.SetProperty(property);
                    break;
            }
        }

        public override bool IsReferenced
        {
            get
            {
                return point.Count > 0 || timeSeries.Count > 0 || base.IsReferenced;
            }
        }

        public override void GetReferences(Dictionary<ModelCode, List<long>> references, TypeOfReference refType)
        {
            if (point != null && point.Count > 0 && (refType == TypeOfReference.Target || refType == TypeOfReference.Both))
            {
                references[ModelCode.PERIOD_POINT] = point.GetRange(0, point.Count);
            }


            if (timeSeries != null && timeSeries.Count > 0 && (refType == TypeOfReference.Target || refType == TypeOfReference.Both))
            {
                references[ModelCode.PERIOD_TIMESERIES] = timeSeries.GetRange(0, timeSeries.Count);
            }

            if (marketDocument != 0 && (refType == TypeOfReference.Reference || refType == TypeOfReference.Both))
            {
                references[ModelCode.PERIOD_MARKETDOCUMENT] = new List<long>();
                references[ModelCode.PERIOD_MARKETDOCUMENT].Add(marketDocument);
            }

            base.GetReferences(references, refType);
        }

        public override void AddReference(ModelCode referenceId, long globalId)
        {
            switch (referenceId)
            {
                case ModelCode.POINT_PERIOD:
                    point.Add(globalId);
                    break;

                case ModelCode.TIMESERIES_PERIOD:
                    timeSeries.Add(globalId);
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
                case ModelCode.POINT_PERIOD:

                    if (point.Contains(globalId))
                    {
                        point.Remove(globalId);
                    }
                    else
                    {
                        CommonTrace.WriteTrace(CommonTrace.TraceWarning, "Entity (GID = 0x{0:x16}) doesn't contain reference 0x{1:x16}.", this.GlobalId, globalId);
                    }

                    break;

                case ModelCode.TIMESERIES_PERIOD:

                    if (timeSeries.Contains(globalId))
                    {
                        timeSeries.Remove(globalId);
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

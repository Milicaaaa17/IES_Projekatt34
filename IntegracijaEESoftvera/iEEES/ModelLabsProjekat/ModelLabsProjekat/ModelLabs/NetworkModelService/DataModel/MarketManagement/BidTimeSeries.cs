using FTN.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FTN.Services.NetworkModelService.DataModel.MarketManagement
{
    public class BidTimeSeries : TimeSeries
    {


        public BidTimeSeries(long globalId) : base(globalId)
        {

        }

        private bool blockBid = false;
        private string direction = string.Empty;
        private bool divisible = false;
        private string linkedBidsIdentifications = string.Empty;
        private float mininumActivationQ = 0;
        private float stepIncQ = 0;

        public bool BlockBid { get => blockBid; set => blockBid = value; }
        public string Direction { get => direction; set => direction = value; }
        public bool Divisible { get => divisible; set => divisible = value; }
        public string LinkedBidsIdentifications { get => linkedBidsIdentifications; set => linkedBidsIdentifications = value; }
        public float MininumActivationQ { get => mininumActivationQ; set => mininumActivationQ = value; }
        public float StepIncQ { get => stepIncQ; set => stepIncQ = value; }

        public override bool Equals(object obj)
        {
            if (base.Equals(obj))
            {
                BidTimeSeries x = (BidTimeSeries)obj;
                return (x.blockBid == this.blockBid &&
                        x.direction == this.direction &&
                        x.divisible == this.divisible &&
                        x.linkedBidsIdentifications == this.linkedBidsIdentifications &&
                        x.mininumActivationQ == this.mininumActivationQ &&
                        x.stepIncQ == this.stepIncQ
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
                case ModelCode.BIDTIMESERIES_BLOCKBID:
                case ModelCode.BIDTIMESERIES_DIRECTION:
                case ModelCode.BIDTIMESERIES_DIVISIBLE:
                case ModelCode.BIDTIMESERIES_LINKED_BIDID:
                case ModelCode.BIDTIMESERIES_MIN_AQ:
                case ModelCode.BIDTIMESERIES_STEP_INCQ:
                    return true;

                default:
                    return base.HasProperty(t);
            }
        }

        public override void GetProperty(Property prop)
        {
            switch (prop.Id)
            {
                case ModelCode.BIDTIMESERIES_BLOCKBID:
                    prop.SetValue(blockBid);
                    break;

                case ModelCode.BIDTIMESERIES_DIRECTION:
                    prop.SetValue(direction);
                    break;

                case ModelCode.BIDTIMESERIES_DIVISIBLE:
                    prop.SetValue(divisible);
                    break;

                case ModelCode.BIDTIMESERIES_LINKED_BIDID:
                    prop.SetValue(linkedBidsIdentifications);
                    break;

                case ModelCode.BIDTIMESERIES_MIN_AQ:
                    prop.SetValue(mininumActivationQ);
                    break;

                case ModelCode.BIDTIMESERIES_STEP_INCQ:
                    prop.SetValue(stepIncQ);
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
                case ModelCode.BIDTIMESERIES_BLOCKBID:
                    blockBid = property.AsBool();
                    break;

                case ModelCode.BIDTIMESERIES_DIRECTION:
                    direction = property.AsString();
                    break;

                case ModelCode.BIDTIMESERIES_DIVISIBLE:
                    divisible = property.AsBool();
                    break;

                case ModelCode.BIDTIMESERIES_LINKED_BIDID:
                    linkedBidsIdentifications = property.AsString();
                    break;

                case ModelCode.BIDTIMESERIES_MIN_AQ:
                    mininumActivationQ = property.AsFloat();
                    break;

                case ModelCode.BIDTIMESERIES_STEP_INCQ:
                    stepIncQ = property.AsFloat();
                    break;


                default:
                    base.SetProperty(property);
                    break;
            }
        }

        #endregion IAccess implementation

    }
}

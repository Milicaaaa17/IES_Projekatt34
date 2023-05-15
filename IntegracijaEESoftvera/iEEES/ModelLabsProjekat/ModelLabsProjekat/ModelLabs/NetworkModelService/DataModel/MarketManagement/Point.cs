using FTN.Common;
using FTN.Services.NetworkModelService.DataModel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FTN.Services.NetworkModelService.DataModel.MarketManagement
{
    public class Point : IdentifiedObject
    {

        public Point(long globalId) : base(globalId)
        {

        }

        private float bidQuantity = 0;
        private int position = 0;
        private float quantity = 0;
        private long period = 0;

        public float BidQuantity { get => bidQuantity; set => bidQuantity = value; }
        public int Position { get => position; set => position = value; }
        public float Quantity { get => quantity; set => quantity = value; }
        public long Period { get => period; set => period = value; }


        public override bool Equals(object obj)
        {
            if (base.Equals(obj))
            {
                Point x = (Point)obj;
                return (x.bidQuantity == this.bidQuantity &&
                        x.position == this.position &&
                        x.quantity == this.quantity &&
                        x.period == this.period

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
                case ModelCode.POINT_BIDQUANTITY:
                case ModelCode.POINT_POSIION:
                case ModelCode.POINT_QUANTITY:
                case ModelCode.POINT_PERIOD
:
                    return true;

                default:
                    return base.HasProperty(t);
            }
        }

        public override void GetProperty(Property prop)
        {
            switch (prop.Id)
            {
                case ModelCode.POINT_BIDQUANTITY:
                    prop.SetValue(bidQuantity);
                    break;

                case ModelCode.POINT_POSIION:
                    prop.SetValue(position);
                    break;

                case ModelCode.POINT_QUANTITY:
                    prop.SetValue(quantity);
                    break;

                case ModelCode.POINT_PERIOD:
                    prop.SetValue(period);
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
                case ModelCode.POINT_BIDQUANTITY:
                    bidQuantity = property.AsFloat();
                    break;

                case ModelCode.POINT_POSIION:
                    position = property.AsInt();
                    break;
                case ModelCode.POINT_QUANTITY:
                    quantity = property.AsFloat();
                    break;

                default:
                    base.SetProperty(property);
                    break;
            }
        }

        #endregion IAccess implementation
        #region IReference implementation
        public override void GetReferences(Dictionary<ModelCode, List<long>> references, TypeOfReference refType)
        {
            if (period != 0 && (refType == TypeOfReference.Reference || refType == TypeOfReference.Both))
            {
                references[ModelCode.POINT_PERIOD] = new List<long>();
                references[ModelCode.POINT_PERIOD].Add(period);
            }

            base.GetReferences(references, refType);
        }

        #endregion IReference implementation



    }
}

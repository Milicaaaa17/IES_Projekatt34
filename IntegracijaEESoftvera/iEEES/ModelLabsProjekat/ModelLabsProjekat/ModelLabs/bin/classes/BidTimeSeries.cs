//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FTN {
    using System;
    using FTN;
    
    
    /// The formal specification of specific characteristics related to a bid.
    public class BidTimeSeries : TimeSeries {
        
        /// Indication that  the values in the period are considered as a whole. They cannot be changed or subdivided.
        private System.Boolean? cim_blockBid;
        
        private const bool isBlockBidMandatory = false;
        
        private const string _blockBidPrefix = "cim";
        
        /// The coded identification of the energy flow.
        private string cim_direction;
        
        private const bool isDirectionMandatory = false;
        
        private const string _directionPrefix = "cim";
        
        /// An indication whether or not each element of the bid may be partially accepted or not.
        private System.Boolean? cim_divisible;
        
        private const bool isDivisibleMandatory = false;
        
        private const string _divisiblePrefix = "cim";
        
        /// Unique identification associated with all linked bids.
        private string cim_linkedBidsIdentification;
        
        private const bool isLinkedBidsIdentificationMandatory = false;
        
        private const string _linkedBidsIdentificationPrefix = "cim";
        
        /// The minimum quantity of energy that can be activated at a given time interval.
        private System.Single? cim_minimumActivationQuantity;
        
        private const bool isMinimumActivationQuantityMandatory = false;
        
        private const string _minimumActivationQuantityPrefix = "cim";
        
        /// The minimum increment that can be applied for an increase in an activation request.
        private System.Single? cim_stepIncrementQuantity;
        
        private const bool isStepIncrementQuantityMandatory = false;
        
        private const string _stepIncrementQuantityPrefix = "cim";
        
        public virtual bool BlockBid {
            get {
                return this.cim_blockBid.GetValueOrDefault();
            }
            set {
                this.cim_blockBid = value;
            }
        }
        
        public virtual bool BlockBidHasValue {
            get {
                return this.cim_blockBid != null;
            }
        }
        
        public static bool IsBlockBidMandatory {
            get {
                return isBlockBidMandatory;
            }
        }
        
        public static string BlockBidPrefix {
            get {
                return _blockBidPrefix;
            }
        }
        
        public virtual string Direction {
            get {
                return this.cim_direction;
            }
            set {
                this.cim_direction = value;
            }
        }
        
        public virtual bool DirectionHasValue {
            get {
                return this.cim_direction != null;
            }
        }
        
        public static bool IsDirectionMandatory {
            get {
                return isDirectionMandatory;
            }
        }
        
        public static string DirectionPrefix {
            get {
                return _directionPrefix;
            }
        }
        
        public virtual bool Divisible {
            get {
                return this.cim_divisible.GetValueOrDefault();
            }
            set {
                this.cim_divisible = value;
            }
        }
        
        public virtual bool DivisibleHasValue {
            get {
                return this.cim_divisible != null;
            }
        }
        
        public static bool IsDivisibleMandatory {
            get {
                return isDivisibleMandatory;
            }
        }
        
        public static string DivisiblePrefix {
            get {
                return _divisiblePrefix;
            }
        }
        
        public virtual string LinkedBidsIdentification {
            get {
                return this.cim_linkedBidsIdentification;
            }
            set {
                this.cim_linkedBidsIdentification = value;
            }
        }
        
        public virtual bool LinkedBidsIdentificationHasValue {
            get {
                return this.cim_linkedBidsIdentification != null;
            }
        }
        
        public static bool IsLinkedBidsIdentificationMandatory {
            get {
                return isLinkedBidsIdentificationMandatory;
            }
        }
        
        public static string LinkedBidsIdentificationPrefix {
            get {
                return _linkedBidsIdentificationPrefix;
            }
        }
        
        public virtual string MinimumActivationQuantity {
            get {
                return this.cim_minimumActivationQuantity.GetValueOrDefault();
            }
            set {
                this.cim_minimumActivationQuantity = value;
            }
        }
        
        public virtual bool MinimumActivationQuantityHasValue {
            get {
                return this.cim_minimumActivationQuantity != null;
            }
        }
        
        public static bool IsMinimumActivationQuantityMandatory {
            get {
                return isMinimumActivationQuantityMandatory;
            }
        }
        
        public static string MinimumActivationQuantityPrefix {
            get {
                return _minimumActivationQuantityPrefix;
            }
        }
        
        public virtual float StepIncrementQuantity {
            get {
                return this.cim_stepIncrementQuantity.GetValueOrDefault();
            }
            set {
                this.cim_stepIncrementQuantity = value;
            }
        }
        
        public virtual bool StepIncrementQuantityHasValue {
            get {
                return this.cim_stepIncrementQuantity != null;
            }
        }
        
        public static bool IsStepIncrementQuantityMandatory {
            get {
                return isStepIncrementQuantityMandatory;
            }
        }
        
        public static string StepIncrementQuantityPrefix {
            get {
                return _stepIncrementQuantityPrefix;
            }
        }
    }
}
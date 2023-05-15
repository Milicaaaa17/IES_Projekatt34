using FTN.Common;
using FTN.Services.NetworkModelService.DataModel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FTN.Services.NetworkModelService.DataModel.Common
{
    public class Document : IdentifiedObject
    {
        private DateTime createdDateTime;
        private DateTime lastModifiedDateTime;
        private string revisionNumber = string.Empty;
        private string subject = string.Empty;
        private string title = string.Empty;
        private string type = string.Empty;



        public Document(long globalId) : base(globalId)
        {

        }

        public DateTime CreatedDateTime { get => createdDateTime; set => createdDateTime = value; }
        public DateTime LastModifiedDateTime { get => lastModifiedDateTime; set => lastModifiedDateTime = value; }
        public string RevisionNumber { get => revisionNumber; set => revisionNumber = value; }
        public string Subject { get => subject; set => subject = value; }
        public string Title { get => title; set => title = value; }
        public string Type { get => type; set => type = value; }


        public override bool Equals(object obj)
        {
            if (base.Equals(obj))
            {
                Document x = (Document)obj;
                return (x.createdDateTime == this.createdDateTime &&
                        x.lastModifiedDateTime == this.lastModifiedDateTime &&
                        x.revisionNumber == this.revisionNumber &&
                        x.subject == this.subject && x.title == this.title &&
                        x.type == this.type
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

        public override bool HasProperty(ModelCode property)
        {
            switch (property)
            {
                case ModelCode.DOCUMENT_CREATED_DATETIME:
                case ModelCode.DOCUMENT_LAST_MODIFIED_DATETIME:
                case ModelCode.DOCUMENT_REVISION_NUMBER:
                case ModelCode.DOCUMENT_SUBJECT:
                case ModelCode.DOCUMENT_TITLE:
                case ModelCode.DOCUMENT_TYPE:
                    return true;

                default:
                    return base.HasProperty(property);
            }
        }

        public override void GetProperty(Property property)
        {
            switch (property.Id)
            {
                case ModelCode.DOCUMENT_CREATED_DATETIME:
                    property.SetValue(createdDateTime);
                    break;

                case ModelCode.DOCUMENT_LAST_MODIFIED_DATETIME:
                    property.SetValue(lastModifiedDateTime);
                    break;
                case ModelCode.DOCUMENT_REVISION_NUMBER:
                    property.SetValue(revisionNumber);
                    break;

                case ModelCode.DOCUMENT_SUBJECT:
                    property.SetValue(subject);
                    break;

                case ModelCode.DOCUMENT_TITLE:
                    property.SetValue(title);
                    break;

                case ModelCode.DOCUMENT_TYPE:
                    property.SetValue(type);
                    break;

                default:
                    base.GetProperty(property);
                    break;
            }
        }

        public override void SetProperty(Property property)
        {
            switch (property.Id)
            {
                case ModelCode.DOCUMENT_CREATED_DATETIME:
                    createdDateTime = property.AsDateTime();
                    break;


                case ModelCode.DOCUMENT_LAST_MODIFIED_DATETIME:
                    lastModifiedDateTime = property.AsDateTime();
                    break;

                case ModelCode.DOCUMENT_REVISION_NUMBER:
                    revisionNumber = property.AsString();
                    break;


                case ModelCode.DOCUMENT_SUBJECT:
                    subject = property.AsString();
                    break;

                case ModelCode.DOCUMENT_TITLE:
                    title = property.AsString();
                    break;

                case ModelCode.DOCUMENT_TYPE:
                    type = property.AsString();
                    break;

                default:
                    base.SetProperty(property);
                    break;
            }
        }



        #endregion IAccess implementation
    }
}

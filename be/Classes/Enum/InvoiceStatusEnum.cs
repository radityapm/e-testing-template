namespace api.Classes.Enum
{
    public enum InvoiceStatusEnum
    {
        Invoice_Created = 0,
        Waiting_For_Approval = 1,
        Handover_Approved = 2,
        Handover_Rejected = 3,
        On_Delivery = 4,
        Delivery_Succese = 5,
        Delivery_Failed = 6,
        Payment = 7,
        Paid = 8,
        Revision_Requested = 9,
        Revision_Approved = 10,
        Revision_Rejected = 11,
        Revision_Cancelled = 12,
        Invoice_Removed = 13,
    }
}

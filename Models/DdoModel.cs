namespace statejitsss.Models
{
    public class DdoModel
    {
        public string? TreasuryCode { get; set; }
        public string? TreasuryName { get; set; }
        public string DdoCode { get; set; } = null!;
        public char? DdoType { get; set; }
        public DateOnly? ValidUpto { get; set; }
        public string? Designation { get; set; }
        public string? Gstin { get; set; }
        public string? DdoTanNo { get; set; }
        public string? NpsRegistrationNo { get; set; }
        public string? Address { get; set; }
        public string? Pin { get; set; }
        public string? PhoneNo1 { get; set; }
        public string? PhoneNo2 { get; set; }
        public string? Fax { get; set; }
        public string? EMail { get; set; }
        public string? OfficeName { get; set; }
        public string? EnrolementNo { get; set; }
        public string? Station { get; set; }
        public string? ControllingOfficer { get; set; }
    }
}

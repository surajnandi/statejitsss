namespace statejitsss.Models
{
    public class UserModel
    {
        public string? Role { get; set; }
        public long? RoleId { get; set; }
        public List<string>? Permissions { get; set; }
        public string? Level { get; set; }
        public long? LevelId { get; set; }
        public string? Scope { get; set; }
        public long? ScopeId { get; set; }
        public long? UserId { get; set; }
        public string? UserEmail { get; set; }
        public string? UserName { get; set; }
        public long? CreatedBy { get; set; }
        public string? Designation { get; set; }
        public string? TokenType { get; set; }
        public string? MobileNumber { get; set; }
    }
}

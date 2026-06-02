namespace OCMS.DTO_s.AdminDashBoard
{
    public class DashboardDTO
    {
        public int TotalUsers { get; set; }
        public int TotalComplaints { get; set; }
        public int PendingComplaints { get; set; }
        public int ResolvedComplaints { get; set; }
        public int InProgressComplaints { get; set; }
        public int RejectedComplaints { get; set; }
        public int ApprovedComplaints { get; set; }
        public int TotalApprovedUsers { get; set; }
        public int TotalPendingUsers { get; set; }
        public int TotalRejectedUsers { get; set; }
        public int TotalSuspendedUsers { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;

namespace BSATroop829.Models
{
    public class GirlTroopOrgChartViewModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? ScoutMaster { get; set; }
        [Required]
        public string? AssistantScoutMaster { get; set; }
        public string? AssistantScoutMaster2 { get; set; }
        public string? AssistantScoutMaster3 { get; set; }
        public string? SeniorPatrolLeader { get; set; }
        [Required]
        public string? AssistantSeniorPatrolLeader { get; set; }
        [Required]
        public string? PatrolLeader { get; set; }
        public string? PatrolLeader2 { get; set; }
        public string? PatrolLeader3 { get; set; }
        [Required]
        public string? AssistantPatrolLeader { get; set; }
        public string? AssistantPatrolLeader2 { get; set; }
        public string? AssistantPatrolLeader3 { get; set; }
        public string? Instructor { get; set; }
        public string? Bugler { get; set; }
        public string? Quartermaster { get; set; }
        public string? ChaplainAide { get; set; }
        public string? Librarian { get; set; }
        public string? Historian { get; set; }
        public string? Scribe { get; set; }
    }
}

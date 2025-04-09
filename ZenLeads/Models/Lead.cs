using System.ComponentModel.DataAnnotations;

namespace ZenLeads.Models
{
    public class Lead
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "O nome é obrigatório")]
        public string Nome { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "O email é obrigatório")]
        [EmailAddress(ErrorMessage = "Formato de email inválido")]
        public string Email { get; set; } = string.Empty;
        
        public string Empresa { get; set; } = string.Empty;
        
        public string Telefone { get; set; } = string.Empty;
        
        public LeadStatus Status { get; set; } = LeadStatus.EmAnalise;
    }
} 
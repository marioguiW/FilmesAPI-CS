using System.ComponentModel.DataAnnotations;

namespace FimesAPI.Modules;

public class Filme
{
    [Key]
    [Required]
    public int Id { get; set; }
    [Required(ErrorMessage = "O titulo do filme deve ser obrigatorio")]
    public string Titulo {  get; set; }

    [Required(ErrorMessage = "O genero do filme deve ser obrigatorio")]
    [MaxLength(50, ErrorMessage = "O genero não pode ultrapassar 50 caracteres")]
    public string Genero { get; set; }
    [Required(ErrorMessage = "A duração do filme deve ser obrigatoria")]
    [Range(70,600, ErrorMessage = "A duração deve ser entre 70 e 600 minutos")]
    public int Duracao { get; set; }
}

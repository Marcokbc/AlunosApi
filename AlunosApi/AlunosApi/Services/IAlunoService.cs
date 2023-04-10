using AlunosApi.Models;

namespace AlunosApi.Services
{
    public interface IAlunoService
    {
        Task<IEnumerable<Aluno>> GetAlunos();
        Task<Aluno> GetAluno(int id);
        Task<IEnumerable<Aluno>> GetAlunosByNome(String nome);
        Task CreateAluno(Aluno aluno);
        Task DeleteAluno(Aluno aluno);
        Task UpdateAluno(Aluno aluno);
    }
}

﻿using AlunosApi.Context;
using AlunosApi.Models;
using Microsoft.EntityFrameworkCore;

namespace AlunosApi.Services
{
    public class AlunoService : IAlunoService
    {
        private readonly AppDbContext _context;

        public AlunoService(AppDbContext context)
        {
            _context = context;
        }
        public async Task CreateAluno(Aluno aluno)
        {
            _context.Alunos.Add(aluno);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAluno(Aluno aluno)
        {
            _context.Alunos.Remove(aluno);
            await _context.SaveChangesAsync();
        }

        public async Task<Aluno> GetAluno(int id)
        {
            Aluno aluno = await _context.Alunos.FindAsync(id);
            return aluno;
        }

        public async Task<IEnumerable<Aluno>> GetAlunos()
        {
            try
            {
                return await _context.Alunos.ToListAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<Aluno>> GetAlunosByNome(string nome)
        {
            if (!string.IsNullOrWhiteSpace(nome))
            {
                var alunos = await _context.Alunos.Where(n => n.Name.Contains(nome)).ToListAsync();
                return alunos;
            }
            else
            {
                var alunos = await GetAlunos();
                return alunos;
            }
        }

        public async Task UpdateAluno(Aluno aluno)
        {
            _context.Entry(aluno).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}

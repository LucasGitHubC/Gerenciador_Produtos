using ApiTarefa.Data;
using ApiTarefa.Model;
using ApiTarefa.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ApiTarefa.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly SistemaTarefaDbContext _dbContext;

        public UsuarioRepositorio(SistemaTarefaDbContext sistemaTarefaDBContext)
        {
            _dbContext = sistemaTarefaDBContext;
        }


        public async Task<UsuarioModel> BuscarporId(int id)
        {
            return await _dbContext.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<UsuarioModel>> BuscarTodosUsuarios()
        {
            return await _dbContext.Usuarios.ToListAsync();
        }

        public async Task<UsuarioModel> Adicionar(UsuarioModel usuario)
        {
            await _dbContext.AddAsync(usuario);
            await _dbContext.SaveChangesAsync();

            return usuario;
        }

        public async Task<UsuarioModel> Atualizar(UsuarioModel usuario, int id)
        {
            // Validar os dados recebidos
            if (string.IsNullOrEmpty(usuario.Nome))
            {
                throw new ArgumentException("O campo Nome não pode estar vazio.");
            }

            if (usuario.Preco < 0)
            {
                throw new ArgumentException("O campo Preço não pode ser negativo.");
            }

            // Verificar se o usuário existe
            UsuarioModel usuarioPorId = await BuscarporId(id);

            if (usuarioPorId == null)
            {
                throw new Exception($"Usuário para o ID: {id} não foi encontrado no banco de dados.");
            }

            // Atualizar o usuário
            usuarioPorId.Nome = usuario.Nome;
            usuarioPorId.Descricao = usuario.Descricao;
            usuarioPorId.Preco = usuario.Preco;
            usuarioPorId.DataCriacao = usuario.DataCriacao;

            _dbContext.Usuarios.Update(usuarioPorId);
            await _dbContext.SaveChangesAsync();

            return usuarioPorId;
        }



        public async Task<bool> Apagar(int id)
        {
            UsuarioModel usuarioPorId = await BuscarporId(id);

            if (usuarioPorId == null)
            {
                throw new Exception($"Usuário para o ID: {id} não foi encontrado no banco de dados.");
            }

            _dbContext.Usuarios.Remove(usuarioPorId);
            await _dbContext.SaveChangesAsync();
            return true;
        }

    }
}

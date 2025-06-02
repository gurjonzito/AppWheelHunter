using AppWheelHunter.Models;
using AppWheelHunter.Services;
using SQLite;

namespace AppWheelHunter.Controllers
{
    public class CarroController
    {
        private DatabaseService databaseService;
        private SQLiteConnection conexao;

        public event Action DadosAlterados;

        public CarroController()
        {
            databaseService = new DatabaseService();

            conexao = databaseService.GetConexao();

            conexao.CreateTable<Carro>();
        }

        public bool Insert(Carro value)
        {
            var result = conexao.Insert(value) > 0;
            if (result) DadosAlterados?.Invoke();
            return result;
        }

        public bool Update(Carro value)
        {
            var result = conexao.Update(value) > 0;
            if (result) DadosAlterados?.Invoke();
            return result;
        }

        public bool Delete(Carro value)
        {
            var result = conexao.Delete(value) > 0;
            if (result) DadosAlterados?.Invoke();
            return result;
        }

        public List<Carro> GetAll()
        {
            return conexao.Table<Carro>().ToList();
        }

        public Carro GetById(int value)
        {
            return conexao.Find<Carro>(value);
        }

        public List<Carro> Filtrar(string modelo = null, bool? obtido = null, bool? desejado = null)
        {
            var query = conexao.Table<Carro>();

            if (!string.IsNullOrEmpty(modelo))
            {
                query = query.Where(c => c.Modelo.ToLower().Contains(modelo.ToLower()));
            }

            if (obtido.HasValue)
            {
                query = query.Where(c => c.Obtido == obtido.Value);
            }

            if (desejado.HasValue)
            {
                query = query.Where(c => c.Desejado == desejado.Value);
            }

            return query.ToList();
        }
    }
}

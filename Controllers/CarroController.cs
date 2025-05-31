using AppWheelHunter.Models;
using AppWheelHunter.Services;
using SQLite;

namespace AppWheelHunter.Controllers
{
    public class CarroController
    {
        private DatabaseService databaseService;
        private SQLiteConnection conexao;

        public CarroController()
        {
            databaseService = new DatabaseService();

            conexao = databaseService.GetConexao();

            conexao.CreateTable<Carro>();
        }

        public bool Insert(Carro value)
        {
            return conexao.Insert(value) > 0;
        }

        public bool Update(Carro value)
        {
            return conexao.Update(value) > 0;
        }

        public bool Delete(Carro value)
        {
            return conexao.Delete(value) > 0;
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
